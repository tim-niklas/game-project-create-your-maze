using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public bool[] walls;
    public bool visited;

    public MazeCell()
    {
        walls = new bool[4] { true, true, true, true }; // true = wall, false = passage
        visited = false; 
    }
}
