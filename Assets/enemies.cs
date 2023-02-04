using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{

    public Transform character;
    public Rigidbody2D rb;
    
    private bool inRange;
    private bool onCooldown;
    public float range;
    
    public GameObject enemyBullet;
    public float basedHeatlh;
    public float timeToShoot;
    public int damage;
    
    public int xpReward;
    public int hpReward;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Vector2.Distance(this.gameObject.transform.position, character.gameObject.transform.position) < range;
        
        enemyexen();
        enemyMovement();
        TryShoot();
    }

    void enemyMovement()
    {
        if(inRange == false)
            transform.position = Vector2.MoveTowards(this.gameObject.transform.position, character.gameObject.transform.position, 0.01f);
    }

    private void TryShoot(){
        if(inRange == false)
            return;

        if(onCooldown)
            return;

        Shoot();      
    }

    private void Reload(){
        onCooldown = false;
    }

    private void Shoot(){
        onCooldown = true;
        Instantiate(enemyBullet,transform.position,transform.rotation);
        Invoke("Reload",timeToShoot);
    }

    private void Hurt(GameObject bullet, float damage){
        bullet.SetActive(false);
        basedHeatlh = basedHeatlh - character.GetComponent<gunScript>().HPgunPower;
        
        if(basedHeatlh < 0)
            Death();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet"){
            Hurt(collision.gameObject,character.GetComponent<gunScript>().HPgunPower);
            character.GetComponent<Stats>().AddHP(hpReward);
        }        

        
        if(collision.gameObject.tag == "bulletXP"){
            Hurt(collision.gameObject,character.GetComponent<gunScript>().XPgunPower);
            character.GetComponent<Stats>().AddXP(xpReward);
        }

    }
    void enemyexen()
    {
        Vector3 targetrotation = character.transform.position - transform.position;
        float rotateZ = Mathf.Atan2(targetrotation.y, targetrotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
