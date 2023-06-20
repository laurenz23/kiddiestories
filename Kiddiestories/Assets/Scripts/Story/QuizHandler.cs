using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace kiddiestories
{
    public class QuizHandler : MonoBehaviour
    {

        public GameObject promptPanel;
        public GameObject quizAnsPanel;
        [SerializeField] private TMP_Text _quizText;
        [SerializeField] private TMP_Text _ans1Text;
        [SerializeField] private TMP_Text _ans2Text;
        [SerializeField] private TMP_Text _ans3Text;
        [SerializeField] private TMP_Text _ans4Text;
        [SerializeField] private Image[] _imageArrayList;
        [SerializeField] private QuizItemData[] _quiz1Array;
        [SerializeField] private QuizItemData[] _quiz2Array;
        [SerializeField] private QuizItemData[] _quiz3Array;
        [SerializeField] private SoundFXManager _soundFXManager;

        private Story _selectedStory = Story.STORY1;
        private QuizItemData[] _selectedQuiz;
        private bool _isAlreadyAnswer;
        private int _quizNumber = 0;
        private string _correctAns = "";

        private void Start()
        {
            _selectedStory = StoryManager.GetSelectedStory();

            if (_selectedStory == Story.STORY1)
            {
                _selectedQuiz = _quiz1Array;
            }
            else if (_selectedStory == Story.STORY2)
            {
                _selectedQuiz = _quiz2Array;
            }
            else if (_selectedStory == Story.STORY3)
            {
                _selectedQuiz = _quiz3Array;
            }

            DisplayQuiz();
        }

        #region :: Actions
        public void OnChoice1()
        {
            if (_isAlreadyAnswer)
                return;

            _soundFXManager.PlayUITap("tap1");
            _isAlreadyAnswer = true;

            if (!IsHaveQuestions())
            {
                SceneManager.LoadScene("MainMenuScene");
                return;
            }

            _quizNumber++;
            CheckAnswer(_ans1Text.text, _imageArrayList[0]);
            StartCoroutine(WaitForSecondToDisplayNextQuestion());
        }

        public void OnChoice2()
        {
            if (_isAlreadyAnswer)
                return;

            _soundFXManager.PlayUITap("tap1");
            _isAlreadyAnswer = true;

            if (!IsHaveQuestions())
            {
                SceneManager.LoadScene("MainMenuScene");
                return;
            }

            _quizNumber++;
            CheckAnswer(_ans2Text.text, _imageArrayList[1]);
            StartCoroutine(WaitForSecondToDisplayNextQuestion());
        }

        public void OnChoice3()
        {
            if (_isAlreadyAnswer)
                return;

            _soundFXManager.PlayUITap("tap1");
            _isAlreadyAnswer = true;

            if (!IsHaveQuestions())
            {
                SceneManager.LoadScene("MainMenuScene");
                return;
            }

            _quizNumber++;
            CheckAnswer(_ans3Text.text, _imageArrayList[2]);
            StartCoroutine(WaitForSecondToDisplayNextQuestion());
        }

        public void OnChoice4()
        {
            if (_isAlreadyAnswer)
                return;

            _soundFXManager.PlayUITap("tap1");
            _isAlreadyAnswer = true;

            if (!IsHaveQuestions())
            {
                SceneManager.LoadScene("MainMenuScene");
                return;
            }

            _quizNumber++;
            CheckAnswer(_ans4Text.text, _imageArrayList[3]);
            StartCoroutine(WaitForSecondToDisplayNextQuestion());
        }
        #endregion

        #region :: Helper
        private void CheckAnswer(string answer, Image buttonImage)
        {
            Debug.Log("Checking answer: " + answer + " : " + _correctAns);
            if (_correctAns.Equals(answer))
            {
                buttonImage.color = Color.green;
            }
            else 
            {
                buttonImage.color = Color.red;
            }
        }

        private void DisplayQuiz()
        {
            if (_quizNumber >= _selectedQuiz.Length)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("MainMenuScene");
                return;
            }

            _correctAns = _selectedQuiz[_quizNumber].GetAnswer();
            _quizText.text = _selectedQuiz[_quizNumber].GetDescription();
            _ans1Text.text = _selectedQuiz[_quizNumber].GetChoiceList()[0];
            _ans2Text.text = _selectedQuiz[_quizNumber].GetChoiceList()[1];
            _ans3Text.text = _selectedQuiz[_quizNumber].GetChoiceList()[2];
            _ans4Text.text = _selectedQuiz[_quizNumber].GetChoiceList()[3];
        }

        private bool IsHaveQuestions() 
        {
            if (_quizNumber >= _selectedQuiz.Length) 
            {
                return false;
            }

            return true;
        }

        private void ResetButtonColor()
        {
            foreach (Image b in _imageArrayList)
            {
                b.color = Color.white;
            }
        }
        #endregion

        private IEnumerator WaitForSecondToDisplayNextQuestion()
        {
            yield return new WaitForSeconds(2f);
            _isAlreadyAnswer = false;
            ResetButtonColor();
            DisplayQuiz();
            StopCoroutine(WaitForSecondToDisplayNextQuestion());
        }

    }
}
