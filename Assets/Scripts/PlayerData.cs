using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class PlayerData
    {
        public static FighterSO chosenFighterSO;
        public static FighterSO secondPlayerChosenFighterSO;
        public static int plotStep;
        public static List<FighterSO> arenaFighters = new List<FighterSO>();

        public static bool isSoundDisabled
        {
            get { return PlayerPrefs.GetInt("Sound", 0) == 0; }
            set { PlayerPrefs.SetInt("Sound", value ? 1 : 0); }
        }

        public static bool isMusicDisabled
        {
            get { return PlayerPrefs.GetInt("Music", 0) == 0; }
            set { PlayerPrefs.SetInt("Music", value ? 1 : 0); }
        }
    }
}