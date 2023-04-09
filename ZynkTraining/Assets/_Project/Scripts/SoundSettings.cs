using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Button volumeButton;
    public Image volumeOnImage;
    public Image volumeOffImage;

    private bool soundOn = true;

    public Slider volumeSlider;


    public static SoundSettings Instance { get; private set; }

    void Awake()
    {        
        Instance = this;
        gameObject.SetActive(false);
        AudioListener.volume = 0.5f;
        volumeSlider.value = 0.5f;
        SetVolumeButtonImage();
        Save();
    }

    void Start()
    {
        Load();
        SetVolumeButtonImage();
    }

    private void SetVolumeButtonImage()
    {
        if (soundOn)
        {
            volumeOnImage.gameObject.SetActive(true);
            volumeOffImage.gameObject.SetActive(false);
        }
        else
        {
            volumeOnImage.gameObject.SetActive(false);
            volumeOffImage.gameObject.SetActive(true);
        }
        Save();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        SetVolumeButtonImage();

        if (soundOn)
        {
            // Activați sunetul
            AudioListener.volume = volumeSlider.value;
        }
        else
        {
            // Dezactivați sunetul
            AudioListener.volume = 0f;
        }
        Save();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;

        if (volumeSlider.value == 0)
        {
            soundOn = false;
            volumeOffImage.gameObject.SetActive(true);
            volumeOnImage.gameObject.SetActive(false);
        }
        else
        {
            soundOn = true;
            volumeOffImage.gameObject.SetActive(false);
            volumeOnImage.gameObject.SetActive(true);
        }

        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Slider", 0.5f);
        
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Slider", volumeSlider.value);
    }
}
