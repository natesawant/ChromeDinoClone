using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject dino;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(dino.transform.position.x, transform.position.y, -10);
    }
}
