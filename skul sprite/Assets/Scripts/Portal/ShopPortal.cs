using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopPortal : Portal
{

    string targetSceneName = "Shop";


    protected override void OnPortal()
    {
        SceneManager.LoadScene("Loading");

        PlayerPrefs.SetString("TargetScene", targetSceneName);
    }
}
