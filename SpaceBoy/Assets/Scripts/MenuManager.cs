using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject page01;
    public GameObject page02;

    public GameObject backButton;

    public GameObject tuto;


    public void OnClickPlay()
    {
        backButton.SetActive(true);
        page01.SetActive(false);
        page02.SetActive(true);
    }

    public void OnClickHowToPlay()
    {
        backButton.SetActive(true);
        page01.SetActive(false);
        tuto.SetActive(true);
    }

    public void OnClickBack()
    {
        backButton.SetActive(false);
        page01.SetActive(true);
        page02.SetActive(false);
        tuto.SetActive(false);
    }

    public void OnClickLevel(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }

}
