using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public const string DAMAGE_PLAYER="damagePlayer",DESELECT="deselect", 
    DICE_ROLL="diceRoll", MAIN_MENU_BACKGROUND="mainMenuBackground",
    MINE="mine", NOTIF="notif", SELECT="select", SHORT_CLICK="shortClick", 
    START_OF_TURN="startOfTurn", TELEPORT="teleport", OVERHEAT="overheat", REFILL="refill",
    STEAL_FUEL="steelFuel";
    [System.Serializable]
    public class Audio
    {
        protected string nameOfAudio;
        protected AudioSource link;
        public string NameOfAudio { get { return nameOfAudio; } set { nameOfAudio = value; } }
        public AudioSource Link { get { return link; } set { link=value; } }
    }
    public static AudioManager Instance;
    protected List<Audio> audioArray= new List<Audio>();
    AudioSource[] sources;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        else    Destroy(gameObject);

        List<AudioClip> clips= new List<AudioClip>();
        clips.AddRange(Resources.LoadAll<AudioClip>("Sounds/"));
        sources= new AudioSource[clips.Count];
        for (int i=0;i<clips.Count;i++)
        {
            sources=gameObject.AddComponent(typeof(AudioSource)).GetComponents<AudioSource>();
            Audio audio= new Audio();
            audioArray.Add(audio);
            sources[i].clip=clips[i];
            sources[i].volume = 1;
            sources[i].playOnAwake = false;
            sources[i].loop = false;
            if(clips[i].name=="mainMenuBackground")
                sources[i].outputAudioMixerGroup=Resources.LoadAll<AudioMixerGroup>("Sounds/")[2];
            else sources[i].outputAudioMixerGroup=Resources.LoadAll<AudioMixerGroup>("Sounds/")[0];
            audioArray[i].Link = sources[i];
            audioArray[i].NameOfAudio=clips[i].name;
        }
    }
    public void PlaySound(string name, bool loop, float volume) 
    {
        foreach (Audio audio in audioArray)
        {
            if(audio.NameOfAudio==name)
            {
                audio.Link.Play();
                audio.Link.loop=loop;
                audio.Link.volume=volume;
            }
        }
    }
    public void StopSound(string name) 
    {
        foreach (Audio audio in audioArray)
        {
            if(audio.NameOfAudio==name)
            {
                audio.Link.Stop();
            }
        }
    }
    public void PauseAllSounds(string name, bool boolean)
    {
        foreach (Audio audio in audioArray)
        {
            if(boolean)
                audio.Link.Pause();
            else audio.Link.UnPause();
        }
    }
}