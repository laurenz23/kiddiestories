using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace kiddiestories
{
    public class LevelCompleteUIHandler : MonoBehaviour
    {

        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private TMP_Text _stageText;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Image _backgroundPanel;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _levelCompeleteObject;
        [SerializeField] private SoundManager _soundManager;

        private const string _exitAnim = "exit";

        #region :: Listener
        public delegate void RetryListener();
        public event RetryListener OnRetryListener;

        public delegate void NextListener();
        public event NextListener OnNextListener;
        #endregion

        #region :: Actions
        public void OnRetryTap()
        {
            _soundManager.soundFXManager.PlayUITap("tap1");
            _animator.SetTrigger(_exitAnim);
            StartCoroutine(WaitForSecondToRetry());
        }

        public void OnHomeTap()
        {
            _soundManager.soundFXManager.PlayUITap("tap1");
            SceneManager.LoadScene("MainMenuScene");
        }

        public void OnNextTap()
        {
            _soundManager.soundFXManager.PlayUITap("tap1");
            _animator.SetTrigger(_exitAnim);
            StartCoroutine(WaitForSecondToNext());
        }
        #endregion

        #region :: Helper
        public void DisplayLevelComplete(string headerText, string stageText, int score)
        {
            _backgroundPanel.enabled = true;
            _levelCompeleteObject.SetActive(true);
            _headerText.text = headerText;
            _stageText.text = stageText;
            _scoreText.text = "Score " + score.ToString();
        }

        public void HideLevelComplete()
        {
            _backgroundPanel.enabled = false;
            _levelCompeleteObject.SetActive(false);
        }

        private IEnumerator WaitForSecondToRetry()
        {
            yield return new WaitForSeconds(1f);
            HideLevelComplete();
            OnRetryListener?.Invoke();
            StopCoroutine(WaitForSecondToRetry());
        }

        private IEnumerator WaitForSecondToNext()
        {
            yield return new WaitForSeconds(1f);
            HideLevelComplete();
            OnNextListener?.Invoke();
            StopCoroutine(WaitForSecondToNext());
        }
        #endregion

    }
}
