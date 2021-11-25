using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class PlayerData
    {
        public static FighterSO chosenFighterSO;
        public static FighterSO secondPlayerChosenFighterSO;
        public static int plotStep;
        public static List<FighterSO> arenaFighters = new List<FighterSO>();
    }
}