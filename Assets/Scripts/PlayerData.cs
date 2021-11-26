using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class PlayerData
    {
        public static FighterSO chosenFighterSO;
        public static FighterSO secondPlayerChosenFighterSO;

        public static float SoundVolume
        {
            get { return PlayerPrefs.GetFloat("SfxVolume", 0); }
            set { PlayerPrefs.SetFloat("SfxVolume", value); }
        }

        public static float MusicVolume
        {
            get { return PlayerPrefs.GetFloat("MusicVolume", 0); }
            set { PlayerPrefs.SetFloat("MusicVolume", value); }
        }
    }
}