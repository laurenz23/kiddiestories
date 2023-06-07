using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace kiddiestories
{
    public class GameHandler : MonoBehaviour
    {

        #region :: Variables
        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private GameObject _alphabetPanel;
        [SerializeField] private GameObject _numberPanel;
        [SerializeField] private GameObject _shapePanel;
        [SerializeField] private GameObject _colorPanel;
        [SerializeField] private GameObject _fruitPanel;
        [SerializeField] private GameObject _vegetablePanel;

        private SoundFXManager _soundFXManager;
        private GameItem _selectedGame;
        #endregion

        #region :: Life Cycle
        private void Start()
        {
            _soundFXManager = _soundManager.soundFXManager;
            _selectedGame = GameManager.GetSelectedGame();

            DisplayGame();
        }
        #endregion

        #region :: Action
        public void OnBackTap()
        {
            _soundFXManager.PlayUITap("tap2");
            SceneManager.LoadScene("MainMenuScene");
        }
        #endregion

        #region ::
        private void DisplayGame()
        {
            _alphabetPanel.SetActive(false);
            _colorPanel.SetActive(false);
            _fruitPanel.SetActive(false);
            _numberPanel.SetActive(false);
            _shapePanel.SetActive(false);
            _vegetablePanel.SetActive(false);

            if (_selectedGame == GameItem.ALPHABET)
            {
                _headerText.SetText("Alphabet");
                _alphabetPanel.SetActive(true);
            }
            else if (_selectedGame == GameItem.COLOR)
            {
                _headerText.SetText("Color");
                _colorPanel.SetActive(true);
            }
            else if (_selectedGame == GameItem.FRUIT)
            {
                _headerText.SetText("Fruit");
                _fruitPanel.SetActive(true);
            }
            else if (_selectedGame == GameItem.NUMBER)
            {
                _headerText.SetText("Number");
                _numberPanel.SetActive(true);
            }
            else if (_selectedGame == GameItem.SHAPE)
            {
                _headerText.SetText("Shape");
                _shapePanel.SetActive(true);
            }
            else if (_selectedGame == GameItem.VEGETABLE)
            {
                _headerText.SetText("Vegetable");
                _vegetablePanel.SetActive(true);
            }
        }
        #endregion

    }
}
