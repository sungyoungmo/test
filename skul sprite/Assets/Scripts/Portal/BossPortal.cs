using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPortal : Portal
{
    string targetSceneName = "Boss";


    protected override void OnPortal()
    {
        SceneManager.LoadScene("Loading");

        PlayerPrefs.SetString("TargetScene", targetSceneName);
    }
}
