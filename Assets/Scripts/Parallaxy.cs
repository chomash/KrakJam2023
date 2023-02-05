using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxy : MonoBehaviour
{
    #region Variables

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    #endregion


    void Start()
    {
        startpos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // if (temp > startpos + length) startpos += length;
        // else if (temp < startpos - length) startpos -= length;
    }
}