using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject Bloco;
    GameObject bloco;

    GM gm;
    void Start()
    {
       gm = GM.GetInstance();
       GM.changeStateDelegate += Construir;
       Construir();
    }
    private void Construir(){
        if (gm.gameState == GM.GameState.MENU){
            foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
            }
            for(int i = 2; i < 11; i++)
            {
                for(int j = 1; j < 6; j++){
                    Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);
                    bloco = Instantiate(Bloco, posicao, Quaternion.identity, transform);
                    if (j%2==0){
                        bloco.gameObject.GetComponent<SpriteRenderer>().color = new Color(3f, 92f, 75f, 0f);
                    }
                }

            }
        }
    }
    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GM.GameState.GAME)
        {
            gm.ChangeState(GM.GameState.ENDGAME);
        }
    }
}
