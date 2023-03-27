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
        
        public void ChangeResolution(SettingChangeDirection changeDirection)
        {

        }
        public void ToggleFullscreen()
        {
            
        }
        public void ChangeQuality(SettingChangeDirection changeDirection)
        {
            
        }
        public void ChangeSfxSound(SettingChangeDirection changeDirection)
        {
            
        }
        public void ChangeMusicSound(SettingChangeDirection changeDirection)
        {
            
        }
    }

    public enum SettingChangeDirection
    {
        Decrease,
        Increase
    }
}