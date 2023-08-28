using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer myMixer;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField] 
    private AudioSource sfxAudioSource;

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject selectStage;
    [SerializeField]
    private GameObject settings;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            loadVolume();
        }
        else
        {
            setMusicVolume();
            setSFXVolume();
        }
    }

    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void setSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void playSFX()
    {
        sfxAudioSource.volume = sfxSlider.value;
        sfxAudioSource.Play();
    }

    private void loadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        setMusicVolume();
        setSFXVolume();
    }

    public void onBackButton()
    {
        mainMenu.SetActive(true);
        selectStage.SetActive(false);
        settings.SetActive(false);
    }

}
