using System;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;
    private Dictionary<string, AudioClip> levelMusicMap;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeLevelMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        PlayMusic(global::Sounds.Music);
    }
    private void InitializeLevelMusic()
    {
        levelMusicMap = new Dictionary<string, AudioClip>
        {
            { "Main Menu", getSoundClip(global::Sounds.Music) },
            { "Level 1", getSoundClip(global::Sounds.Level1Music) },
            { "Level 2", getSoundClip(global::Sounds.Level2Music) },
            { "Level 3", getSoundClip(global::Sounds.Level3Music) },
            // Add more levels as needed
        };
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    public void PlayLevelMusic(string levelName)
    {
        if (levelMusicMap.TryGetValue(levelName, out AudioClip clip))
        {
            if (soundMusic.clip != clip)
            {
                soundMusic.Stop();
                soundMusic.clip = clip;
                soundMusic.Play();
            }
        }
        else
        {
            Debug.LogError("No music found for level: " + levelName);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {

            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }


    }
    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
    public void MoveSoundPlayer(Sounds sound, bool isMoving)
    {
        AudioClip audioClip = getSoundClip(sound);
        if (audioClip != null)
        {
            if (isMoving)
            {
                if (!soundEffect.isPlaying)// Only play if not already playing
                {
                    soundEffect.clip = audioClip;
                    soundEffect.loop = true;// Enable looping for footsteps
                    soundEffect.Play();
                }
            }
            else
            {
                if (soundEffect.isPlaying) // Stop when no movement
                {
                    soundEffect.Stop();// Instantly stop the sound
                    soundEffect.loop = false;
                    soundEffect.clip = null;
                }

                // Play a short sound when the player quickly taps movement keys


            }


        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);

        }
    }
    public void PlayerLoss(Sounds sound, bool playerDead)
    {
        AudioClip soundClip = getSoundClip(sound);
        if (playerDead)
        {
            soundEffect.PlayOneShot(soundClip);
        }

    }
    public void FinishLine(Sounds sound, bool reachedFinishLine)
    {
        AudioClip soundClipp = getSoundClip(sound);
        if (reachedFinishLine)
        {
            soundEffect.PlayOneShot(soundClipp);
        }
    }
    public void PlayerHurt(Sounds sound, bool isHurt)
    {
        AudioClip hurtClip = getSoundClip(sound);
        if (isHurt)
        {
            soundEffect.PlayOneShot(hurtClip);
        }
    }



}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    Level1Music,
    Level2Music,
    Level3Music,
    PlayerMove,
    PlayerDeath,
    Finish,
    EnemyDeath,
    Hurt,
}
