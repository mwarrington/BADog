using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stagemanager: MonoBehaviour, iPausable {

    private GameManager _theGameManager;
    public GameObject[] StagePrefabs;

    private float _timer = 34f;
    private bool _paused = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        DestroyOldSP(col);
        if (_timer > 10f)
        {
            AddNewStagePiece();
        }   
    }

    private void DestroyOldSP(Collider2D col)
    {
        _theGameManager.RemoveFromPausables(col.GetComponent<iPausable>());
            Destroy(col.transform.parent.gameObject);
        
    }

    private void AddNewStagePiece()
    {
        Instantiate(
            StagePrefabs[UnityEngine.Random.Range(0, StagePrefabs.Length)],
            new Vector3(18, -5, 0),
            Quaternion.identity);
    }

    void Start()
    {
        _theGameManager = GameManager.TheGameManager;
        _theGameManager.AddToPausables(this);

        if (Physics2D.gravity.y > 0f)
        {
            GameObject.Find("arrow").transform.Rotate(-180f, 0f, 0f);
        }
        else
        {
            GameObject.Find("arrow").transform.Rotate(0, 0f, 0f);
        }
    }

    void Update()
    {
        if (!_paused)
            _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            if (GameObject.Find("playerdog").transform.position.y > 5)
            {
                SceneManager.LoadScene("SkyEnd");
            }
            else if
                (GameObject.Find("playerdog").transform.position.y < -5)
            {
                SceneManager.LoadScene("GroundEnd");
            }
            else
            {
                SceneManager.LoadScene("CarEnd");
            }
        }
    }

    public void TogglePause()
    {
        _paused = !_paused; 
    }
}
