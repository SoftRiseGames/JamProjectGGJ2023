using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletxp;
    [SerializeField] GameObject gunHP;
    [SerializeField] GameObject gunXP;
    public List<GameObject> poolListHealth = new List<GameObject>();
    public List<GameObject> poolListXp = new List<GameObject>();
    public static gunScript instance;
    public bool isHealth;
    public int edge;
    [SerializeField] Transform bulletPoint;

    [SerializeField] CameraNoise noiseHandler;
    [SerializeField] Text gunText;
    [SerializeField] Text bulletCount;

    
    /// ///////////////////77////////////////////
   
    public float HPgunPower;
    public float XPgunPower;

    public float ReloadGun;
    public float reloadTimer;
    public float BulletCount;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            fire();

      
        PoollObject();
        gunChange();
        activatepoolHP();
        activatepoolXP();

        if (bulletxp != null && !isHealth && ReloadGun > 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                gunXP.GetComponent<Animator>().SetBool("isXPok", false);
            }
        }


    }

    void gunChange()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            isHealth = true;
            gunText.text = "Current Gun = HP Gun";
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            isHealth = false;
            gunText.text = "Current Gun = XP Gun";
        }

        if (isHealth)
        {
          
            gunHP.gameObject.SetActive(true);
            gunXP.gameObject.SetActive(false);
           
        }
           
        else if (!isHealth)
        {
           
            gunHP.gameObject.SetActive(false);
            gunXP.gameObject.SetActive(true);
            
        }
           
    }

    void PoollObject()
    {
        for( ;  edge<20; edge++)
        {
           GameObject obj =  Instantiate(bullet);
            obj.SetActive(false);
            poolListHealth.Add(obj);

            GameObject objxp = Instantiate(bulletxp);
            objxp.SetActive(false);
            poolListXp.Add(objxp);

        }
    }
    
    public GameObject activatepoolHP()
    {
        for(int i = 0; i < poolListHealth.Count; i++)
        {
            if (!poolListHealth[i].activeInHierarchy)
            {
                return poolListHealth[i];
            }
        }
        return null;
    }
    public GameObject activatepoolXP()
    {
        for (int i = 0; i < poolListXp.Count; i++)
        {
            if (!poolListXp[i].activeInHierarchy)
            {
                return poolListXp[i];
            }
        }
        return null;
    }


    void fire()
    {
        GameObject bulletactivate = instance.activatepoolHP();
        GameObject bulletActivateXP = instance.activatepoolXP();

        if (bullet != null && isHealth && ReloadGun>0)
        {
            StartCoroutine(reload(reloadTimer));
            bulletactivate.gameObject.transform.position = bulletPoint.gameObject.transform.position;
            bulletactivate.gameObject.transform.rotation = this.gameObject.transform.rotation;
            bulletactivate.SetActive(true);
            noiseHandler.AddNoise(10);
            bulletCount.text = "Bullet Count: " + ReloadGun;  
        }
        else if(bulletxp != null && !isHealth && ReloadGun>0)
        {       
            StartCoroutine(reload(reloadTimer));
            bulletActivateXP.gameObject.transform.position = bulletPoint.gameObject.transform.position;
            bulletActivateXP.gameObject.transform.rotation = this.gameObject.transform.rotation;
            bulletActivateXP.SetActive(true);
            gunXP.GetComponent<Animator>().SetBool("isXPok", true);
            noiseHandler.AddNoise(10);
            bulletCount.text = "Bullet Count: " + ReloadGun;  
        }

      
    }
     IEnumerator reload(float timer)
    {
        ReloadGun = ReloadGun - 1;
        if(ReloadGun<= 0)
        {
            yield return new WaitForSeconds(timer);
            ReloadGun = BulletCount;
        }
        bulletCount.text = "Bullet Count: " + ReloadGun; 
    }
  

      

}
