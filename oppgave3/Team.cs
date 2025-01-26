using System;
using System.Collections.Generic;
using System.Linq;

namespace oppgave3
{
    public class Team
    {
        public static int count = 0;
        public static bool isNotEmpty => Team.count > 0;
        private List<Player> players = new List<Player>();

        public string Name { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public Player? GetPlayer(string name)
        {
            return players.FirstOrDefault(p => p.Name == name);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public List<Player> GetPlayersByRank(int rank)
        {
            return players.Where(p => p.Rank == rank).ToList();
        }

        public object CalculateStatistics()
        {
            var oldest = players.OrderByDescending(p => p.Age).FirstOrDefault();
            var youngest = players.OrderBy(p => p.Age).FirstOrDefault();
            var maxAge = players.Max(p => p.Age);
            var minAge = players.Min(p => p.Age);

            return new
            {
                OldestPlayer = oldest,
                YoungestPlayer = youngest,
                MaxAge = maxAge,
                MinAge = minAge
            };
        }

        public void UpdatePlayer(Player player)
        {
            var existingPlayer = players.FirstOrDefault(p => p.Name == player.Name);
            if (existingPlayer != null)
            {
                existingPlayer.Age = player.Age;
                existingPlayer.Position = player.Position;
                existingPlayer.Rank = player.Rank;
            }
        }
    }
}