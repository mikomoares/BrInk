using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velocidade;
    GM gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GM.GetInstance();
        velocidade = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GM.GameState.GAME) return;

        float inputX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;  
        if (transform.position.x <= -6.52){
            transform.position = new Vector3(-6.5f, transform.position.y, 0);  
        }       
        if (transform.position.x >= 6.9){
            transform.position = new Vector3(6.8f, transform.position.y, 0);  
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GM.GameState.GAME) {
            gm.ChangeState(GM.GameState.PAUSE);
        }


    }
}
