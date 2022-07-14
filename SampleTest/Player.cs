using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakesandLadders
{
    class Player
    {
            private static readonly Random _rnd = new Random();
            private readonly int[] _board;

            private int _position;
            public int Position => _position + 1;

            public int DiceResult { get; private set; }
            public string NickName { get; }
            public bool Winner { get; private set; }

            public Player(string nickName, Board board)
            {
                NickName = nickName;
                _board = board.GameBoard;
            }

            public void Roll()
            {
            // Wait 30 milliseconds to change the random seed.
            //    Thread.Sleep(30);
            DiceResult = _rnd.Next(1, 7);
            }

            public void Move()
            {
            // Move the player N dice cells.
            if (_position + DiceResult < _board.Length)
                {
                    _position = _board[DiceResult + _position];
                    if (_position == _board.Length - 1)
                    {
                        Winner = true;
                    }
                }
            }
        }
    }
