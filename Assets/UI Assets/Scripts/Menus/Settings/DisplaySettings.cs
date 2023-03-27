using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class DisplaySettings : MonoBehaviour
    {
        public Text resolutionLabel;
        private int _currentResolutionIndex;

        public Text qualityLabel;
        private int _currentQualityIndex;

        public Toggle fullscreenToggle;
        
        private Resolution[] _resolutions;
        private string[] _qualityNames;

        private void Start()
        {
            _resolutions = Screen.resolutions;

            foreach (var resolution in _resolutions)
            {
                if (resolution.width == Screen.currentResolution.width &&
                    resolution.height == Screen.currentResolution.height) ;
            }

            SetInitialResolution();
            DisplayCurrentResolution();

            _qualityNames = QualitySettings.names;
            SetInitialQuality();
            DisplayCurrentQuality();

            fullscreenToggle.isOn = Screen.fullScreen;
        }

        private void SetInitialQuality() => _currentQualityIndex = QualitySettings.GetQualityLevel();
        public void SlideQualityDown()
        {
            _currentQualityIndex--;
            if (_currentQualityIndex < 0) _currentQualityIndex = LastQualityIndex;
            DisplayCurrentQuality();
        }
        public void SlideQualityUp()
        {
            _currentQualityIndex++;
            if (_currentQualityIndex > LastQualityIndex) _currentQualityIndex = 0;
            DisplayCurrentQuality(); 
        }

        
        private void SetInitialResolution() => _currentResolutionIndex = LastResolutionIndex;
        public void SlideResolutionDown()
        {
            _currentResolutionIndex--;
            if (_currentResolutionIndex < 0) _currentResolutionIndex = LastResolutionIndex;
            DisplayCurrentResolution();
        }
        public void SlideResolutionUp()
        {
            _currentResolutionIndex++;
            if (_currentResolutionIndex > LastResolutionIndex) _currentResolutionIndex = 0;
            DisplayCurrentResolution(); 
        }

        public void ToggleFullscreen()
        {
            Debug.Log(fullscreenToggle.isOn);
        }
        
        
        public void ApplySettings()
        {
            Resolution resolution = CurrentResolution;
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            
            QualitySettings.SetQualityLevel(_currentQualityIndex);
            
            Screen.fullScreenMode = fullscreenToggle.isOn ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
        }

        
        
        private void DisplayCurrentResolution() => resolutionLabel.text = ResolutionTextValue(CurrentResolution);
        private string ResolutionTextValue(Resolution resolution) => resolution.width + " x " + resolution.height;
        private Resolution CurrentResolution => _resolutions[_currentResolutionIndex];
        private int LastResolutionIndex => _resolutions.Length - 1;
        
        private void DisplayCurrentQuality() => qualityLabel.text = _qualityNames[_currentQualityIndex];
        private int LastQualityIndex => _qualityNames.Length - 1;
    }
}