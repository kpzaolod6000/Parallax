using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject tileMap;
    private float previouStep = 25.0f;
    private float previousPosition;
    //public GameObject[] floorTiles;
    private float zCam = -10.0f;
    private float yPos = 2.4f;

    //private Vector3 positionSet = new Vector3(2,-2,0);

    // Start is called before the first frame update{

    //private void Awake()
    //{
    //    Instantiate(floorTiles[0], positionSet, Quaternion.identity);
    //}

    void Start()
    {
        previousPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (transform.position.x  > previouStep + previousPosition)
        {
            tileMap.transform.position = new Vector3(target.transform.position.x, 0, 0);
            previousPosition = transform.position.x;
        }
        else if(transform.position.x  < previousPosition - previouStep)
        {
            tileMap.transform.position = new Vector3(target.transform.position.x, 0, 0);
            previousPosition = transform.position.x;
        }

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + yPos, target.transform.position.z + zCam);
        
    }
}
