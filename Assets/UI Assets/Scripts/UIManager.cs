using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<GameObject> inputsGameObject;
    public AudioMixer masterMixer;
    Resolution[] resolutions;
    public static UIManager Instance;
    void Awake()
    {
        Instance=this;
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
                currentResolutionIndex = i;
        }
        ResolutionSlide.Instance.AddOptions(options);
        ResolutionSlide.Instance.index = currentResolutionIndex;
        ResolutionSlide.Instance.RefreshShownValue();
    }
    public void InputAllNamesForPlayers()
    {
        if(CheckForInputsAreEmpty() && CheckThatNamesAreNotEqual())
            for(int i=0;i<BoardStateHolder.Instance.playerBoardStates.Length;i++)
            {
                BoardStateHolder.Instance.playerBoardStates[i].playerName=inputsGameObject[i].GetComponent<InputField>().text;
                SceneManager.LoadScene(1);
            }
        else    print("Unesi ponovo");
    }
    public bool CheckForInputsAreEmpty()
    {
        for (int i = 0; i < inputsGameObject.Count; i++)
            if(string.IsNullOrEmpty(inputsGameObject[i].GetComponent<InputField>().text))
                return false;
        return true;
    }
    public bool CheckThatNamesAreNotEqual()
    {
        for (int i = 0; i < inputsGameObject.Count-1; i++)
            for (int j = i+1; j < inputsGameObject.Count ; j++)
               if(inputsGameObject[i].GetComponent<InputField>().text.ToLower().Equals(inputsGameObject[j].GetComponent<InputField>().text.ToLower()) )
                  return false;
        return true;
    }
    public void SetMusicValue(float volume) 
    {
        masterMixer.SetFloat("musicVolume", volume);
    }
    public void SetSfxValue(float volume) 
    {
        masterMixer.SetFloat("sfxVolume", volume);
    }
    public void SetQuiality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void ApplyResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ImportInputs()
    {
        inputsGameObject.Clear();
        inputsGameObject.AddRange(GameObject.FindGameObjectsWithTag("PInput"));
        Player3DController.Instance.ShowSpaceShip();
    }
}