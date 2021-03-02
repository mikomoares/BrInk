using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
  GM gm;

  private void OnEnable()
  {
      gm = GM.GetInstance();
  }
 
  public void Retornar()
  {
      gm.ChangeState(GM.GameState.GAME);
  }

  public void Inicio()
  {
      gm.ChangeState(GM.GameState.MENU);
  }
}
