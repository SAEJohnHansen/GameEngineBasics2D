using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Loads next scene specified by LoadData.cs
public class SceneLoader : MonoBehaviour
{
    public float Delay;
    private string sceneName;
    private void Awake()
    {
        sceneName = LoadData.SceneName;
        Invoke("LoadNextScene", Delay);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
