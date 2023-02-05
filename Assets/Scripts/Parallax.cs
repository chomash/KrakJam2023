using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    #region Variables

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    #endregion

    [SerializeField] float offSet = 3f;
    void Start()
    {
        startpos = transform.position.y;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist + offSet,  transform.position.z);

        // if (temp > startpos + length) startpos += length;
        // else if (temp < startpos - length) startpos -= length;
    }
}