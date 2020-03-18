using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioClip[] clips;
    [System.Serializable]
    public class Audio
    {
        public string tag;
        public AudioSource link;
        public bool playOnAwake;
        public bool loop;
        [Range(0.0f, 1.0f)]
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
        clips=Resources.LoadAll<AudioClip>("Sounds/");
        AudioSource[] audioSource = new AudioSource[audioArray.Length];
        foreach (Audio audio in audioArray)
        {
            gameObject.AddComponent(typeof(AudioSource));
            audioSource = gameObject.GetComponents<AudioSource>();
            audioSource[i].volume = audio.volume;
            audioSource[i].loop = audio.loop;
            audioSource[i].playOnAwake = audio.playOnAwake;
            audioSource[i].outputAudioMixerGroup=Resources.LoadAll<AudioMixerGroup>("Sounds/")[0];
            for(int j=0;j<clips.Length;j++)
            {
                if(clips[j].name==audio.tag)
                {
                    audioSource[i].clip=clips[j];
                }
            }
            audio.link = audioSource[i];
            i++;
        }
    }
    public void PlaySound(string name) 
    {
        foreach (Audio audio in audioArray)
        {
            if(audio.tag==name)
            {
                audio.link.Play();
            }
        }
    }
    public void StopSound(string name) 
    {
        foreach (Audio audio in audioArray)
        {
            if(audio.tag==name)
            {
                audio.link.Play();
            }
        }
    }
    public void PlayOrPauseAllSounds(string name)
    {
        foreach (Audio audio in audioArray)
        {
            if(audio.link.isPlaying)
                audio.link.Pause();
            else audio.link.UnPause();
        }
    }
    public void LoopOnOrOff(string name)
    {
        foreach (Audio audio in audioArray)
        {
            audio.loop = !audio.loop;
        }
    }
}