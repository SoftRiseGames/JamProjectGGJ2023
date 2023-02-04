using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public gunScript gunstats;
    public Stats stats;
    public enemies rewards;

    public GameObject upgradeScreen;
    private void Start()
    {
        rewards = GameObject.Find("Enemy").GetComponent<enemies>();
    }
    public void xpgunupgrade()
    {
        rewards.xpReward = rewards.xpReward + 1;
        Time.timeScale = 1;
        upgradeScreen.SetActive(false);
    }
    public void hpgunupgrade()
    {
        rewards.hpReward = rewards.hpReward + 1;
        Time.timeScale = 1;
        upgradeScreen.SetActive(false);

    }
    public void hpupgrade()
    {
        stats.maxHP = stats.maxHP + 10;
        Time.timeScale = 1;
        upgradeScreen.SetActive(false);
    }
}
