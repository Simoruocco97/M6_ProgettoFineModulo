using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sounds")]
    [SerializeField] private List<Sounds> sfxSounds;
    [SerializeField] private AudioClip backgroundClip;

    [Header("Sources")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        if (backgroundClip != null && backgroundSource != null)
        {
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
            backgroundSource.loop = true;
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundSource.isPlaying)
        {
            backgroundSource.Stop();
        }
    }

    public void PlaySFXSound(string soundToPlay)
    {
        var sound = sfxSounds.Find(t => t.ClipName == soundToPlay);

        if (sound != null)
            audioSource.PlayOneShot(sound.AudioClip);
    }
}
