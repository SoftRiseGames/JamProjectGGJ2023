using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * 50;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathZone")
            this.gameObject.SetActive(false);
    }
}
