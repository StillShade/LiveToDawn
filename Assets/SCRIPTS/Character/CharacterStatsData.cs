using System;
using System.Collections.Generic;

namespace Character
{
    [Serializable]
    public class CharacterStatsData
    {
        public Dictionary<CharacterStatType, int> stats = new();
    }
}