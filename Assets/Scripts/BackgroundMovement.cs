using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocityMovement;
    private Vector2 offset;
    private Material material;

    // Start is called before the first frame update
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = velocityMovement * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
