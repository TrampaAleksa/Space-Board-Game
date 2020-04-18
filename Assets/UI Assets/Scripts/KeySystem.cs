using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeySystem : MonoBehaviour
{
    public GameObject pointer;
    public bool horizontalRightArrowPressed;
    public bool verticalDownArrowPressed;
    public bool allowedHorizontalMove=false;
    public GameObject mainMenuPanel;
    public List<GameObject> panels;
    public List<GameObject> buttonsUI;
    public List<Selectable> verticalsUI=new List<Selectable>();
    public List<Selectable> horizontalsUI=new List<Selectable>();
    public Selectable verticalObjectUI;
    public Selectable horizontalObjectUI;
    int verticalIndex;
    int horizontalIndex;
    int panelIndex;
    private void Start() 
    {
        //Cursor.visible=false;
        //Cursor.lockState=CursorLockMode.Locked;
        AudioManager.Instance.PlaySound(AudioManager.MAIN_MENU_BACKGROUND,true,1f);
        MainMenuReset();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && allowedHorizontalMove)
        {
            horizontalRightArrowPressed=false;
            horizontalIndex=Move(horizontalsUI,horizontalIndex,horizontalRightArrowPressed,1);
            HorizontalSelectButton();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && allowedHorizontalMove)
        {
            horizontalRightArrowPressed=true;
            horizontalIndex=Move(horizontalsUI,horizontalIndex,horizontalRightArrowPressed,1);
            HorizontalSelectButton();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            horizontalIndex=0;
            verticalDownArrowPressed=true;
            verticalIndex=Move(verticalsUI,verticalIndex,verticalDownArrowPressed,0);
            SelectButton();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            horizontalIndex=0;
            verticalDownArrowPressed=false;
            verticalIndex=Move(verticalsUI,verticalIndex,verticalDownArrowPressed,0);
            SelectButton();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(mainMenuPanel.activeSelf)
                Invoke("PressButton",0.1f);
            else if(horizontalObjectUI.GetComponent<Button>()!=null)
                Invoke("ApplyOrStart",0.1f);
        }      
        if(Input.GetKeyDown(KeyCode.Escape) && !mainMenuPanel.activeSelf)
        {
            Invoke("BackButton",0.1f);
        }
    }
    int Move(List<Selectable> list,int index,bool boolean, int bound)
    {
        if(boolean)    index++;
        else    index--;
        if(index<bound)
            index=list.Count-1;
        else if(index>=list.Count)
            index=bound;
        return index;
    }
    void FadeAlpha(GameObject gameObject,float alpha,float time, bool boolean)
    {
        Graphic graphic= gameObject.GetComponent<Graphic>();
        graphic.CrossFadeAlpha(alpha,time,true);
        if(gameObject.GetComponentInChildren<Text>()!=null && boolean)
            gameObject.GetComponentInChildren<Text>().CrossFadeAlpha(alpha,time,true);
    }
    void SelectButton()
    {
        AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
        if(verticalsUI.Count>0){
            FadeAlpha(verticalObjectUI.gameObject,0,0.5f,false);
            verticalObjectUI=verticalsUI[verticalIndex];
            FadeAlpha(verticalObjectUI.gameObject,1,0.5f,false);
            Selectable[] tmp=verticalObjectUI.GetComponentsInChildren<Selectable>();
            if(allowedHorizontalMove)
                FadeAlpha(horizontalObjectUI.gameObject,0.5f,0.5f,true);
            horizontalsUI.Clear();
            if(tmp.Length>1 && !mainMenuPanel.activeSelf)
            {
                allowedHorizontalMove=true;
                horizontalsUI.AddRange(tmp);
                horizontalObjectUI=horizontalsUI[horizontalIndex+1];
                if(horizontalObjectUI.GetComponent<Button>()!=null)
                    FadeAlpha(horizontalObjectUI.gameObject,1,0.1f,true);
            }
            else allowedHorizontalMove=false;
        }
    }
    void HorizontalSelectButton()
    {
        AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
        FadeAlpha(horizontalObjectUI.gameObject,1,0.5f,true);
        horizontalObjectUI=horizontalsUI[horizontalIndex];
        FadeAlpha(horizontalObjectUI.gameObject,0.3f,0.5f,true);
        if(horizontalObjectUI.GetComponentInChildren<Toggle>()!=null)
            horizontalObjectUI.GetComponentInChildren<Toggle>().isOn=!horizontalObjectUI.GetComponentInChildren<Toggle>().isOn;
        else if(horizontalObjectUI.GetComponentInChildren<Slider>()!=null)
            {
                if(horizontalRightArrowPressed)
                    horizontalObjectUI.GetComponent<SliderController>().PressedRightButton();
                else horizontalObjectUI.GetComponent<SliderController>().PressedLeftButton();
            }
        else if(horizontalObjectUI.GetComponent<ResolutionSlide>()!=null)
        {
            if(horizontalRightArrowPressed)
                    horizontalObjectUI.GetComponent<ResolutionSlide>().PressedRightButton();
                else horizontalObjectUI.GetComponent<ResolutionSlide>().PressedLeftButton();
        }
        else if(horizontalObjectUI.GetComponent<QualitySlider>()!=null)
        {
            if(horizontalRightArrowPressed)
                    horizontalObjectUI.GetComponent<QualitySlider>().PressedRightButton();
                else horizontalObjectUI.GetComponent<QualitySlider>().PressedLeftButton();
        }
        else if(horizontalObjectUI.GetComponent<InputField>()!=null)
        {
            horizontalObjectUI.GetComponent<InputField>().ActivateInputField();
            pointer.transform.SetParent(horizontalObjectUI.transform.parent, false);
        }
    }
    void ChangedPanel()
    {
        verticalsUI.Clear();
        GameObject[] tmp=GameObject.FindGameObjectsWithTag("VerticalMenu");
        for(int i=0;i<tmp.Length;i++)
            verticalsUI.Add(tmp[i].GetComponent<Selectable>());
    }
    void Quit()
    {
        GoToPanel(panels[verticalIndex]);
    }
    void PressButton()
    {
        AudioManager.Instance.PlaySound(AudioManager.SHORT_CLICK,false,1f);
        panelIndex=verticalIndex;
        horizontalIndex=0;
        GoToPanel(panels[verticalIndex]);
        if(panelIndex==0)
            UIManager.Instance.ImportInputs();
        else if(panelIndex==2)
            ResolutionSlide.Instance.CopyIndex();QualitySlider.Instance.CopyIndex();
        verticalIndex=0;
        ChangedPanel();
    }
    void BackButton()
    {
        AudioManager.Instance.PlaySound(AudioManager.DESELECT,false,0.5f);
        horizontalIndex=0;
        if(panelIndex==2)
            {ResolutionSlide.Instance.RevertSettings();QualitySlider.Instance.RevertSettings();}
        else if(panelIndex==0)
            Player3DController.Instance.DisableSpaceShip();
        mainMenuPanel.SetActive(true);
        verticalIndex=panelIndex;
        verticalsUI.Clear();
        MainMenuReset();
    }
    public void GoToPanel(GameObject gameObject)
    {
        mainMenuPanel.SetActive(false);
        gameObject.SetActive(true);
    }
    void MainMenuReset()
    {
        Selectable[] tmp= new Selectable[panels.Count];
        for(int i=0;i<panels.Count;i++){
            panels[i].SetActive(false);
            tmp[i]=buttonsUI[i].GetComponent<Button>();
        }
        verticalsUI.AddRange(tmp);
        verticalObjectUI=verticalsUI[verticalIndex];
    }
    void ApplyOrStart()
    {
        if(panelIndex==0)
        {
            UIManager.Instance.InputAllNamesForPlayers();
        }
        else if(panelIndex==2)
        {
            ResolutionSlide.Instance.ApplySettings();
            QualitySlider.Instance.ApplySettings();
        }
        else if(panelIndex==4)
        {
            if(horizontalObjectUI.GetComponentInChildren<Text>().text=="Yes")
                BackButton();
            else Application.Quit();
        }
    }
}
