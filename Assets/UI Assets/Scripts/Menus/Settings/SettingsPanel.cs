using System;
using UnityEngine;

namespace UI_Assets.Scripts
{
    [RequireComponent(typeof(DisplaySettings), typeof(SoundSettings))]
    public class SettingsPanel : MonoBehaviour
    {
        private DisplaySettings _displaySettings;
        private SoundSettings _soundSettings;

        private void Awake()
        {
            _displaySettings = GetComponent<DisplaySettings>();
            _soundSettings = GetComponent<SoundSettings>();
        }
        
        public void ChangeResolutionUp()
        {
            Debug.Log("R Up");
        }
        public void ChangeResolutionDown()
        {
            Debug.Log("R Down");
        }
        public void ToggleFullscreen()
        {
            
        }
        public void ChangeQualityUp()
        {
            Debug.Log("Q Up");
        }
        public void ChangeQualityDown()
        {
            Debug.Log("Q Down");
        }
        public void ChangeSfxSoundUp()
        {
            
        }
        public void ChangeSfxSoundDown()
        {
            
        }
        public void ChangeMusicSoundUp()
        {
            
        }
        public void ChangeMusicSoundDown()
        {
            
        }
    }

    public enum SettingChangeDirection
    {
        Decrease,
        Increase
    }
}