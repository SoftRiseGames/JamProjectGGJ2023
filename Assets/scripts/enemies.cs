using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemies : MonoBehaviour
{
    public WaweManager waweManager;
    public Transform character;
    public Rigidbody2D rb;
    public ParticleSystem particle;
    private bool inRange;
    private bool onCooldown;
    public float range;
    public GameObject[] roots;
    public GameObject enemyBullet;
    public float basedHeatlh;
    public float timeToShoot;
    public int damage;
    public enemies instance;
    public int xpReward;
    public int hpReward;

    public float maxrange;
    public float minrange;
    float randomize;
    int randomArray;
    GameObject target;

    void Start()
    {
        waweManager = GameObject.Find("Wawe Manager").GetComponent<WaweManager>();
        character = GameObject.Find("character").transform;
        rb = GetComponent<Rigidbody2D>();
        range = Random.Range(minrange, maxrange);
        randomize = Random.Range(0, 100);
        if (instance == null)
            instance = this;
        randomArray = Random.Range(0, roots.Length);

        if (randomize > 100)
            target = character.gameObject;
        else
            target = roots[randomArray];
    }

    // Update is called once per frame
    void Update()
    {
        
        inRange = Vector2.Distance(this.gameObject.transform.position, target.gameObject.transform.position) < range;
        enemyexen();
        enemyMovement();
        TryShoot();
    }

    void enemyMovement()
    {
        if(inRange == false && Time.timeScale == 1)
            transform.position = Vector2.MoveTowards(this.gameObject.transform.position, target.gameObject.transform.position,0.02f);
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
        basedHeatlh = basedHeatlh - damage;

        if (basedHeatlh <= 0)
            Death();
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet"){
          
            Hurt(collision.gameObject,character.GetComponent<gunScript>().HPgunPower);
            StartCoroutine(colortimer());
            character.GetComponent<Stats>().AddHP(hpReward);
        }        

        
        if(collision.gameObject.tag == "bulletXP"){
            Hurt(collision.gameObject,character.GetComponent<gunScript>().XPgunPower);
            StartCoroutine(colortimer());
            character.GetComponent<Stats>().AddXP(xpReward);
        }

    }
    void enemyexen()
    {
        Vector3 targetrotation = target.transform.position - transform.position;
        float rotateZ = Mathf.Atan2(targetrotation.y, targetrotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    void Death()
    {

        Instantiate(particle, instance.gameObject.transform.position, Quaternion.identity);
        waweManager.enemies.Remove(gameObject);
        Destroy(this.gameObject);
    }
   
    IEnumerator colortimer()
    {
        this.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        this.gameObject.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
