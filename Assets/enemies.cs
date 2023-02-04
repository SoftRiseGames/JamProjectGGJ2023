using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    public enemies instance;
    public Transform character;
    public Rigidbody2D rb;
    float Distance;

    public float basedHEatlh;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector2.Distance(this.gameObject.transform.position, character.gameObject.transform.position);
        enemyexen();
        enemyMovement();
        Death();
    }

    void enemyMovement()
    {
        if(Distance>5)
            transform.position = Vector2.MoveTowards(this.gameObject.transform.position, character.gameObject.transform.position, 0.01f);


        Debug.Log("b");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            //partikül
            //ölüm 
            collision.gameObject.SetActive(false);
            basedHEatlh = basedHEatlh - character.GetComponent<gunScript>().HPgunPower;
        }
        else if(collision.gameObject.tag == "bulletXP")
        {
            //partikül
            //destroy
            collision.gameObject.SetActive(false);
            basedHEatlh = basedHEatlh - character.GetComponent<gunScript>().XPgunPower;

        }
    }
    void enemyexen()
    {
        Vector3 targetrotation = GameObject.Find("character").transform.position - transform.position;
        float rotateZ = Mathf.Atan2(targetrotation.y, targetrotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    void Death()
    {
        if (basedHEatlh <= 0)
            Destroy(this.gameObject);
    }
}
