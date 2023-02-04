using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementSystem : MonoBehaviour
{
    public float range;
    private bool inRange;
    public Transform character;
    void Start()
    {
        character = GameObject.Find("character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Vector2.Distance(this.gameObject.transform.position, character.gameObject.transform.position) < range;
        enemyexen();
        enemyMovement();
    }
    void enemyexen()
    {
        Vector3 targetrotation = character.transform.position - transform.position;
        float rotateZ = Mathf.Atan2(targetrotation.y, targetrotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }
    void enemyMovement()
    {
        if (inRange == false)
            transform.position = Vector2.MoveTowards(this.gameObject.transform.position, character.gameObject.transform.position, 0.01f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            Debug.Log("cakisik");
        }
    }
}
