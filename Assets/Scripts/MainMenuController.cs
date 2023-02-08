using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainBox, creditBox;

    public void StartGame()
    {
        SceneManager.LoadScene("Solarpunk");
    }

    public void EndGame()
    {
        Application.Quit();
    }




}
