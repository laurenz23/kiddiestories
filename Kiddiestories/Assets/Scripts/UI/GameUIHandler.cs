using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace kiddiestories
{
    public class GameUIHandler : MainSubUIPanel
    {

        #region :: Actions
        public void OnAlphabetTap()
        {
            soundFXManager.PlayUITap("tap1");
            SelectedGame(GameItem.ALPHABET);
        }

        public void OnNumberTap()
        {
            soundFXManager.PlayUITap("tap1");
            SelectedGame(GameItem.NUMBER);
        }

        public void OnShapeTap()
        {
            soundFXManager.PlayUITap("tap1");
            SelectedGame(GameItem.SHAPE);
        }

        public void OnColorTap()
        {
            soundFXManager.PlayUITap("tap1");
            SelectedGame(GameItem.COLOR);
        }

        public void OnFruitTap()
        {
            soundFXManager.PlayUITap("tap1");
            SelectedGame(GameItem.FRUIT);
        }

        public void OnVegetableTap()
        {
            soundFXManager.PlayUITap("tap1");
            SelectedGame(GameItem.VEGETABLE);
        }
        #endregion

        #region :: Helper
        public void SelectedGame(GameItem gameItem)
        {
            GameManager.SetSelectedGame(gameItem);
            SceneManager.LoadScene("GameScene");
        }
        #endregion

    }
}
