using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
  GM gm;

  private void OnEnable()
  {
      gm = GM.GetInstance();
  }
 
  public void Comecar()
  {
      gm.ChangeState(GM.GameState.GAME);
  }
}
