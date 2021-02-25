using System;
using System.Collections.Generic;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); ;
            string[,] matrix = new string[n, n];
            List<string> coordinates = new List<string>(Console.ReadLine().Split(","));
            // filling
            for (int row = 0; row < n; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ");
                for (int column = 0; column < currentRow.Length; column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }
            // filled up
            int shipsFirstPlayer = 0;
            int shipsSecondPlayer = 0;
            int totalCountShipsDestroyed = 0;
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    switch (matrix[row, column])
                    {
                        case "<":
                            shipsFirstPlayer++;
                            break;
                        case ">":
                            shipsSecondPlayer++;
                            break;
                    }
                }
            }
            for (int i = 0; i < coordinates.Count; i++)
            {
                string[] tokens = coordinates[i].Split();
                int attackRow = int.Parse(tokens[0]);
                int attackColumn = int.Parse(tokens[1]);

                if (attackRow >= 0 && attackRow < n && attackColumn >= 0 && attackColumn < n)
                {
                    if (matrix[attackRow, attackColumn] == "#")
                    {
                        matrix[attackRow, attackColumn] = "X";
                        // 1.
                        if (attackRow >= 0 && attackRow < n && attackColumn + 1 >= 0 && attackColumn + 1 < n)
                        {
                            switch (matrix[attackRow, attackColumn + 1])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow, attackColumn + 1] = "X";
                        }
                        // 2.
                        if (attackRow + 1 >= 0 && attackRow + 1 < n && attackColumn + 1 >= 0 && attackColumn + 1 < n)
                        {
                            switch (matrix[attackRow + 1, attackColumn + 1])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow + 1, attackColumn + 1] = "X";
                        }
                        // 3.
                        if (attackRow + 1 >= 0 && attackRow + 1 < n && attackColumn >= 0 && attackColumn < n)
                        {
                            switch (matrix[attackRow + 1, attackColumn])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow + 1, attackColumn] = "X";
                        }
                        // 4.
                        if (attackRow + 1 >= 0 && attackRow + 1 < n && attackColumn - 1 >= 0 && attackColumn - 1 < n)
                        {
                            switch (matrix[attackRow + 1, attackColumn - 1])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow + 1, attackColumn - 1] = "X";
                        }
                        // 5.
                        if (attackRow >= 0 && attackRow < n && attackColumn - 1 >= 0 && attackColumn - 1 < n)
                        {
                            switch (matrix[attackRow, attackColumn - 1])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow, attackColumn - 1] = "X";
                        }
                        // 6.
                        if (attackRow - 1 >= 0 && attackRow - 1 < n && attackColumn - 1 >= 0 && attackColumn - 1 < n)
                        {
                            switch (matrix[attackRow - 1, attackColumn - 1])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow - 1, attackColumn - 1] = "X";
                        }
                        // 7.
                        if (attackRow - 1 >= 0 && attackRow - 1 < n && attackColumn >= 0 && attackColumn < n)
                        {
                            switch (matrix[attackRow - 1, attackColumn])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow - 1, attackColumn] = "X";
                        }
                        // 8.
                        if (attackRow - 1 >= 0 && attackRow - 1 < n && attackColumn + 1 >= 0 && attackColumn + 1 < n)
                        {
                            switch (matrix[attackRow - 1, attackColumn + 1])
                            {
                                case "<":
                                    shipsFirstPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                                case ">":
                                    shipsSecondPlayer--;
                                    totalCountShipsDestroyed++;
                                    break;
                            }
                            matrix[attackRow - 1, attackColumn + 1] = "X";
                        }
                    }
                }
                if (attackRow >= 0 && attackRow < n && attackColumn >= 0 && attackColumn < n)
                {
                    switch (matrix[attackRow, attackColumn])
                    {
                        case "<":
                            shipsFirstPlayer--;
                            totalCountShipsDestroyed++;
                            matrix[attackRow, attackColumn] = "X";
                            break;
                        case ">":
                            shipsSecondPlayer--;
                            totalCountShipsDestroyed++;
                            matrix[attackRow, attackColumn] = "X";
                            break;
                    }
                }
            }

            if (shipsSecondPlayer == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (shipsFirstPlayer == 0)
            {
                Console.WriteLine($"Player Twp has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsFirstPlayer} ships left. Player Two has {shipsSecondPlayer} ships left.");
            }
        }
    }
}
