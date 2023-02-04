using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : Collectable
{
    public int shroomAmount;
    //dodac refke itemku, jesli beda rozne

    protected override void OnCollect()
    {
        if(!collected){
            collected = true;
            GameManager.instance.AddShroom(shroomAmount);
            Destroy(gameObject);
        }
    }
}
