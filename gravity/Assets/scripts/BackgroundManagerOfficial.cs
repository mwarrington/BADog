using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManagerOfficial : MonoBehaviour {

    public float MovementSpeed = 3;
    public GameObject[] BackgroundPrefabs;

    void DestroyAdd()
    {
        Destroy(this.transform.gameObject);

        Instantiate(
            BackgroundPrefabs[UnityEngine.Random.Range(0, BackgroundPrefabs.Length)],
            new Vector3(19, 0, 0),
            Quaternion.identity
        );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "backgrounddeletemarker")
            DestroyAdd();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * MovementSpeed, Space.World);
    }
}
