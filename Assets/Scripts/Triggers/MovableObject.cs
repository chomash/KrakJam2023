using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Vector3 startPos, endPos;
    public GameObject endRef;
    public GameObject movingPart;
    public float forthSpeed = 0.5f, backSpeed = 0.2f;

    private bool isMoving = false;
    [SerializeField] bool canBack;
    [SerializeField] bool doLoop;
    [SerializeField] bool startAlone;
    private bool goUp, goDown;
    private float fraction = 0;


    public void Start()
    {
        goUp = true;
        goDown = false;
        startPos = movingPart.transform.position;
        endPos = endRef.transform.position;
        isMoving = startAlone;
    }

    public void Update()
    {
        if (isMoving)
        {
            Debug.Log("StartMoving");
            if (goUp)
            {
                Debug.Log("GoUp");
                fraction += forthSpeed * Time.deltaTime;
                movingPart.transform.position = Vector3.Lerp(startPos, endPos, fraction);
                if (fraction > 1)
                {
                    if (canBack)
                    {
                        ToggleGo();
                        fraction = 0;
                    }
                    else isMoving = false;
                }
            }
            if (goDown)
            {
                Debug.Log("Go");
                fraction += backSpeed * Time.deltaTime;
                movingPart.transform.position = Vector3.Lerp(endPos, startPos, fraction);
                if (fraction > 1)
                {
                    if (doLoop)
                    {
                        ToggleGo();
                        fraction = 0;
                    }
                    else isMoving = false;
                }
            }
        }
    }

    private void ToggleGo()
    {
        goUp = !goUp;
        goDown = !goDown;
    }

    public void Trigger()
    {
        isMoving = true;
    }



}
