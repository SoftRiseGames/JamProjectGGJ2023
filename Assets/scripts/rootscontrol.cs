using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootscontrol : MonoBehaviour
{
    public TreeHealth treecontrol;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            treecontrol.health = treecontrol.health - 10;
            Destroy(collision.gameObject);
        }
           
       
    }
}
