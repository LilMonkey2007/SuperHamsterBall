using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer myMixer;
    [SerializeField]
    private Slider musicSlider;

    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", volume);
    }
}
