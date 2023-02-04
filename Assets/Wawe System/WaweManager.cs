using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweManager : MonoBehaviour
{
    public float offset;

    public GameObject Enemy;
    public List<Vector2> spawnPositions;
    public List<GameObject> enemies;

    public float hordeDifficulty; //Düşman sayısı
    public float statDifficulty;  //Stat Bonusları
    
    public float maxHordeDifficulty; //Max düşman
    public float hordeDifficultyMultiplier;
    public float statDifficultyMultiplier;

    public void NextWawe(){
        hordeDifficulty = Mathf.Clamp(hordeDifficulty * hordeDifficultyMultiplier,0,maxHordeDifficulty);
        statDifficulty *= statDifficultyMultiplier;
        SummonEnemies();
    }

    public void SummonEnemies(){
        for (int i = 0; i < hordeDifficulty; i++)
        {
            Spawn();
        }
    }

    private void Spawn(){
        Vector2 GetSpawnPos(){
            Vector2 baseVector = spawnPositions[Random.Range(0,spawnPositions.Count)];
            float rX = Random.Range(-offset,offset);
            float rY = Random.Range(-offset,offset);

            baseVector += new Vector2(rX,rY);
            return baseVector;
        }

        GameObject newEnemy = Instantiate(Enemy,GetSpawnPos(),Quaternion.identity);
        enemies enemyData = newEnemy.GetComponent<enemies>();
        enemyData.basedHeatlh *= statDifficultyMultiplier;
        enemyData.damage = (int)(enemyData.damage * statDifficultyMultiplier);
        enemies.Add(newEnemy);
    }

    private void CheckCount(){
        if(enemies.Count < 1)
            NextWawe();
    }

    private void Update(){
        CheckCount();
    }
}

