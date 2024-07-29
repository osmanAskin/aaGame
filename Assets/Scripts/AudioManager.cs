using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip clickSound;
    public AudioClip failSound;
    public AudioClip backGroundMusic;
    public AudioClip winSound;

    private static AudioManager instance;

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
        audioSource.clip = backGroundMusic;
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SaveAudioState()
    {
        PlayerPrefs.SetFloat("MusicTime", audioSource.time);
    }

    public void LoadAudioState()
    {
        if (PlayerPrefs.HasKey("MusicTime"))
        {
            audioSource.time = PlayerPrefs.GetFloat("MusicTime");
        }
    }
}
