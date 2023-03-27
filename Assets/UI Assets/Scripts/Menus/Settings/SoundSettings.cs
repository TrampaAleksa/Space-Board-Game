using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Assets.Scripts
{
    public class SoundSettings : MonoBehaviour
    {
        public Image SfxFillImage;
        public Image MusicFillImage;
        public float increment = 0.1f;

        public void SlideSfxDown() => ChangeFillSliderValue(-increment, SfxFillImage);
        public void SlideSfxUp() => ChangeFillSliderValue(+increment, SfxFillImage);
        public void SlideMusicDown() => ChangeFillSliderValue(-increment, MusicFillImage);
        public void SlideMusicUp() => ChangeFillSliderValue(+increment, MusicFillImage);

        private void ChangeFillSliderValue(float value, Image fillImage)
        {
            fillImage.fillAmount += Math.Clamp(fillImage.fillAmount + value, 0, 1);
        }
    }
}