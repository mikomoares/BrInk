using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GM
{
   private static GM _instance;
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };

   public GameState gameState { get; private set; }
   public int vidas;
   public int pontos;
   public string vidasText = "";

   public delegate void ChangeStateDelegate();
   public static ChangeStateDelegate changeStateDelegate;

   public void ChangeState(GameState nextState)
    {
        if (gameState == GameState.MENU) Reset();
        gameState = nextState;
        changeStateDelegate();
    }
   public static GM GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GM();
       }

       return _instance;
   }
   private GM()
   {
       vidas = 3;

       pontos = 0;
       gameState = GameState.MENU;
   }
   private void Reset()
    {
        vidas = 3;
        DesenhaVida();
        pontos = 0;
    }
    public void DesenhaVida(){
        vidasText ="";
        for(int i = 1;i<=vidas;i++){
           vidasText += ".";
        }
    }


}