using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The Maze generator uses the depth-first search algorithm. */

// MazePosition of cell
public class MazePosition
{
    public int x, z;
    public MazePosition(int posX, int posZ)
    {
        x = posX;
        z = posZ;
    }
}

public class MazeGenerator
{
    private int sizeX;
    private int sizeZ;

    // Cells
    public MazeCell[,] cells;
    // Stack of cells
    private MazePosition[] stack;
    // Position of cell in stack
    private int positionInStack;

    // MazeGenerator (Constructor)
    public MazeGenerator(int size_X, int size_Z)
    {
        sizeX = size_X;
        sizeZ = size_Z;

        cells = new MazeCell[sizeX, sizeZ];

        // Init all cells
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                cells[x, z] = new MazeCell();
            }
        }

        // Create stack (amount of all cells)
        stack = new MazePosition[sizeX * sizeZ];

        // Set a random position for the first cell
        int startX = Random.Range(0, sizeX);
        int startZ = Random.Range(0, sizeZ);

        // Put first cell in stack
        stack[0] = new MazePosition(startX, startZ);
        positionInStack = 0;

        // First cell is visited
        cells[startX, startZ].visited = true;
    }

    // Method to check possible neighbours
    private int[] checkNeighbours(MazePosition currentPosition)
    {
        // List of possible neighbours
        List<int> result = new List<int>();

        // Position of cell
        int x = currentPosition.x;
        int z = currentPosition.z;

        // Check wall +z
        if (z + 1 < sizeZ) // Check if its still in the maze size
        {
            if (cells[x, z + 1].visited == false) result.Add(0); // Add wall to possible neighbours
        }

        // Check wall +x
        if (x + 1 < sizeX) // Check if its still in the maze size
        {
            if (cells[x + 1, z].visited == false) result.Add(1); // Add wall to possible neighbours
        }
        // Check wall -x
        if (x - 1 >= 0) // Check if its still in the maze size
        {
            if (cells[x - 1, z].visited == false) result.Add(2); // Add wall to possible neighbours
        }

        // Check wall -z
        if (z - 1 >= 0) // Check if its still in the maze size
        {
            if (cells[x, z - 1].visited == false) result.Add(3); // Add wall to possible neighbours
        }

        // Return of neighbours
        return result.ToArray();
    }

    // Method to generate the maze
    public void generate()
    {
        /* The algorithm always go back if there is no neighbours found.  
         * So the algorithm will be executed until we are at the beginning of the stack again (so if there is no cell unvisited anymore) */
        while (positionInStack >= 0)
        {
            // Get the coordinates of the current cell 
            int x = stack[positionInStack].x;
            int z = stack[positionInStack].z;

            // Check neighbours
            int[] possibleNeighbours = checkNeighbours(stack[positionInStack]);

            if (possibleNeighbours.Length > 0)  // There are unvisited neighbours
            {
                // Take a random possible neighbour (wall)
                int wall = possibleNeighbours[Random.Range(0, possibleNeighbours.Length)];

                // Set the wall to false (make it a passage)
                cells[x, z].walls[wall] = false;

                // Identify the new coordinates of the new cell
                if (wall == 2) x--;
                else if (wall == 1) x++;
                else if (wall == 3) z--;
                else if (wall == 0) z++;

                // Set the new cell to visited
                cells[x, z].visited = true;
                // Make the opposite wall also a passage 
                cells[x, z].walls[3 - wall] = false;

                // Put the new cell in the stack with its position
                positionInStack++;
                stack[positionInStack] = new MazePosition(x, z);
            }

            else  // Found no neigbours
            {
                // Go back to the previous cell in stack
                positionInStack--;
                // Look for neighbours in the previous cell again
            }
        }
    }
}
