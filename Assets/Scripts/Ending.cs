using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
    }
}
