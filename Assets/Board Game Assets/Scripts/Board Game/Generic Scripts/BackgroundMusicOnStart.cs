using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicOnStart : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlaySound(AudioManager.MAIN_MENU_BACKGROUND, true, 1f);
    }
}