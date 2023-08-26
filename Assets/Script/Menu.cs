using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void onPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void onQuitButton()
    {
        // This only works if you build the game. 
        // It won't work if testing in the editor
        Application.Quit();
    }
}
