﻿/**
 * This component handles player score and loading\reloading scenes depending if the player loses or wins a stage.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController player;
    private Coroutine victoryCoroutine;

    private string currentScene;

    [SerializeField]
    private string nextScene;

    public Camera mainCam;
    public Camera victoryCam;

    public Transform deathHeight;

    public int playerScore;

    public float timer;

    [SerializeField]
    private FloatSO ScoreSO, TotalSO;

    private float previousScore;
    private float stageScore;
    private int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();  // Find player
        currentScene = SceneManager.GetActiveScene().name; // Get active scene name
        previousScore = ScoreSO.Value;
        stageScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.currentState)
        {
            case PlayerController.State.NORMAL:
                timer -= Time.deltaTime;    // Decrement timer

                // Player falls off stage or timer runs out
                if (player.transform.position.y < deathHeight.position.y || timer < 0.0f)
                {
                    player.currentState = PlayerController.State.DEAD;  // Set player's state to DEAD
                    ScoreSO.Value = previousScore;
                    stageScore = 0;
                    StartCoroutine(FallingProcedure());                 // Start falling procedure
                }
                break;
            case PlayerController.State.VICTORY:
                if (victoryCoroutine == null)
                {
                    Debug.Log("ScoreSO inside update:" + ScoreSO.Value);
                    victoryCoroutine = StartCoroutine(Victory());
                }
                           // Start victory procedure
                break;
        }
    }

    /// <summary>
    /// Waits a few seconds before reloading current scene.
    /// </summary>
    /// <returns></returns>
    IEnumerator FallingProcedure()
    {
        // Wait 1.5 secs then re load the scene
        yield return new WaitForSeconds(1.5f);
        LoadScene(currentScene);
    }

    /// <summary>
    /// Enables\Disables the main and victory cameras, then waits a few second before loading the next scene.
    /// </summary>
    /// <returns></returns>
    IEnumerator Victory()
    {
        mainCam.enabled = false;    // Disable main camera
        victoryCam.enabled = true;  // Enable victory camera
        int pickups = (int)(ScoreSO.Value - previousScore);
        multiplier = (pickups < 1) ? 1 : pickups;

        if (timer > 45.0f)
            multiplier *= 2;
        else if (timer > 30.0f)
            multiplier = (int)(multiplier*1.5);
        
        stageScore = multiplier * timer;
        TotalSO.Value += (int)stageScore;

        // Wait 2.0 secs then load the next scene
        yield return new WaitForSeconds(2.0f);
        LoadScene(nextScene);
    }

    /// <summary>
    /// Loads scene using the scene name passed
    /// </summary>
    /// <param name="sceneName">The name of the scene to load</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
