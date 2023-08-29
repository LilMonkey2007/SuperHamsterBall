using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------------- Audio Source -----------------")]
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource music;

    [Header("----------------- Audio Clip -----------------")]
    public AudioClip pickup;
    public AudioClip backgroundMusic;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(float volume)
    {
        Debug.Log("In AudioManager");
        sfx.volume = volume;
        sfx.PlayOneShot(pickup);
    }
}
