using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public GameObject[] BackgroundPrefabs;
    private float _timer = 34f;

    void DestroyAdd(Collider2D col)
    {
        Destroy(col.transform.gameObject);

        if (_timer > 10f)
        {
            Instantiate(
                BackgroundPrefabs[UnityEngine.Random.Range(0, BackgroundPrefabs.Length)],
                new Vector3(19, 0, 0),
                Quaternion.identity
            );
        }
    }

    void Update()
    {
            _timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        {
            DestroyAdd(col);
        }
    }
}
