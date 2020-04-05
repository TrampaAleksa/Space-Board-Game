using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeySystem : MonoBehaviour
{
    public bool allowedHorizontalMove=false;
    public bool horizontalMove=false;
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
        if(Input.GetKeyDown(KeyCode.LeftArrow) && horizontalMove)
        {
            horizontalIndex++;
            if(horizontalIndex>=horizontalsUI.Count)
                horizontalIndex=0;
            SelectButton();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && horizontalMove)
        {
            horizontalIndex--;
            if(horizontalIndex<0)
                horizontalIndex=horizontalsUI.Count-1;
            SelectButton();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)&& !horizontalMove)
        {
            lastIndex=verticalIndex;
            verticalIndex++;
            if(verticalIndex>=verticalsUI.Count)
                verticalIndex=0;
            SelectButton();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)&& !horizontalMove)
        {
            lastIndex=verticalIndex;
            verticalIndex--;
            if(verticalIndex<0)
                verticalIndex=verticalsUI.Count-1;
            SelectButton();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(!allowedHorizontalMove)
                Invoke("PressButton",0.1f);
            else
                Invoke("IntoSettings",0.1f);
        }      
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!horizontalMove)
                Invoke("BackButton",0.1f);
            else
                Invoke("GoBack",0.1f);
        }
        
    }
    void ChangeColor(Color clr1, Color clr2)
    {
        Graphic graphic= verticalObjectUI.GetComponent<Graphic>();
        graphic.CrossFadeAlpha(clr1.a,clr2.a,true);
    }
    void SelectButton()
    {
        Selectable tmpUIObject=verticalsUI[lastIndex];
        verticalObjectUI=verticalsUI[verticalIndex];
        ChangeColor(verticalObjectUI.colors.highlightedColor, verticalObjectUI.colors.normalColor);
        ChangeColor(tmpUIObject.colors.normalColor, tmpUIObject.colors.highlightedColor);
        Selectable[] tmp=verticalObjectUI.GetComponentsInChildren<Selectable>();
        if( tmp.Length>0 && !mainMenuPanel.activeSelf)
        {
            horizontalsUI.Clear();
            allowedHorizontalMove=true;
            horizontalsUI.InsertRange(0,tmp);
            horizontalObjectUI=horizontalsUI[horizontalIndex];   
        }
        else {horizontalsUI.Clear();allowedHorizontalMove=false;}
    }
    void ChangedPanel()
    {
        verticalsUI.Clear();
        Selectable[] tmp=panels.GetComponentsInChildren<Button>();
        verticalsUI.AddRange(tmp);
    }
    void Quit()
    {
        UIManager.Instance.GoToPanel(panels.MemberWithIndex(verticalIndex));
    }
    void PressButton()
    {
        panelIndex=verticalIndex;
        UIManager.Instance.GoToPanel(panels.MemberWithIndex(verticalIndex));
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
    void GoBack()
    {
        print("stisnup");
        horizontalMove=false;
    }
    void IntoSettings()
    {
        horizontalMove=true;
    }
    void MainMenuReset()
    {
        Selectable[] tmp= new Selectable[panels.ArrayLength()];
        for(int i=0;i<panels.ArrayLength();i++){
            tmp[i]=buttonsUI.MemberWithIndex(i).GetComponent<Button>();
            panels.MemberWithIndex(i).SetActive(false);
        }
        verticalsUI.AddRange(tmp);
    }
}

