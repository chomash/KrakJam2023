using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : Collidable
{
    [SerializeField] GameObject TutWindow;

    public SpriteRenderer spriteRenderer;
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            TutWindow.SetActive(true);
        }
    }

   

}
