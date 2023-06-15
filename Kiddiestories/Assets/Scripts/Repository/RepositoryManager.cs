using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

namespace kiddiestories
{
    public class RepositoryManager : MonoBehaviour
    {
        private static RepositoryManager _instance;

        public static RepositoryManager GetInstance()
        {
            return _instance;
        }


        #region :: Variables
        public bool loadData;

        private PlayerModel _playerProfileData;

        private readonly string _fileExtension = ".json";
        private readonly string _playerProfileStr = "ProfileData";
        #endregion


        #region :: Lifecycle
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void Start()
        {
            if (loadData)
            {
                _playerProfileData = LoadPlayerProfileData();
            }
        }
        #endregion


        #region :: Properties
        public bool GetIsPlayerProfileExist()
        {
            return IsExist(_playerProfileStr);
        }

        public PlayerModel GetPlayerProfileData()
        {
            return _playerProfileData;
        }
        #endregion


        #region :: Player profile data
        public void SavePlayerProfileData(PlayerModel playerData)
        {
            SaveData(_playerProfileStr, playerData);
        }

        public PlayerModel LoadPlayerProfileData()
        {
            PlayerModel pm = new();
            if (LoadData(_playerProfileStr, pm))
            {
                _playerProfileData = pm;
                return _playerProfileData;
            }

            return null;
        }

        public void DeletePlayerProfileData()
        {
            DeleteData(_playerProfileStr);
        }
        #endregion

        #region :: Helper
        private bool IsExist(string fileName)
        {
            string filePath = Application.persistentDataPath + "/" + fileName + _fileExtension;

            if (File.Exists(filePath))
                return true;

            return false;
        }

        private void SaveData(string fileName, object objectData)
        {
            string destination = Application.persistentDataPath + "/" + fileName + _fileExtension;

            string json = JsonUtility.ToJson(objectData);

            File.WriteAllText(destination, json);

#if UNITY_EDITOR
            Debug.Log(fileName + " Data File Save: " + destination, this);
#endif
        }

        private bool LoadData(string fileName, object objectData)
        {
            string destination = Application.persistentDataPath + "/" + fileName + _fileExtension;

            if (File.Exists(destination))
            {
                string json = File.ReadAllText(destination);

                JsonUtility.FromJsonOverwrite(json, objectData);

                return true;
            }

#if UNITY_EDITOR
            Debug.Log(fileName + " Data File does not exist: " + destination, this);
#endif

            return false;
        }

        private void DeleteData(string fileName)
        {
            string filePath = Application.persistentDataPath + "/" + fileName + _fileExtension;

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        #endregion

    }
}
