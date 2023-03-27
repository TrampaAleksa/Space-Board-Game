using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class DisplaySettings : MonoBehaviour
    {
        public int currentResolutionIndex;
        public Text resolutionLabel;
        
        public int currentQualityIndex;
        public Text qualityLabel;

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
            currentQualityIndex = QualitySettings.GetQualityLevel();
            qualityLabel.text = _qualityNames[currentQualityIndex];
        }

        private void SetInitialResolution()
        {
            currentResolutionIndex = LastResolutionIndex;
        }

        public void SlideResolutionDown()
        {
            currentResolutionIndex--;
            if (currentResolutionIndex < 0) currentResolutionIndex = LastResolutionIndex;
            DisplayCurrentResolution();
        }

        public void SlideResolutionUp()
        {
            currentResolutionIndex++;
            if (currentResolutionIndex > LastResolutionIndex) currentResolutionIndex = 0;
            DisplayCurrentResolution(); 
        }

        
        
        public void ApplySettings()
        {
            Resolution resolution = CurrentResolution;
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        
        
        private void DisplayCurrentResolution() => resolutionLabel.text = ResolutionTextValue(CurrentResolution);
        private string ResolutionTextValue(Resolution resolution) => resolution.width + " x " + resolution.height;
        private Resolution CurrentResolution => _resolutions[currentResolutionIndex];
        private int LastResolutionIndex => _resolutions.Length - 1;
    }
}