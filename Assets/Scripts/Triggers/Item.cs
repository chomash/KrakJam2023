using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collectable
{
    public int amoutOfMe;
    //dodac refke itemku, jesli beda rozne

    protected override void OnCollect()
    {
        if(!collected){
            Debug.Log("Player collected " + gameObject.name + " in an amout of: " + amoutOfMe);
            collected = true;
            //tutaj skrypt dodawania itemku
            Destroy(gameObject);
        }
    }
}
