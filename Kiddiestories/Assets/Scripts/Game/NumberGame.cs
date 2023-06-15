using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class NumberGame : MonoBehaviour
    {

        [SerializeField] private int _currentStage;
        [SerializeField] private GameObject[] _stageObject;
        [SerializeField] private LevelCompleteUIHandler _levelCompleteUIHandler;
        [SerializeField] private FlipHandler _flipHandler;
        [SerializeField] private HealthHandler _healthHandler;

        private int _score = 0;
        private const int _stage1MaxScore = 2;
        private const int _stage2MaxScore = 3;
        private const int _stage3MaxScore = 4;
        private const int _stage4MaxScore = 5;
        private const int _stage5MaxScore = 6;

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
            DisplayStage(_currentStage);
        }

        public int GetMaxScore()
        {
            return _currentStage switch
            {
                1 => _stage1MaxScore,
                2 => _stage2MaxScore,
                3 => _stage3MaxScore,
                4 => _stage4MaxScore,
                5 => _stage5MaxScore,
                _ => 1,
            };
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

            if (_score >= GetMaxScore())
            {
                StartCoroutine(DelayDisplayLevelComplete("You win", "Stage " + _currentStage, _score));
            }
        }

        private void OnFlipWrong()
        {
            _healthHandler.LoseHealth();

            if (_healthHandler.GetCurrentHealth() <= 0)
            {
                StartCoroutine(DelayDisplayLevelComplete("Game Over", "Stage " + _currentStage, _score));
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
                flipCard.gameObject.SetActive(false);
                flipCard.gameObject.SetActive(true);
            }

            _score = 0;
            _flipHandler.Reset();
            _healthHandler.Reset();
            _levelCompleteUIHandler.HideLevelComplete();
        }

        private IEnumerator DelayDisplayLevelComplete(string header, string stage, int score)
        {
            yield return new WaitForSeconds(1f);
            _levelCompleteUIHandler.DisplayLevelComplete(header, stage, score);
        }

    }
}
