using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{
    public int shroomAmount;
    //dodac refke itemku, jesli beda rozne
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddShroom(shroomAmount);
            Debug.Log("Shroom+");
            Destroy(gameObject);
        }
    }
}
