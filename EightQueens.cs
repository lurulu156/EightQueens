using System;
using System.Collections.Generic;

int n = 8;
List<List<string>> solutions = SolveNQueens(n);

int solutionNumber = 1;
foreach (var solution in solutions)
{
    Console.WriteLine($"//Solution {solutionNumber}:");
    foreach (var row in solution)
    {
        Console.WriteLine(row);
    }
    Console.WriteLine();
    solutionNumber++;
}

static List<List<string>> SolveNQueens(int n)
{
    List<List<string>> result = new List<List<string>>();
    char[][] board = new char[n][];
    for (int i = 0; i < n; i++)
    {
        board[i] = new string('.', n).ToCharArray();
    }

    bool IsSafe(int row, int col)
    {
        //checking column
        for (int i = 0; i < row; i++)
        {
            if (board[i][col] == 'Q')
                return false;
        }
        //checking diagonal
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q')
                return false;
        }

        for (int i = row, j = col; i >= 0 && j < n; i--, j++)
        {
            if (board[i][j] == 'Q')
                return false;
        }

        return true;
    }

    void Solve(int row)
    {
        if (row == n)
        {
            List<string> solution = new List<string>();
            for (int i = 0; i < n; i++)
            {
                solution.Add(new string(board[i]));
            }
            result.Add(solution);
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (IsSafe(row, col))
            {
                board[row][col] = 'Q';
                Solve(row + 1);
                board[row][col] = '.';
            }
        }
    }

    Solve(0);
    return result;
}
