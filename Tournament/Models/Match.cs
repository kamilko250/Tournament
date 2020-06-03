﻿using System;
using System.Collections.Generic;

namespace Tournament.Models
{
    public enum MatchRank
    { 
        GroupStage, Semifinal, Final
    }
    public enum GameType
    { 
        Volleyball, TugOfWar, DodgeBall
    }
    class Match
    {
        private List<Referee> referees;
        private Team A;
        private Team B;
        private int teamAScore;
        private int teamBScore;
        private int teamA_ID;
        private int teamB_ID;
        private GameType gameType;
        private int matchID;
        private MatchRank matchRank;

        /// <summary>
        /// Initializes a new instance of Match 
        /// </summary> 
        public Match(Team A,
                    Team B,
                    List<Referee> referees,
                    MatchRank matchRank, int teamA_ID,
                    int teamB_ID, GameType gameType, List<Match> matchList)
        {

            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (matchList != null)
                {
                    foreach (var match in matchList)
                        if (randID == match.MatchID)
                            FreeID = false;
                }
                else
                {
                    MatchID = randID;
                    FreeID = false;
                    break;
                }
            } while (FreeID == false);
            if (FreeID)
                MatchID = randID;

            this.A = A;
            this.B= B;
            Referees = referees;
            TeamA_ID = teamA_ID;
            TeamB_ID = teamB_ID;
            GameType = gameType;
            MatchRank = matchRank;
        }

        public Match(Match match)
        {
            this.referees = match.Referees;
            this.A = match.A;
            this.B = match.B;
            this.teamAScore = match.TeamAScore;
            this.teamBScore = match.TeamBScore;
            this.teamA_ID = match.teamA_ID;
            this.teamB_ID = match.TeamB_ID;
            this.gameType = match.GameType;
            this.matchID = match.MatchID;
            this.matchRank = match.MatchRank;
        }
        /// <summary>
        /// Gets a Referees List  of Match
        /// </summary>
        public List<Referee> Referees
        {
            get => referees;
            private set => referees = value;
        }
        /// <summary>
        /// Adds TeamAScore, TeamBScore and MatchID to Match. 
        /// Use when Match was read from file
        /// and you want to add missing fields 
        /// </summary>
        public void ReadMatch(int teamAScore,int teamBScore, int matchID)
        {
            TeamAScore = teamAScore;
            TeamBScore = teamBScore;
            MatchID = matchID;
        }

        /// <summary>
        /// Gets  a matchID value
        /// </summary>
        public int MatchID
        {
            get => matchID;
            private set => matchID = value;
        }
        /// <summary>
        /// Simulates results of match and 
        /// returns results(teamAscore,teamBscore) 
        /// </summary>
        public void SymulateGame()
        {
            Random random = new Random();
            switch(random.Next(1,3))
            {
                case (1):
                    {
                    A.PointEarned=TeamAScore = 3;
                    B.PointEarned=TeamBScore = 0;
                        break;
                    }
                case (2):
                    {
                        A.PointEarned = TeamAScore = 1;
                        B.PointEarned = TeamBScore = 1;
                        break;
                    }
                case (3):
                    {
                        A.PointEarned = TeamAScore = 0;
                        B.PointEarned = TeamBScore = 3;
                        break;
                    }
            }

        }
        /// <summary>
        /// Gets a matchRank value
        /// </summary>
        public MatchRank MatchRank
        {
            get => matchRank;
            private set => matchRank = value;
        }
        /// <summary>
        /// Gets a GameType value of match
        /// </summary>
        public GameType GameType
        {
            get => gameType;
            private set => gameType = value;
        }
        /// <summary>
        /// Gets TeamAScore value
        /// </summary>
        public int TeamAScore
        {
            get => teamAScore;
            private set=> teamAScore = value;
        }
        /// <summary>
        /// Gets TeamBScore value
        /// </summary>
        public int TeamBScore
        {
            get => teamBScore;
            private set => teamBScore = value;
        }
        /// <summary>
        /// Gets TeamA ID value
        /// </summary>
        public int TeamA_ID
        {
            get => teamA_ID;
            private set => teamA_ID = value;

        }
        /// <summary>
        /// Gets TeamB ID value
        /// </summary>
        public int TeamB_ID
        {
            get => teamB_ID;
            private set => teamB_ID = value;

        }
        /// <summary>
        /// Gets a List<Players> of TeamA  
        /// </summary>
        public List<Player> PlayersTeamA
        {
            get => A.PlayersList.PlayersList;

        }
        /// <summary>
        /// Gets a List<Players> of TeamB
        /// </summary>
        public List<Player> PlayersTeamB
        {
            get => B.PlayersList.PlayersList;

        }
    }



}
