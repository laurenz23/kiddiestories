using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class AlphabetGame : MonoBehaviour
    {

        [SerializeField] private int _selectedStage;
        [SerializeField] private GameObject[] _stageObject;
        [SerializeField] private LevelCompleteUIHandler _levelCompleteUIHandler;
        [SerializeField] private FlipHandler _flipHandler;
        [SerializeField] private HealthHandler _healthHandler;

        private int _score = 0;
        private int _currentStage = 0;

        private void OnEnable()
        {
            _levelCompleteUIHandler.OnRetryListener += OnRetryAction;
            _levelCompleteUIHandler.OnNextListener += OnNextAction;
            _flipHandler.OnFlipCorrectListener += OnFlipCorrect;
            _flipHandler.OnFlipWrongListener += OnFlipWrong;
        }

        private void OnDisable()
        {
            _levelCompleteUIHandler.OnRetryListener -= OnRetryAction;
            _levelCompleteUIHandler.OnNextListener -= OnNextAction;
            _flipHandler.OnFlipCorrectListener -= OnFlipCorrect;
            _flipHandler.OnFlipWrongListener -= OnFlipWrong;
        }

        private void Start()
        {
            DisplayStage(_selectedStage);
        }

        private void OnRetryAction()
        {
            Reset();
        }

        private void OnNextAction()
        {
            _currentStage++;
            Reset();
            DisplayStage(_currentStage);
        }

        private void OnFlipCorrect()
        {
            _score++;
        }

        private void OnFlipWrong()
        {
            _healthHandler.LoseHealth();

            if (_healthHandler.GetCurrentHealth() <= 0)
            {
                _levelCompleteUIHandler.DisplayLevelComplete("Game Over", "Stage " + _currentStage, _score);
            }
        }

        public void DisplayStage(int stage)
        {
            foreach (GameObject o in _stageObject)
            {
                o.SetActive(false);
            }

            _stageObject[stage - 1].SetActive(true);
        }

        public void Reset()
        {
            FlipCard[] flipCardList = _stageObject[_currentStage - 1].GetComponentsInChildren<FlipCard>();

            foreach (FlipCard flipCard in flipCardList)
            {
                flipCard.Reset();
            }

            _flipHandler.Reset();
            _healthHandler.Reset();
        }

    }
}
