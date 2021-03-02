using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Vidas : MonoBehaviour
{
    // Start is called before the first frame update
   Text textComp;
   GM gm;
   void Start()
   {
       textComp = GetComponent<Text>();
       gm = GM.GetInstance();
   }
   
   void Update()
   {
       textComp.text = $"{gm.vidasText}";
   }
}
