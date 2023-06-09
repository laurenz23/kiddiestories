using UnityEngine;
using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;

namespace kiddiestories
{
    public static class Directory
    {

#if UNITY_EDITOR
        [MenuItem("Bright/Create Folder/Animation")]
        public static void CreateAnimationDir() => CreateNewDirectory("Animations", "Animations.NewFolder");


        [MenuItem("Bright/Create Folder/Art")]
        public static void CreateArtDir() => CreateNewDirectory("Arts", "Arts.NewFolder");


        [MenuItem("Bright/Create Folder/Prefab")]
        public static void CreatePrefabDir() => CreateNewDirectory("Prefabs", "Prefabs.NewFolder");


        [MenuItem("Bright/Create Folder/Scene")]
        public static void CreateSceneDir() => CreateNewDirectory("Scenes", "Scene.NewFolder");


        [MenuItem("Bright/Create Folder/Script")]
        public static void CreateScriptDir() => CreateNewDirectory("Scripts", "Scripts.NewFolder");


        private static void CreateNewDirectory(string path, string folderName)
        {
            CreateDirectory(Combine(dataPath + "/" + path, folderName));
            AssetDatabase.Refresh();
        }
#endif

    }
}
