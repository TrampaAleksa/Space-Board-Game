using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeySystem : MonoBehaviour
{
    public GameObject pointer;
    Transform saveOffset;
    public bool horizontalRightArrowPressed;
    public bool verticalDownArrowPressed;
    public bool allowedHorizontalMove=false;
    public GameObject mainMenuPanel;
    public GenericObjectArray panels;
    public GenericObjectArray buttonsUI;
    public List<Selectable> verticalsUI=new List<Selectable>();
    public List<Selectable> horizontalsUI=new List<Selectable>();
    public Selectable verticalObjectUI;
    public Selectable horizontalObjectUI;
    int lastIndex;
    int verticalIndex;
    int horizontalIndex;
    int panelIndex;
    private void Start() 
    {
        panels=gameObject.AddComponent<GenericObjectArray>();
        panels.gameObjects=GameObject.FindGameObjectsWithTag("UI");
        buttonsUI=gameObject.AddComponent<GenericObjectArray>();
        buttonsUI.gameObjects=GameObject.FindGameObjectsWithTag("MainMenuButton");
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
        }      
        if(Input.GetKeyDown(KeyCode.Escape))
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
    void FadeAlpha(GameObject gameObject, bool boolean)
    {
        Graphic graphic= gameObject.GetComponent<Graphic>();
        if(boolean)
            graphic.CrossFadeAlpha(1,0.5f,true);
        else    graphic.CrossFadeAlpha(0,0.5f,true);
    }
    void HorizontalFadeAlpha(GameObject gameObject, bool boolean)
    {
        Graphic graphic= gameObject.GetComponent<Graphic>();
        if(boolean)
            graphic.CrossFadeAlpha(1,1,true);
        else    graphic.CrossFadeAlpha(0.3f,1,true);
    }
    void SelectButton()
    {
        if(verticalsUI.Count>0){
            FadeAlpha(verticalObjectUI.gameObject,false);
            verticalObjectUI=verticalsUI[verticalIndex];
            FadeAlpha(verticalObjectUI.gameObject,true);
            Selectable[] tmp=verticalObjectUI.GetComponentsInChildren<Selectable>();
            if(allowedHorizontalMove)
                HorizontalFadeAlpha(horizontalObjectUI.gameObject,true);
            horizontalsUI.Clear();
            if(tmp.Length>1 && !mainMenuPanel.activeSelf)
            {
                allowedHorizontalMove=true;
                horizontalsUI.AddRange(tmp);
                horizontalObjectUI=horizontalsUI[horizontalIndex+1];
                if(horizontalObjectUI.GetComponent<Button>()!=null)
                    HorizontalFadeAlpha(horizontalObjectUI.gameObject,false);
            }
            else allowedHorizontalMove=false;
        }
    }
    void HorizontalSelectButton()
    {
        HorizontalFadeAlpha(horizontalObjectUI.gameObject,true);
        horizontalObjectUI=horizontalsUI[horizontalIndex];
        HorizontalFadeAlpha(horizontalObjectUI.gameObject,false);
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
        SelectButton();
    }
    void Quit()
    {
        GoToPanel(panels.MemberWithIndex(verticalIndex));
    }
    void PressButton()
    {
        panelIndex=verticalIndex;
        GoToPanel(panels.MemberWithIndex(verticalIndex));
        verticalIndex=0;
        ChangedPanel();
    }
    void BackButton()
    {
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
        Selectable[] tmp= new Selectable[panels.ArrayLength()];
        for(int i=0;i<panels.ArrayLength();i++){
            tmp[i]=buttonsUI.MemberWithIndex(i).GetComponent<Button>();
            panels.MemberWithIndex(i).SetActive(false);
        }
        verticalsUI.AddRange(tmp);
        verticalObjectUI=verticalsUI[verticalIndex];
    }
}

