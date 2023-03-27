using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class SoundSettings : MonoBehaviour
    {
        public AudioMixer masterMixer;
        
        public Image SfxFillImage;
        public Image MusicFillImage;
        public float increment = 0.1f;

        private void Start()
        {
            AudioManager.Instance.PlaySound(AudioManager.MAIN_MENU_BACKGROUND,true,1f);
        }

        public void SlideSfxDown()
        {
            var newVolume = ChangeFillSliderValue(-increment, SfxFillImage);
            AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);

            masterMixer.SetFloat("sfxVolume", -(1f - newVolume) * 80f);
        }

        public void SlideSfxUp()
        {
            var newVolume = ChangeFillSliderValue(+increment, SfxFillImage);
            AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
            masterMixer.SetFloat("sfxVolume", -(1f - newVolume) * 80f);
        }

        public void SlideMusicDown()
        {
            var newVolume = ChangeFillSliderValue(-increment, MusicFillImage);
            masterMixer.SetFloat("musicVolume", -(1f - newVolume) * 80f);
        }

        public void SlideMusicUp()
        {
            var newVolume = ChangeFillSliderValue(+increment, MusicFillImage);
            masterMixer.SetFloat("musicVolume", -(1f - newVolume) * 80f);
        }

        private float ChangeFillSliderValue(float value, Image fillImage)
        {
           return fillImage.fillAmount = Math.Clamp(fillImage.fillAmount + value, 0, 1);
        }
    }
}