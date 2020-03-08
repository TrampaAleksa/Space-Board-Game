using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Audio
    {
        public string tag;
        public static AudioMixer mixer;
        public AudioClip clip;
        public AudioSource link;
        public bool playOnAwake;
        public bool loop;
        public int volume;
    }

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Audio[] audioArray;

    private void Start()
    {
        int i = 0;
        AudioSource[] audioSource = new AudioSource[audioArray.Length];
        foreach (Audio audio in audioArray)
        {
            gameObject.AddComponent(typeof(AudioSource));
            audioSource = gameObject.GetComponents<AudioSource>();
            audioSource[i].clip = audio.clip;
            audioSource[i].volume = audio.volume;
            audioSource[i].loop = audio.loop;
            audioSource[i].playOnAwake = audio.playOnAwake;
            audio.link = audioSource[i];
            i++;
        }
    }
}