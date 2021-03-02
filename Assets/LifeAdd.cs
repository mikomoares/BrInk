using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAdd : MonoBehaviour
{
    GM gm;
    
    private void Start() {
        gm = GM.GetInstance();
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Raquete"){
            gm.vidas ++;
            gm.DesenhaVida();
            Destroy(gameObject);
        }
    }
    private void Update() {
        this.transform.position += new Vector3(0,-1.5f,0)* Time.deltaTime;
    }
}
