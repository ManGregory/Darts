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
            return _rule.IsCommand
                ? "Команда: " + GetCurrentTeam().Name + ", Игрок: " + GetCurrentUser().Name
                : "Игрок: " + GetCurrentUser().Name;
        }

        private Team GetCurrentTeam()
        {
            return _rule.IsCommand ? (_players[_currentTeamIndex] as Team) : null;
        }

        private User GetCurrentUser()
        {
            return _rule.IsCommand
                ? GetCurrentTeam().UsersAttending.ToList()[_currentUserIndex]
                : (_players[_currentUserIndex] as User);
        }


        public void MoveNextTeam()
        {
            // todo move next team
            throw new NotImplementedException();
        }

        public void MoveNextPlayer()
        {
            if (_rule.IsCommand)
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
            else
            {
                if (_currentUserIndex + 1 >= _players.Count)
                {
                    CurrentSerieNum++;
                    _currentUserIndex = 0;
                }
                else
                {
                    _currentUserIndex++;
                }
            }
        }
    }
}