using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace kiddiestories
{
    public class StoryHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text _storyTitle;
        [SerializeField] private TMP_Text _storyDescription;
        [SerializeField] private GameObject[] _story1Image;
        [SerializeField] private SoundManager _soundManager;

        private Story _selectedStory = Story.STORY1;
        private int _currentPage = 0;
        private readonly string[] _story1Array =
        {
            "Adda iti duwa nga tutak ayan ti danuman ayan iti igid iti waig. Ajay nga duwa nga tukak ket agina. Kananayen da nga nangiwat ken nagulo jay pag gyagyanan da nga agina.",
            "Ageti karuba da nga tukak idjay igid iti waig ket agriri dan iti laaw da nga duwa. “Ninyang! Bigbigat kami pay laeng ket!” riri iti karuba da.",
            "\"Sika gamin nga ubing nagsimpet ka unayen aya, nakaalaan ageta nga ugalim? \" damag na ni Ina nga tukak kenni anak nga  na bangad.",
            "\"Butsoy ingka umuli idjay nga kasla bundok ta ingka agala uray anya nga makan\" baon na ni Inang na kanyana, ngem atoy nga karag ket napan jay baba  na ajay nga bundok , apannakiayayam.",
            "Ibaon da manun atoy nga bangad nga tukak, \"Butsoy ingka agkita iti makan jay waig\". Ngem iti maramid na atoy nga tukak ket napan nagdigos jay waig. Amin nga ibaon ni Inang na ket madi na arramiden.",
            "Gado ta amin nga ibaon kanyana ket madi na araramiden, pinaguntan isunan ni Inang na.",
            "\"Apan ka man ditoy\" kuna ni Inang na napan isuna.",
            "\"Apay sika nga ubing nagkulit ka unay, nagtangken ulom. Kokak Kokak  bagam man.\" Ibabaon na ni Inang na nga agkokak kokak ngem iti sungbat na ket \"Kakok Kakok\".",
            "\"aminanin nga ibabaon ko kanyam nu madim aramiden jay nasayaat ket baliktadem!\" baga na ni Inang na  nga  agung unget.",
            "Amin nga pangbiruken iti makan ket ni Inang  nan ta kasjay mut galud ni Butsoy. Baket mutten ni Inang nan, isu nga simmampet aldaw ket natay ni Inang nan ti kinakapsot nan.",
            "Simula ajay awan maasahan nan agbirok makanen, nu ti kinasadot na iti panunuten  na ket mabininan isuna. Isu nga simula ajay nagbiyag Isunan maymaysa."
        };

        private void Start()
        {
            _selectedStory = StoryManager.GetSelectedStory();

            if (_selectedStory == Story.STORY1)
            {
                _storyTitle.text = "Kakok";
            }
            else if (_selectedStory == Story.STORY2)
            {
                _storyTitle.text = "Ni Pagong Kenne Nuwang";
            }
            else if (_selectedStory == Story.STORY3)
            {
                _storyTitle.text = "Ni Pagong Kenne Unggoy";
            }

            OnNext();
        }

        public void OnBack()
        {
            _soundManager.soundFXManager.PlayUITap("tap2");
            SceneManager.LoadScene("MainMenuScene");
        }

        public void OnNext()
        {
            _soundManager.soundFXManager.PlayUITap("tap1");

            if (_selectedStory == Story.STORY1)
            {
                if (!(_currentPage >= _story1Array.Length))
                {
                    if (_currentPage == 2)
                    {
                        _story1Image[0].SetActive(false);
                        _story1Image[1].SetActive(true);
                    }
                    else if (_currentPage == 4)
                    {
                        _story1Image[1].SetActive(false);
                        _story1Image[2].SetActive(true);
                    }
                    else if (_currentPage == 7)
                    {
                        _story1Image[2].SetActive(false);
                        _story1Image[3].SetActive(true);
                    }
                    else if (_currentPage == 10)
                    {
                        _story1Image[3].SetActive(false);
                        _story1Image[4].SetActive(true);
                    }

                    _storyDescription.text = _story1Array[_currentPage];
                    _currentPage++;
                }
                else 
                {
                    _storyDescription.text = "The END!!!";
                }
            }
            else if (_selectedStory == Story.STORY2)
            {
                Debug.Log("Story 2");
            }
            else if (_selectedStory == Story.STORY3)
            {
                Debug.Log("Story 3");
            }
        }

        public void Reset()
        {
            _currentPage = 0;
        }
    }
}
