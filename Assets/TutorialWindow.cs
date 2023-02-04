using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindow : MonoBehaviour
{
 public void onClose()
    {
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(DestroyMe);
    }


public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

