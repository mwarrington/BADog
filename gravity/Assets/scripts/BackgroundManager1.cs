using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager1 : MonoBehaviour, iPausable
{

    private GameManager _theGameManager;
    private float _timer = 34f;
    private bool _paused = false;

    public GameObject[] BackgroundPrefabs;

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

    void Start()
    {
        _theGameManager = GameManager.TheGameManager;
        _theGameManager.AddToPausables(this);

    }

    void Update()
    {
        if (!_paused)
            _timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        {
            DestroyAdd(col);
        }
    }

    public void TogglePause()
    {
        _paused = !_paused;
    }
}
