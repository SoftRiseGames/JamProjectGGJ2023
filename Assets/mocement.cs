using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mocement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    
    Vector3 mouseExens;

    // Update is called once per frame
    void Update()
    {
       
        mouseExens = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));

        Vector3 targetrotation = mouseExens - transform.position;
        float rotateZ = Mathf.Atan2(targetrotation.y, targetrotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
       

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
