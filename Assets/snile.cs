using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snile : MonoBehaviour
{

    [SerializeField] GameObject PopUp;
    [SerializeField] GameObject PatPat;
    bool canInteract = false;
    // Start is called before the first frame update


    private void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Debug.Log("Slimak");
            PopUp.SetActive(false);
            Destroy(PopUp);
            PatPat.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;


        }
    }
}
