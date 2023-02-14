using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindow : MonoBehaviour
{
    [SerializeField] TutorialTrigger tut;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onClose();
        }
    }

    private void Awake()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
    }

    public void onClose()
    {
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setOnComplete(DestroyMe);
        tut.PlayerMovement();
    }


public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

