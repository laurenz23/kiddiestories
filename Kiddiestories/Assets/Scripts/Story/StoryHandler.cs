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
        [SerializeField] private GameObject[] _storyArray;
        [SerializeField] private GameObject[] _story1Image;
        [SerializeField] private GameObject[] _story2Image;
        [SerializeField] private GameObject[] _story3Image;
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
        private readonly string[] _story2Array =
        {
            "Maysa nga bigat, nagsinnabat ni Pagong kenne Nuang",
            "Pagong: Nuwang papanam mabalen nga umayak met? Kayat ko kuma nga makigayyem kanya yo da kalding kenne kabayo",
            "Nuwang: tskk! Sika? Makipagayyem? Madik kayat nagy, Inya ngay met itt maaramid mo kuma, sa maysa makigayagayem kami laeng iti papada mi nga dadakkel. Nakabunbuntog ka pay nga magna!",
            "Pagong: Nagsakit ka met nga agsaon Nuwang, uray kastoyak laeng met serbik latta..",
            "Nuwang: Sige ngarod, makigayyem mak kanyam no maabak nak itit lumba. Aglumba ta nga makadanon idjay maikalima nga bantay, ni sika iti mangabak, ipaam-ammo ka kenne kalading kenne kabayo ken mabalen kan kumadwa kanayami.",
            "Nuwang: Ngem no syak iti managabak, haan nak nga isistorbwenen ken katkatungtongen nen.",
            "Pagong: wen sige! Mayat tak!",
            "Napakudkod laeng iti ulo ni Pagong, napanunot na,kasla imposible nga maabak n ani Nuwang iti lumba. Ngem, nakapanunot isuna iti ideya. Napan isuna idyay kakabsat nan ga Pagong ken kinatungtong na isuda",
            "Pagong: Kakabsat, adda kuma iti iapaiusap ko kanyo? Mabalen dak nga tulungan jay lumba no bigat? Bawat maysa kanya yo aganaed idjay idjay 4 nga bundok. Siyak to jay maika lima nga bundok. Kayat ko iti mangabak tapno maikkat iti lastog n ani Nuwang.",
            "Kakabsat nan ga Pagong: \"Wen cge Manong!\"",
            "Kinabigatan na. Nangrugi iti karera ni Pagong ken Nuwang",
            "Nuwang: Hahaha! Awan panama kenyak. Ammo tayon no sinno mangabak ken, Kitaem man maududti kan to pay yen tattan...",
            "Nagkarera ni Pagonng kenne Nuwang. Kampante ni Nuwang nga maabak n ani Pagong. Idi makadanon ijay umuna nga bantay, uray la nagillil ta Makita na ni pagong ket nabanbannog gen.",
            "Idi makadanon iti mai kadwa ken maikatlo, masdaaw ta isu pay immunan nga nakadanon nen",
            "Nadanagan ni nuwang iti sitwasyon isu nga pinaspasan nan bassit it nagna... idi makagudwa na iti maika oppat nga bundok agulaw isunan bannog ngem, bigla isuna naipaidda.",
            "Agay ayat ni Pagong nga didjay toktok iti maikalima nga bantay, Idi maka riing ni Nuwang…",
            "Nuwang: kongrats Pagong, naglaing ka, sika iti nangabak iti lumba.",
            "Pagong:”agyaman nak Nuwang!",
            "Nuwang: Manipod tatta, mabalen ka makigayem kanya men, ken iyam-ammo ka kenne kalding ken kabayo…",
            "Manipod iddi nagbalen nga agbest pren ni Nuwang kenne Pagong!"
        };
        private readonly string[] _story3Array =
        {
            "Maysa nga ladaw nagkarera ni Pagong ken Unggoy nga napan diay bantay. Daras nga nakadanun ni Unggoy.",
            "Ti kinabuntog na ni Pagong aradiay pay lang isuna katingaan ti dalan. Ti kinabayag ni Pagong nag inana ni Ungoy.",
            "Idi aradiay dan bantay nabisinan da a duwa. Nakabirok ni Pag-ong iti maysa nga puon tis saba nga ada ti bunga na.",
            "Awan ti nabirukan ni Unggoy. Ngem madi na met maala ni Pag-ong ta nangato diay bunga ti saba.",
            "Inuli ni Unggoy diay bunga a naluom a saba, kinanamin ni Unggoy diay saba. Sumaruno nga aldaw nagbisin da manen a duwa.",
            "Inala ni pag-ong diay puon ti saba ken inala met ni Unggoy diay murdong  na inmula da nga duwa diay saba.",
            "Simaruno nga domingo idi kinita da diay mula da natay diay immula ni Unggoy, nagtubo met diay Inmula ni Pag-ong dimakel inggana nagbunga diay saba ni Pag-ong. Rinimmingan ni Pag-ong diay mula na.",
            "Sumuno nga aldaw adda kinnan ni Pag-ong ngahaan suna nga mabisinan. Pirmi iti appal ni Unggoy kini Pag-ong, ta awan met ti makkan na.",
            "Naasyan ni Pag-ong keni Unggoy ket inikkan na ti saba para makan na. Haan nga nagbayag ket nagtungtung da nga duwa nga agmula da iti puon ti saba tapno no mabisin da ket ada iti makkan da nga duwa.",
            "Nagbalin da nga ag gayem inggana.",
            "Adal: Haan nga agim-imut iti kapada tayo, Agsaet tayo nga agmula tapno no agkaikailangan tayo keta da iti maani tayo."
        };

        private void Start()
        {
            _selectedStory = StoryManager.GetSelectedStory();

            if (_selectedStory == Story.STORY1)
            {
                _storyTitle.text = "Kakok";
                _storyArray[0].SetActive(true);
            }
            else if (_selectedStory == Story.STORY2)
            {
                _storyTitle.text = "Ni Pagong Kenne Nuwang";
                _storyArray[1].SetActive(true);
            }
            else if (_selectedStory == Story.STORY3)
            {
                _storyTitle.text = "Ni Pagong Kenne Unggoy";
                _storyArray[2].SetActive(true);
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
                    if (_currentPage == 0)
                    {
                        _story1Image[0].SetActive(true);
                    }
                    else if (_currentPage == 2)
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
                if (!(_currentPage >= _story2Array.Length))
                {
                    if (_currentPage == 0)
                    {
                        _story2Image[0].SetActive(true);
                    } 
                    else if (_currentPage == 3)
                    {
                        _story2Image[0].SetActive(false);
                        _story2Image[1].SetActive(true);
                    }
                    else if (_currentPage == 7)
                    {
                        _story2Image[1].SetActive(false);
                        _story2Image[2].SetActive(true);
                    }
                    else if (_currentPage == 10)
                    {
                        _story2Image[2].SetActive(false);
                        _story2Image[3].SetActive(true);
                    }
                    else if (_currentPage == 14)
                    {
                        _story2Image[3].SetActive(false);
                        _story2Image[4].SetActive(true);
                    }
                    else if (_currentPage == 18)
                    {
                        _story2Image[4].SetActive(false);
                        _story2Image[5].SetActive(true);
                    }

                    _storyDescription.text = _story2Array[_currentPage];
                    _currentPage++;
                }
                else
                {
                    _storyDescription.text = "The END!!!";
                }
            }
            else if (_selectedStory == Story.STORY3)
            {
                if (!(_currentPage >= _story3Array.Length))
                {
                    if (_currentPage == 0)
                    {
                        _story3Image[0].SetActive(true);
                    }
                    else if (_currentPage == 2)
                    {
                        _story3Image[0].SetActive(false);
                        _story3Image[1].SetActive(true);
                    }
                    else if (_currentPage == 4)
                    {
                        _story3Image[1].SetActive(false);
                        _story3Image[2].SetActive(true);
                    }
                    else if (_currentPage == 7)
                    {
                        _story3Image[2].SetActive(false);
                        _story3Image[3].SetActive(true);
                    }
                    else if (_currentPage == 10)
                    {
                        _story3Image[3].SetActive(false);
                        _story3Image[4].SetActive(true);
                    }

                    _storyDescription.text = _story3Array[_currentPage];
                    _currentPage++;
                }
                else
                {
                    _storyDescription.text = "The END!!!";
                }
            }
        }

        public void Reset()
        {
            _currentPage = 0;
        }
    }
}
