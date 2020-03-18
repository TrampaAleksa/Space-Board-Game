using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public const string DAMAGE_PLAYER="damagePlayer", DICE_ROLL="diceRoll",
    MINE="mine", NOTIF="notif", SHORT_CLICK="shortClick", 
    START_OF_TURN="startOfTurn", TELEPORT="teleport";
    public AudioClip[] clips;
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
        clips=Resources.LoadAll<AudioClip>("Sounds/");
        AudioSource[] audioSource = new AudioSource[audioArray.Length];
        for (int i=0;i<clips.Length;i++)
        {
            gameObject.AddComponent(typeof(AudioSource));
            audioSource = gameObject.GetComponents<AudioSource>();
            audioArray[i].tag=clips[i].name;
            audioSource[i].clip=clips[i];
            audioSource[i].volume = audioArray[i].volume;
            audioSource[i].loop = audioArray[i].loop;
            audioSource[i].playOnAwake = audioArray[i].playOnAwake;
            audioSource[i].outputAudioMixerGroup=Resources.LoadAll<AudioMixerGroup>("Sounds/")[0];
            audioArray[i].link = audioSource[i];
        }
    }
    private void Update() {
        if(Input.GetKeyDown("k"))
        {
            PlaySound(TELEPORT);
        }
    }
    public void PlaySound(string name) 
    {
        foreach (Audio audio in audioArray)
        {
            if(audio.tag==name)
            {
                audio.link.Play();
                Debug.Log("Prosao");
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