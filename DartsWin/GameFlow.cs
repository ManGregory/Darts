using System;
using System.Collections.Generic;
using System.Linq;
using DartsConsole;

namespace DartsWin
{
    public class GameFlow
    {
        private Rule _rule;
        private List<object> _players;
        private int _currentTeamIndex;
        private int _currentUserIndex;

        public int CurrentSerieNum { get; private set; }

        public string CurrentPlayer
        {
            get { return GetCurrentPlayerText(); }
        }

        public User CurrentUser
        {
            get { return GetCurrentUser(); }
        }

        public Team CurrentTeam
        {
            get
            {
                return GetCurrentTeam();
            }
        }

        public GameFlow(Rule rule, IEnumerable<object> players)
        {
            _rule = rule;
            _players = new List<object>(players);
            _currentTeamIndex = 0;
            _currentUserIndex = 0;
            CurrentSerieNum = 1;
        }

        private string GetCurrentPlayerText()
        {
            return "Команда: " + GetCurrentTeam().Name + ", Игрок: " + GetCurrentUser().Name;
        }

        private Team GetCurrentTeam()
        {
            return _players[_currentTeamIndex] as Team;
        }

        private User GetCurrentUser()
        {
            return GetCurrentTeam().UsersAttending.ToList()[_currentUserIndex];
        }


        public void MoveNextTeam()
        {
            _currentUserIndex = 0;
            if (_currentTeamIndex + 1 >= _players.Count)
            {
                CurrentSerieNum++;
                _currentTeamIndex = 0;
            }
            else
            {
                _currentTeamIndex++;
            }
        }

        public void MoveNextPlayer()
        {
            if (_currentUserIndex + 1 >= GetCurrentTeam().UsersAttending.Count)
            {
                if (_currentTeamIndex + 1 >= _players.Count)
                {
                    CurrentSerieNum++;
                    _currentTeamIndex = 0;
                    _currentUserIndex = 0;
                }
                else
                {
                    _currentTeamIndex++;
                    _currentUserIndex = 0;
                }
            }
            else
            {
                _currentUserIndex++;
            }
        }
    }
}