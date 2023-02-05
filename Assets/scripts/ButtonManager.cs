using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public gunScript gunstats;
    public WaweManager waweManager;

    public Stats stats;
    public enemies rewards;

    public GameObject upgradeScreen;
    private void Start()
    {
        rewards = GameObject.Find("Enemy").GetComponent<enemies>();
    }

    private IEnumerator Continue(){
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
    }
    
    public void xpgunupgrade()
    {
        rewards.xpReward = rewards.xpReward + 1;

        foreach (GameObject item in waweManager.enemies)
        {
            item.GetComponent<enemies>().xpReward += 1;
        }
        StartCoroutine(Continue());
        upgradeScreen.SetActive(false);
        
    }
    public void hpgunupgrade()
    {
        rewards.hpReward = rewards.hpReward + 1;
        
        foreach (GameObject item in waweManager.enemies)
        {
            item.GetComponent<enemies>().hpReward += 1;
        }

        StartCoroutine(Continue());
        upgradeScreen.SetActive(false);

    }
    public void hpupgrade()
    {
        stats.maxHP = stats.maxHP + 10;
        StartCoroutine(Continue());
        upgradeScreen.SetActive(false);
    }
}
