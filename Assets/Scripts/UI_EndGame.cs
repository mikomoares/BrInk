using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
   public Text message;

   GM gm;
   private void OnEnable()
   {
       gm = GM.GetInstance();

       if(gm.vidas > 0)
       {
           message.text = "You Win";
       }
       else
       {
           message.text = "Game Over";
       }
   }

   
    public void Voltar()
    {
        gm.ChangeState(GM.GameState.MENU);
    }
}
