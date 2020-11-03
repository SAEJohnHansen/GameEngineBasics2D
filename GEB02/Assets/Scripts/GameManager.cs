using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int CurrentPlayerHealth;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LoadData.SceneName = "SampleScene";
            SceneManager.LoadScene("LoadingScene");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadData.SceneName = "LevelTesting";
            SceneManager.LoadScene("LoadingScene");
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("LevelTesting");
    }

}
