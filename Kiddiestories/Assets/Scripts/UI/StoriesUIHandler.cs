using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class StoriesUIHandler : MainSubUIPanel
    {
        #region :: Actions
        public void OnStory1()
        {
            soundFXManager.PlayUITap("tap1");
            SwitchScene(Story.STORY1);
        }

        public void OnStory2()
        {
            soundFXManager.PlayUITap("tap1");
            SwitchScene(Story.STORY2);
        }

        public void OnStory3()
        {
            soundFXManager.PlayUITap("tap1");
            SwitchScene(Story.STORY3);
        }
        #endregion

        #region :: Helper
        public void SwitchScene(Story selectedStory)
        {
            StoryManager.SetSelectedStory(selectedStory);
        }
        #endregion
    }
}
