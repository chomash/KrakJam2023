using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public void FinishGame()
    {
        SceneManager.LoadScene("_MainMenu", LoadSceneMode.Single);
    }
}
