using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject selectStage;

    //If player clicks on play game button, it will start from tutorial stage
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

    public void onSelectStageButton()
    {
        mainMenu.SetActive(false);
        selectStage.SetActive(true);
    }
}
