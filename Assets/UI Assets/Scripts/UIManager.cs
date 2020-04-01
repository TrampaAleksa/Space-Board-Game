using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    //public PlayerBoardState[] playerBoardStates;
    public GameObject[] inputsGameObject;
    public Button playButton;
    public Button controlsButton;
    public Button settingsButton;
    public Button creditButton;
    public Button quitButton;
    public Button backButton;
    public GameObject controlsPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject inputPanel;
    public GameObject creditsPanel;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        inputsGameObject=GameObject.FindGameObjectsWithTag("PText");
        playButton.onClick.AddListener(()=>GoToPanel(inputPanel));
        creditButton.onClick.AddListener(()=>GoToPanel(creditsPanel));
        settingsButton.onClick.AddListener(()=>GoToPanel(settingsPanel));
        controlsButton.onClick.AddListener(()=>GoToPanel(controlsPanel));
        quitButton.onClick.AddListener(Quit);
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Back();
    }
    public void InputAllNamesForPlayers()
    {
        if(CheckForInputsAreEmpty() && CheckThatNamesAreNotEqual())
            for(int i=0;i<BoardStateHolder.Instance.playerBoardStates.Length;i++)
            {
                BoardStateHolder.Instance.playerBoardStates[i].playerName=inputsGameObject[i].GetComponent<InputField>().text;
                AudioManager.Instance.PlaySound(AudioManager.SHORT_CLICK);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        else    print("Unesi ponovo");
    }
    public bool CheckForInputsAreEmpty()
    {
        for (int i = 0; i < inputsGameObject.Length; i++)
            if(string.IsNullOrEmpty(inputsGameObject[i].GetComponent<InputField>().text) || inputsGameObject[i].GetComponent<InputField>().text.Length>7)
                return false;
        return true;
    }
    public bool CheckThatNamesAreNotEqual()
    {
        for (int i = 0; i < inputsGameObject.Length-1; i++)
            for (int j = i+1; j < inputsGameObject.Length ; j++)
               if(inputsGameObject[i].GetComponent<InputField>().text.ToLower().Equals(inputsGameObject[j].GetComponent<InputField>().text.ToLower()) )
                  return false;
        return true;
    }
    public void Confirm()
    {
        InputAllNamesForPlayers();
    }
    public void GoToPanel(GameObject gameObject)
    {
        AudioManager.Instance.PlaySound(AudioManager.SHORT_CLICK);
        mainMenuPanel.SetActive(false);
        gameObject.SetActive(true);
        backButton=GetComponentInChildren<Button>();
        backButton.onClick.AddListener(Back);
    }
    public void Back() 
    {
        AudioManager.Instance.PlaySound(AudioManager.SHORT_CLICK);
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        inputPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void Quit()
    {
        AudioManager.Instance.PlaySound(AudioManager.SHORT_CLICK);
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
}