using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    GameObject dino;
    public TextMeshProUGUI distanceMeter;

    // Start is called before the first frame update
    void Start()
    {
        dino = GameObject.Find("Dinosaur");
    }

    // Update is called once per frame
    void Update()
    {
        int distance = (int)(dino.transform.position.magnitude * 5);
        distanceMeter.SetText("Distance: " + distance.ToString("00000"));
    }
}
