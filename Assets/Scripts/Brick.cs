using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Brick : MonoBehaviour
{
    public GameObject particlesb;
    public GameObject particlesg;
    public GameObject particlesy;
    private GameObject cam;
    public AudioClip clip;
    public GameObject life;
    GM gm;


    private void Start() {
        cam = GameObject.Find("Main Camera");
        gm = GM.GetInstance();

        
    }
    public void Explode(){
        float cai = Random.Range(0,15);
        Debug.Log(cai);
        if (cai >13 && gm.vidas <= 5){
            Instantiate(life, this.transform.position, Quaternion.identity);
        }
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Destroy(gameObject);
        cam.GetComponent<RipplePostProcessor>().RippleActivate();
        CameraShaker.Instance.ShakeOnce(.4f,4,.1f,1);
        Instantiate(particlesb, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Instantiate(particlesg, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        Instantiate(particlesy, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name =="Bola"){
            Explode();
        }
         
    }
}
