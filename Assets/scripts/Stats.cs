using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int level;
    public int nextLevel;
    public float multiplier;
    public GameObject levelScreen;
    public int maxHP;
    public int xp;
    public int hp;


    public void AddHP(int amount){
        hp = Mathf.Clamp(hp + amount,0,maxHP);
    }

    public void AddXP(int amount){
        xp += amount;
        if(xp >= nextLevel)
            LevelUp();
    }

    public void LevelUp(){
        xp -= nextLevel;
        level++;
        nextLevel = (int)(nextLevel * multiplier);
        levelScreen.SetActive(true);
        Time.timeScale = 0;
        if (xp > nextLevel)
        {
            LevelUp();
        }
            
    }

    private void Hurt(enemies enemy){
        hp -= enemy.damage;  

        if(hp <= 0)
            Death();
        
    }

    private void Hurt(EnemyBulletDamage enemy){
        hp -= enemy.damage; 

        if(hp <= 0)
            Death();
    }

    private void Death(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        
        if(collider2D.gameObject.CompareTag("enemyBullet")){
            Hurt(collider2D.gameObject.GetComponent<EnemyBulletDamage>());
            Destroy(collider2D.gameObject);
        }

        if(collider2D.gameObject.CompareTag("Enemy"))
            Hurt(collider2D.gameObject.GetComponent<enemies>());
    }
}
