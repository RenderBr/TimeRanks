using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TimeRanks
{
    public class RankInfo
    {
        public readonly string nextGroup;
        public readonly int rankCost;
        public readonly int derankCost;
        public readonly Dictionary<int, int> rankUnlocks;

        public RankInfo(string nextGroup, int rankCost, int derankCost, Dictionary<int, int> rankUnlocks)
        {
            this.nextGroup = nextGroup;
            this.rankCost = rankCost;
            this.derankCost = derankCost;
            this.rankUnlocks = rankUnlocks;
        }
    }

    public class Config
    {
        public string StartGroup = "default";
        public string voteApiKey = "";
        public string currencyNameSingular = "dolla";
        public string currencyNamePlural = "dollas";

        public Dictionary<string, RankInfo> Groups = new Dictionary<string, RankInfo> //new Dictionary<string, RankInfo>();
        {
            {"member", new RankInfo("frequent", 60, 0, new Dictionary<int, int>())}

        };

        public void Write(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static Config Read(string path)
        {
            if (!File.Exists(path))
                return new Config();
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
        }
    }
}
