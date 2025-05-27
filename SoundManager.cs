using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SoundType
{
Hammering,
HandleWrapping,
Grinding,
Walking,
Quenching,
LightingFurnace,
Scroll,
SwordInBox,
DroppingSword,
DroppingIngot,
DroppingOre,
PickingUpOre,
Chains,
DingSound,
MainSoundTrack,
}

//list of sounds
//---------------------------------------------------------------------------

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
//forces the sound manager to always have an audio source
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    //grabs the specifc sound (with all the different variations) that it is going to play.
    private static SoundManager instance = null;
    private AudioSource audioSource;

    private void Awake()
    {
        if (!instance)
        {
            {
                instance = this;
            }
        }
    }

    private void Start()
    {
            audioSource = GetComponent<AudioSource>();
        //finds audio source component
    }

//--------------------------------------------------------------------------------

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        //gets random clip from the clips array
        instance.audioSource.PlayOneShot(randomClip, volume);
        //plays a oneshot of the random clip
    }

//--------------------------------------------------------------------------------
#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++) 
            soundList[i].name = names[i];
    }
#endif
//gets the names from the enum of sound types,
//turns the sound types into strings
//and changes each indiviual array name to those strings.
}
//--------------------------------------------------------------------------------

[Serializable]
public struct SoundList
    //to create an array in an array
{
    public AudioClip[] Sounds { get => sounds; }
    //gets the sounds as this code is private.
    //returns the sound array below.
    [HideInInspector] public string name;
    //Gives Each Array An Option To Input A Name.
    [SerializeField] private AudioClip[] sounds;
}
