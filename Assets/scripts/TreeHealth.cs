using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeHealth : MonoBehaviour
{
    public float health;
    void Start()
    {
        health = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(health);
       
    }
}
