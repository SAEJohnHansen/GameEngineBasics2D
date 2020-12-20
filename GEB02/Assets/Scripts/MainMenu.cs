using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;
    public AudioMixer Mixer;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float value)
    {
        Mixer.SetFloat("MasterVolume", Mathf.Log10(value + 0.01f) * 20);
    }
    public void SettingsToggle()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);

        if (SettingsPanel.activeSelf)
        {
            SettingsPanel.SetActive(false);
        }
        else
        {
            SettingsPanel.SetActive(true);
        }
    }


}
