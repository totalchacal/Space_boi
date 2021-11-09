using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public bool isWin = false;

    public string actualLevel;
    public string nextLevel;

    public Text text;

    void Update()
    {
        if (isWin)
        {
            text.text = "You win";
        }
        else
        {
            text.text = "Game over";
        }
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(actualLevel);
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickNext()
    {
        SceneManager.LoadScene(nextLevel);
    }

}
