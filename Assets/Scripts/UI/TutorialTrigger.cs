using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] GameObject TutWindow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TutWindow.SetActive(true);
    }
}
