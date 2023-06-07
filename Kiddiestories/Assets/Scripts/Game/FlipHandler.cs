using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class FlipHandler : MonoBehaviour
    {
        [HideInInspector] public bool _isDisplayingCard;
        
        private FlipCard _firstCard;
        private FlipCard _secondCard;

        public delegate void FlipCorrectListener();
        public event FlipCorrectListener OnFlipCorrectListener;

        public delegate void FlipWrongListener();
        public event FlipWrongListener OnFlipWrongListener;

        public void SetCard(FlipCard card)
        {
            if (_firstCard == null)
            {
                _firstCard = card;
                return;
            }
            else
            {
                if (_firstCard == card)
                {
                    _firstCard = null;
                    return;
                }

                _secondCard = card;
            }

            if (_firstCard != null && _secondCard != null)
            {
                ShowCard();
            }
        }

        public void ShowCard()
        {
            if (_firstCard == null && _secondCard == null)
            {
                return;
            }

            string firstValue = _firstCard.GetCardValue();
            string secondValue = _secondCard.GetCardValue();

            if (firstValue.Equals(secondValue))
            {
                _firstCard.isCorrect = true;
                _secondCard.isCorrect = true;

                _firstCard = null;
                _secondCard = null;

                OnFlipCorrectListener?.Invoke();
            }
            else
            {
                if (!_isDisplayingCard)
                {
                    StartCoroutine(DisplayingCard());
                }
            }
        }

        private IEnumerator DisplayingCard()
        {
            _isDisplayingCard = true;

            yield return new WaitForSeconds(1f); 

            _isDisplayingCard = false;
            _firstCard.FlipFront();
            _secondCard.FlipFront();
            _firstCard = null;
            _secondCard = null;

            OnFlipWrongListener?.Invoke();

            StopCoroutine(DisplayingCard());
        }

        public void Reset()
        {
            _isDisplayingCard = false;
            _firstCard = null;
            _secondCard = null;
        }

    }
}
