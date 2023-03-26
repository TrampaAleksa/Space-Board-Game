using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class UIHandler : MonoBehaviour
    {
        private GameObject _currentPanel;

        private void Start()
        {
            _currentPanel = GameObject.Find("MainMenuPanel");
        }

        public void ExitGame()
        {
            
        }

        public void ChangeResolution()
        {
            
        }

        public void ChangeSound()
        {
            
        }

        public void ToggleFullscreen()
        {
            
        }

        public void OpenPanel(GameObject panel)
        {
            panel.SetActive(true);
            _currentPanel.SetActive(false);
            _currentPanel = panel;
        }
    }
}