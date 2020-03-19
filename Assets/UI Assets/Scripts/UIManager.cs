using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;
    public GameObject[] inputsGameObject;
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;
    public GameObject settingsPanel;
    public GameObject inputPanel;
    public GameObject creditsPanel;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public void InputAllNamesForPlayers()
    {
        if(CheckForInputsAreEmpty() && CheckThatNamesAreNotEqual())
        {
            for(int i=0;i<playerBoardStates.Length;i++)
            {
                playerBoardStates[i].playerName=inputsGameObject[i].GetComponent<InputField>().text;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
        else    print("Unesi ponovo");
    }
    public bool CheckForInputsAreEmpty()
    {
        for (int i = 0; i < inputsGameObject.Length; i++)
        {
            if(string.IsNullOrEmpty(inputsGameObject[i].GetComponent<InputField>().text) || inputsGameObject[i].GetComponent<InputField>().text.Length>7)
                return false;
        }
        return true;
    }
    public bool CheckThatNamesAreNotEqual()
    {
        for (int i = 0; i < inputsGameObject.Length-1; i++)
        {
            for (int j = i+1; j < inputsGameObject.Length ; j++)
            {
               if(inputsGameObject[i].GetComponent<InputField>().text.ToLower().Equals(inputsGameObject[j].GetComponent<InputField>().text.ToLower()) )
                  return false;
            }
        }
        return true;
    }
    public void Input()
    {
        mainMenuPanel.SetActive(false);
        inputPanel.SetActive(true);
    }
    public void Confirm()
    {
        InputAllNamesForPlayers();
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
        inputsGameObject=GameObject.FindGameObjectsWithTag("PInput");
        Back();
    }
}
