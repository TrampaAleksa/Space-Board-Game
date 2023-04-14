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

        public float volumeValueTest = 60f;

        public void SlideSfxDown()
        {
            var newVolumeScale = ChangeFillSliderValue(-increment, SfxFillImage);
            var volumeLin = GetLinearizedVolumeScale(newVolumeScale);
            
            masterMixer.SetFloat("sfxVolume", volumeLin);
            
            AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
        }

        public void SlideSfxUp()
        {
            var newVolumeScale = ChangeFillSliderValue(+increment, SfxFillImage);
            var volumeLin = GetLinearizedVolumeScale(newVolumeScale);
            
            masterMixer.SetFloat("sfxVolume", volumeLin);

            AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
        }

        public void SlideMusicDown()
        {
            var newVolumeScale = ChangeFillSliderValue(-increment, MusicFillImage);
            var volumeLin = GetLinearizedVolumeScale(newVolumeScale);

            masterMixer.SetFloat("musicVolume", volumeLin);
            
            AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
        }

        public void SlideMusicUp()
        {
            var newVolumeScale = ChangeFillSliderValue(+increment, MusicFillImage);
            var volumeLin = GetLinearizedVolumeScale(newVolumeScale);
            
            masterMixer.SetFloat("musicVolume", volumeLin);
            
            AudioManager.Instance.PlaySound(AudioManager.SELECT,false,1f);
        }

        private float ChangeFillSliderValue(float value, Image fillImage)  // 0-1 scale
        {
           return fillImage.fillAmount = Math.Clamp(fillImage.fillAmount + value, 0, 1);
        }

        private float GetLinearizedVolumeScale(float scale) // since sound mixers work with DB we need linearized sliders
        {
            var log = 40 * Mathf.Log10((scale * 100f) + 0.01f); // needs percentages from 0-100
            var volumeLin = -(80 -log);
            // var volumeDB = -(1f - newVolume) * 80f;

            return volumeLin;
        }
    }
}