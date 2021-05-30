using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] groundObjects;
    public GameObject[] easyObstacles;
    public GameObject[] mediumObstacles;
    public GameObject[] hardObstacles;

    public float distanceBetweenObstacles, mediumMarker, hardMarker;
    GameObject dino;
    int currentObstacle;

    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        dino = GameObject.Find("Dinosaur");
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
        GenObstacles();
    }

    void MoveGround()
    {
        for (int i = 0; i < groundObjects.Length; i++)
        {
            Vector2 groundDistanceVector = groundObjects[i].transform.position - dino.transform.position;
            if (groundDistanceVector.magnitude >= maxDistance)
            {
                groundObjects[i].transform.position += Vector3.right * 22f;
            }
        }
    }

    void GenObstacles()
    {
        int distance = (int)(dino.transform.position.magnitude * 5);
        if (dino.transform.position.x + 10f >= currentObstacle * distanceBetweenObstacles)
        {
            if (distance <= mediumMarker)
            {
                int rand = Random.Range(0, easyObstacles.Length);
                Transform newTranform = transform;
                newTranform.position = new Vector2(currentObstacle * distanceBetweenObstacles, 0);
                GameObject newObs = Instantiate(easyObstacles[rand], newTranform);
                newObs.transform.parent = null;
                Destroy(newObs, 100);
                currentObstacle += 1;
            }
            if (distance <= hardMarker)
            {
                int rand = Random.Range(0, mediumObstacles.Length);
                Transform newTranform = transform;
                newTranform.position = new Vector2(currentObstacle * distanceBetweenObstacles, 0);
                GameObject newObs = Instantiate(mediumObstacles[rand], newTranform);
                newObs.transform.parent = null;
                Destroy(newObs, 100);
                currentObstacle += 1;
            }

            else
            {
                int rand = Random.Range(0, hardObstacles.Length);
                Transform newTranform = transform;
                newTranform.position = new Vector2(currentObstacle * distanceBetweenObstacles, 0);
                GameObject newObs = Instantiate(hardObstacles[rand], newTranform);
                newObs.transform.parent = null;
                Destroy(newObs, 10);
                currentObstacle += 1;
            }
        }
    }
}
