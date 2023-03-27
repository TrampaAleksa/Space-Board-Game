using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class DisplaySettings : MonoBehaviour
    {
        public int currentIndex;
        public Text label;

        private Resolution[] _resolutions;

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
        }

        private void SetInitialResolution()
        {
            currentIndex = LastResolutionIndex;
        }

        public void SlideValueDown()
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = LastResolutionIndex;
            DisplayCurrentResolution();
        }

        public void SlideValueUp()
        {
            currentIndex++;
            if (currentIndex > LastResolutionIndex) currentIndex = 0;
            DisplayCurrentResolution();
        }

        
        
        private void DisplayCurrentResolution() => label.text = ResolutionTextValue(CurrentResolution);
        private string ResolutionTextValue(Resolution resolution) => resolution.width + " x " + resolution.height;
        private Resolution CurrentResolution => _resolutions[currentIndex];
        private int LastResolutionIndex => _resolutions.Length - 1;
    }
}