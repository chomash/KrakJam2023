using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingOn : Collidable
{
    public SpriteRenderer spriteRenderer;
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
        }
    }

 
        
 

}
