using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesandLadders
{
        class Board
        {
        public int[] GameBoard { get; }
        public Board()
        {
            // A 100-cell board is created.
            GameBoard = CreateBoard(100);
        }

        // Function to create Ladders and Snakes.Se changes the value
        // of the array in the index [i-1] being i the key of the
        // dictionary.the value that is saved in that index corresponds
        // to the value of the board where the player moves in case of
        // falling into said Index.
        //
        // Ex: Key => 2, Value => 10 implies that there is a ladder that
        // goes from cell 1 to cell 9 of the board.
        private void CreateSnakesOrLadders((int, int)[] jumps)
        {
            foreach (var (from, to) in jumps)
            {
                GameBoard[from - 1] = to - 1;
            }
        }

        // Default constructor overload
        // Creates an A x L board by adding ladders and snakes.
        public Board(int height, int length,
           (int, int)[] ladders = null, (int, int)[] snakes = null)
        {
            // At a minimum, a 2x2 board is necessary.
            if (height < 2 || length < 2)
            {
                throw new Exception("The height and length need to be at least greater than 1.");
            }
            // Ensure non-null arrays. Initial size of the number of ladders and snakes on the board.
            ladders = ladders ?? Array.Empty<(int, int)>();
            snakes = snakes ?? Array.Empty<(int, int)>();

            // We create the GameBoard.
            GameBoard = CreateBoard(height * length);

            // If the total size of the number of ladders and snakes is greater than half the board length,the exception is thrown.
            // If not the ladders and snakes are created on the board.
            if (ladders.Length + snakes.Length > GameBoard.Length / 2)
            {
                throw new Exception("The total sum of Snakes and Ladders cannot exceed 50% of the board.");
            }
            CreateSnakesOrLadders(ladders);
            CreateSnakesOrLadders(snakes);
        }
        private int[] CreateBoard(int size)
        {
            int[] board = new int[size];
            for (int i = 0; i < size; i++)
            {
                board[i] = i;
            }
            return board;
        }
       
    }
  
    }

