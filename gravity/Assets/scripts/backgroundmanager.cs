using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public GameObject[] BackgroundPrefabs;

    void DestroyAdd(Collider2D col)
    {
        Destroy(col.transform.gameObject);

        Instantiate(
            BackgroundPrefabs[UnityEngine.Random.Range(0, BackgroundPrefabs.Length)],
            new Vector3(19, 0, 0),
            Quaternion.identity
        );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        {
            DestroyAdd(col);
        }
    }
}
