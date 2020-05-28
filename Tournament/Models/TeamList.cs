﻿using System.Collections.Generic;
using System.Windows.Documents;

namespace Tournament.Models
{
    class TeamList 
    {
        private List<Team> teamsList;
        private int count;

        /// <summary>
        /// Initializes a TeamsList
        /// </summary>
        private List<Team> TeamsList { get => teamsList; }


        /// <summary>
        /// Initializes a Count
        /// </summary>
        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Initializes a GetTeamsList
        /// </summary>
        public List<Team> GetTeamsList { get => teamsList; set => teamsList = value; }

        /// <summary>
        /// Adds Team to TeamsList
        /// </summary>
        public void AddTeam(Team team)
        {
            TeamsList.Add(team);
        }

        /// <summary>
        /// Removes Team from TeamsList
        /// </summary>
        public void RemoveTeam(int id)
        {
            foreach(var team in TeamsList)
            {
                if (team.IdTeam == id)
                    TeamsList.Remove(team);
            }
        }

        /// <summary>
        /// Saves a MatchList
        /// </summary>
        public void SaveTeamsList(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (var team in GetTeamsList)
                {
                    file.WriteLine("StartTeamsData");
                    file.WriteLine("TeamName: " + team.TeamName);
                    file.WriteLine("TeamID: " + team.IdTeam);
                    file.WriteLine("TeamsPointEarned: " + team.PointEarned);
                    if (team.PlayersList.Count > 0)
                    {
                        file.WriteLine("Players");
                        foreach (var player in team.PlayersList)
                        {
                            file.WriteLine("PlayerID: " + player.ID);
                            file.WriteLine("PlayerName: " + player.Name);
                            file.WriteLine("PlayerSurname: " + player.Surname);
                            file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                            file.WriteLine("EndPlayer");
                        }
                        file.WriteLine("EndTeam");
                    }
                    file.WriteLine("EndTeamsData");
                }
                file.Close();
            };
        }

        /// <summary>
        /// Load TeamList
        /// </summary>
        public List<Team> LoadTeamsList(string path)
        {
            var players = new PlayerList();
            var teamslist = new List<Team>(); 
            int teamID = 0;
            string teamName = "";
            int teamPoint = 0;

            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    switch (words[0])
                    {
                        case "TeamName:":
                            {
                                teamName = words[1];
                                break;
                            }
                        case "TeamID:":
                            {
                                teamID = int.Parse(words[1]);
                                break;
                            }
                        case "TeamsPointEarned:":
                            {
                                teamPoint = int.Parse(words[1]);
                                break;
                            }
                        case "Players:":
                            {
                                players.LoadPlayersList(path);
                                break;
                            }


                        case "EndTeamsData":
                            {

                                var team = new Team(teamName, teamID, players.PlayersList, teamPoint);
                                teamsList.Add(team);
                                break;
                            }
                    }
                }
                file.Close();
            };
            return teamsList;
        }


    }

}
