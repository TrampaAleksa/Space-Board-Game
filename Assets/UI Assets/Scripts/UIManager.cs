using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject[] inputsGameObject;
    public GameObject mainMenuPanel;
    public Button playButton;
    public Button controlsButton;
    public Button settingsButton;
    public Button creditButton;
    public Button quitButton;
    public Button backButton;
    public AudioMixer audioMixer;
    public ResolutionSlide resolutionSlide;
    Resolution[] resolutions;
    public static UIManager Instance;
    void Awake()
    {
        Instance=this;
    }
    private void Start()
    {
        inputsGameObject=GameObject.FindGameObjectsWithTag("PInput");
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
        resolutionSlide.AddOptions(options);
        resolutionSlide.index = currentResolutionIndex;
        resolutionSlide.RefreshShownValue();
        
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
            if(string.IsNullOrEmpty(inputsGameObject[i].GetComponent<InputField>().text))
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
    public string SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        return resolution.width +"x"+resolution.height;
    }
    public void ApplyResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}