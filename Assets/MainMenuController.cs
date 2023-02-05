using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainBox, creditBox;
    private void Awake()
    {
        mainBox.SetActive(true);
        creditBox.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Solarpunk");
    }

    public void CreditsIn()
    {
        mainBox.SetActive(false);
        creditBox.SetActive(true);
    }

    public void CreditsOut()
    {
        mainBox.SetActive(true);
        creditBox.SetActive(false);
    }

    public void EndGame()
    {
        Application.Quit();
    }




}
