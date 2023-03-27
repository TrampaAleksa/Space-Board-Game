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
            _displaySettings.SlideResolutionUp();
        }
        public void ChangeResolutionDown()
        {
            _displaySettings.SlideResolutionDown();

        }
        public void ToggleFullscreen()
        {
            
        }
        public void ChangeQualityUp()
        {
            _displaySettings.SlideQualityUp();
        }
        public void ChangeQualityDown()
        {
            _displaySettings.SlideQualityDown();

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

        public void ApplySettings()
        {
            _displaySettings.ApplySettings();
        }
    }

    public enum SettingChangeDirection
    {
        Decrease,
        Increase
    }
}