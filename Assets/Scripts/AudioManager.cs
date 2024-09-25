using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Instances")]
    public static AudioManager instance;

    [Header("Components")]
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;

    [Header("References")]
    [SerializeField] AudioClip normalDropDownClip;
    [SerializeField] AudioClip perfectDropdownClip;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }

    void Awake() 
    {
        SingletonPattern();
    }

    void Start()
    {
        Application.targetFrameRate = 120;
        MusicVolumeOnStart();
        SFXVolumeOnStart();
    }

    void MusicVolumeOnStart()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicSlider.value = 1f;
        }
        musicSource.volume = musicSlider.value;

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;


        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    void SFXVolumeOnStart()
    {
        if(PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            sfxSlider.value = 1f;
        }
        sfxSource.volume = sfxSlider.value;

        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;


        PlayerPrefs.SetFloat("SFXVolume", volume);
    }


    void SingletonPattern()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayNormalDropDownClip()
    {
        PlayClip(normalDropDownClip);
    }

    public void PlayPerfectDropDownClip()
    {
        PlayClip(perfectDropdownClip);
    }

    void PlayClip(AudioClip clip)
    {
        if(clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
