using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAlive : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
