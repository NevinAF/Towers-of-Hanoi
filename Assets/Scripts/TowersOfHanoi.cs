using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersOfHanoi
{
    private int totalDisks;
    private Queue<Vector2Int> moves;

    public TowersOfHanoi(int disks)
    {
        totalDisks = disks;
        moves = new Queue<Vector2Int>();
    }

    public Queue<Vector2Int> Solve()
    {
        MoveTower(totalDisks, 0, 2, 1);

        return moves;
    }

    private void MoveTower(int numDisks, int start, int end, int temp)
    {
        if(numDisks == 1)
        {
            MoveOneDisk(start, end);
        }
        else
        {
            MoveTower(numDisks - 1, start, temp, end);
            MoveOneDisk(start, end);
            MoveTower(numDisks - 1, temp, end, start);
        }
    }

    private void MoveOneDisk(int start, int end)
    {
        moves.Enqueue(new Vector2Int(start, end));
    }
}


