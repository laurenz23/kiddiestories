using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public enum Story
    {
        STORY1,
        STORY2,
        STORY3
    }

    public class StoryManager
    {

        #region :: Variables
        private static Story _selectedStory;
        #endregion

        #region :: Properties
        public static void SetSelectedStory(Story story)
        {
            _selectedStory = story;
        }

        public static Story GetSelectedStory()
        {
            return _selectedStory;
        }
        #endregion

    }
}
