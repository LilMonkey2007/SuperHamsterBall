using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenu;

    public static bool gameIsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameIsPaused);
        if(gameIsPaused == true)
        {
            ResumeGame();
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (gameIsPaused)
            {
                ResumeGame();
                pauseMenu.SetActive(false);
            }
            else
            {
                PauseGame();
                pauseMenu.SetActive(true);
            }
        }

    }

    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
