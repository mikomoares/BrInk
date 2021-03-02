using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;

public class PanelActivate : MonoBehaviour
{
   public GM.GameState[] activeStates;
   GM gm;

   void Start()
   {
       GM.changeStateDelegate += UpdateVisibility;
       gm = GM.GetInstance();

        UpdateVisibility();
   }

   void UpdateVisibility()
   {
       if (activeStates.Contains(gm.gameState))
       {
           gameObject.SetActive(true);
       }
       else
       {
           gameObject.SetActive(false);
       }
   }
}
