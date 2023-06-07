using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace kiddiestories
{
    public class FlipCard : MonoBehaviour
    {

        [SerializeField] private string _text;
        [Header("Attributes")]
        [SerializeField] private Image _cardBackground;
        [SerializeField] private Animator _cardAnimator;
        [SerializeField] private TMP_Text _cardText;
        [HideInInspector] public bool isCorrect;

        private SoundManager _soundManager;
        private FlipHandler _flipHandler;
        private bool _isFlip = false;
        private const string _flipFrontAnim = "FLIP_FRONT";
        private const string _flipBackAnim = "FLIP_BACK";

        private void Start()
        {
            if (_soundManager == null)
            {
                _soundManager = FindObjectOfType<SoundManager>();
            }

            if (_flipHandler == null)
            {
                _flipHandler = FindObjectOfType<FlipHandler>();
            }

            _cardText.text = _text;
        }

        public string GetCardValue()
        {
            return _text;
        }

        public void OnTap()
        {
            if (isCorrect)
            {
                _soundManager.soundFXManager.PlayUITap("tap1");
                return;
            }

            if (_isFlip)
            {
                _soundManager.soundFXManager.PlayUITap("tap2");

                if (_flipHandler._isDisplayingCard)
                {
                    return;
                }

                if (!isCorrect)
                { 
                    FlipFront();
                }
            }
            else
            {
                _soundManager.soundFXManager.PlayUITap("tap1");

                if (_flipHandler._isDisplayingCard)
                {
                    return;
                }

                if (!isCorrect)
                {
                    FlipBack();
                }
            }

            _flipHandler.SetCard(this);
        }

        public void FlipFront()
        {
            _isFlip = false;
            _cardAnimator.SetTrigger(_flipBackAnim);
        }

        public void FlipBack()
        {
            _isFlip = true;
            _cardAnimator.SetTrigger(_flipFrontAnim);
        }

        public void Reset()
        {
            isCorrect = false;
            _isFlip = false;
        }

    }
}