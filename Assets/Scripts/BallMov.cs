using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMov : MonoBehaviour
{
        [Range(1, 15)]
        public float velocidade = 5.0f;

        private Vector3 direcao;
        private bool started;
        GM gm;
        public Text vidaText;
        void Start()
        {
                float dirX = Random.Range(-5.0f, 5.0f);
                float dirY = Random.Range(1.0f, 5.0f);

                direcao = new Vector3(dirX, dirY).normalized;

                gm = GM.GetInstance();
        }

    // Update is called once per frame


        void Update()
        {    
            if (gm.gameState != GM.GameState.GAME) return;
            if (started){
                transform.position += direcao * Time.deltaTime * velocidade;
            }

            Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

            if( posicaoViewport.x < 0 || posicaoViewport.x > 1 )
            {
                    direcao = new Vector3(-direcao.x, direcao.y);
            }
            if( posicaoViewport.y > 1 )
            {
                    direcao = new Vector3(direcao.x, -direcao.y);
            }
            if(posicaoViewport.y < 0)
            {
                Reset();
            }
            if (!started && Input.anyKeyDown){
                    started = true;
            }


        }

        private void Reset()
        {

                Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        
                float dirX = Random.Range(-5.0f, 5.0f);
                float dirY = Random.Range(2.0f, 5.0f);

                direcao = new Vector3(dirX, dirY).normalized;
                gm.vidas--;
                
                gm.DesenhaVida();
                if(gm.vidas <= 0 && gm.gameState == GM.GameState.GAME)
                {
                    gm.ChangeState(GM.GameState.ENDGAME);
                }  
                started = false;
        }
        

        private void OnTriggerEnter2D(Collider2D col)
        {
                if(col.gameObject.CompareTag("Player"))
                {
                        float dx = transform.position.x - col.transform.position.x;
                        float dirX = dx*5f;
                        float dirY = Random.Range(1.0f, 5.0f);

                        direcao = new Vector3(dirX, dirY).normalized;
                }
                else if(col.gameObject.CompareTag("Parede")){
                        direcao = new Vector3(-direcao.x, direcao.y);
                        if (col.name == "Lateral"){
                                col.transform.parent.gameObject.GetComponent<Brick>().Explode();
                        }
                }
                
                else if(col.gameObject.CompareTag("Teto")){
                        direcao = new Vector3(direcao.x, -direcao.y);
                }



                else if(col.gameObject.CompareTag("Brick"))
                {
                        if (col.transform.position.y - (col.transform.localScale.y/2) >= this.transform.position.y ){
                                direcao = new Vector3(direcao.x, -direcao.y);
                                gm.pontos++;
                        }
                }
        }
}
