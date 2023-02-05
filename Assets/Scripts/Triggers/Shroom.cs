using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : Collectable
{
    public int shroomAmount;
    //dodac refke itemku, jesli beda rozne

    protected override void OnCollect()
    {
        if (!collected){
            collected = true;
            GameManager.instance.AddShroom(shroomAmount);
            Destroy(gameObject);
            //GameManager.instance.ShowText("Picked <color=#c4c4c4>TEXT HERE</color> shroom: x" +shroomAmount, 24, Color.green, GameManager.instance.playerRef.transform.position + new Vector3(0, 1f, 0), new Vector3(0, 4f, 0), 1f);
        }
    }
}
