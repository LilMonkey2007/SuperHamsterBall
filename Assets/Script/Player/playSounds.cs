using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playSounds : MonoBehaviour
{
    private AudioSource audioSource;
    private PlayerController player;
    [SerializeField]
    private AudioClip runSound;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip victorySound;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(player.currentState)
        {
            case PlayerController.State.NORMAL:
                audioSource.Stop();
                audioSource.clip = runSound;
                audioSource.loop = true;
                audioSource.Play();
                break;
            case PlayerController.State.DEAD :
                audioSource.PlayOneShot(deathSound);
                break;
            case PlayerController.State.VICTORY :
                audioSource.PlayOneShot(victorySound);
                break;
        }

    }
}
