using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}
