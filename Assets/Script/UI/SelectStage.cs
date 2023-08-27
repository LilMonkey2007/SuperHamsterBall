using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject selectStage;

    public void onBackButton()
    {
        mainMenu.SetActive(true);
        selectStage.SetActive(false);
    }

    public void onTutorialButton()
    {
        SceneManager.LoadScene(1);
    }

    public void onStage1Button()
    {
        SceneManager.LoadScene(2);
    }

    public void onStage2Button()
    {
        SceneManager.LoadScene(3);
    }

    public void onStage3Button()
    {
        SceneManager.LoadScene(4);
    }

    public void onStage8Button()
    {
        SceneManager.LoadScene(5);
    }
}
