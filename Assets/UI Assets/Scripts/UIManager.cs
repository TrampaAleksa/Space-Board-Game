using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;
    public GameObject settingsPanel;
    public GameObject inputPanel;
    public GameObject creditsPanel;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    public void Input()
    {
        mainMenuPanel.SetActive(false);
        inputPanel.SetActive(true);
    }
    public void Confirm()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Controls() 
    {
        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void Credits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void Back() 
    {
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        inputPanel.SetActive(false);
        creditsPanel.SetActive(false);

        mainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuiality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    private void Start()
    {
        Back();
        
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
