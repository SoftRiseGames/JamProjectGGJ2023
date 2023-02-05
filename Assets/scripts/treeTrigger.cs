using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeTrigger : MonoBehaviour
{
    public SpriteRenderer tree;

    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.name == "character"){
            tree.color = new Color(1,1,1,0.4f);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D){
        if(collider2D.gameObject.name == "character"){
            tree.color = new Color(1,1,1,1f);
        }
    }
}
