using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{

    public enum GameItem
    { 
        ALPHABET,
        NUMBER,
        SHAPE,
        COLOR,
        FRUIT,
        VEGETABLE
    }

    public class GameManager
    {

        #region :: Variable
        private static GameItem selectedGame;
        #endregion

        #region :: Properties
        public static void SetSelectedGame(GameItem gameItem)
        {
            selectedGame = gameItem;
        }

        public static GameItem GetSelectedGame()
        {
            return selectedGame;
        }
        #endregion

    }
}
