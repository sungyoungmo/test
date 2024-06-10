using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    void Start()
    {
        string targetSceneName = PlayerPrefs.GetString("TargetScene", "");

        if (!string.IsNullOrEmpty(targetSceneName))
        {
            StartCoroutine(LoadAsyncScene(targetSceneName));
        }
        else
        {
            Debug.LogError("Target scene name is empty!");
        }
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
