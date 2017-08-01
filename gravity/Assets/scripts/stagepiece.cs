using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagepiece : MonoBehaviour
{

    public float MovementSpeed = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * MovementSpeed, Space.World);
    }
}
