using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageContainer : MonoBehaviour
{
    public Image xpBar,hpBar;
    public Text textHP,textXP;
    public Stats stats;

    public float HPpercentage,XPpercentage;

    public void UpdateImage(){
        HPpercentage = stats.hp / (float)stats.maxHP;
        XPpercentage = stats.xp / (float)stats.nextLevel;

        hpBar.rectTransform.localScale = new Vector3(HPpercentage,1,1);
        xpBar.rectTransform.localScale = new Vector3(XPpercentage,1,1);

        textHP.text = stats.hp + " / " + stats.maxHP;
        textXP.text = stats.xp + " / " + stats.nextLevel;
    }

    private void Update(){
        UpdateImage();
    }
}
