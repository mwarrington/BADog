using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikedestroy : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name == "playerdog")
        {
            Debug.Log("they touched each other");
            Destroy(col.gameObject);
            SceneManager.LoadScene("Start");
        }
    }
}
