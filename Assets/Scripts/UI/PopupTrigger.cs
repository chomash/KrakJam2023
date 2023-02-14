using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupTrigger : MonoBehaviour
{
    [SerializeField] GameObject PopUp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")
        {
            PopUp.SetActive(true);

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")
        {
            PopUp.SetActive(false);


        }
    }


}
