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
            
            var lastResolutionIndex = _resolutions.Length - 1;
            currentIndex = lastResolutionIndex;

            label.text = ResolutionTextValue(CurrentResolution);
        }

        public void SlideValueDown()
        {
            
        }
        public void SlideValueUp()
        {
            
        }
        
        
        public string ResolutionTextValue(Resolution resolution) => resolution.width + " x " + resolution.height;
        public Resolution CurrentResolution => _resolutions[currentIndex];
    }
    
}