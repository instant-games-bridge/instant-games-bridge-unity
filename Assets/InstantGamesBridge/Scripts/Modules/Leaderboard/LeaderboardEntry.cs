using System;
using System.Collections.Generic;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class LeaderboardEntry
    {
        public string id;
        public string name;
        public List<string> photos;
        public int score;
        public int rank;

        public LeaderboardEntry(string id, string name, List<string> photos, int score, int rank)
        {
            this.id = id;
            this.name = name;
            this.photos = photos;
            this.score = score;
            this.rank = rank;
        }
    }
}