using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    // Maze Size (X = Width, Z = Height)
    public int mazeSizeX;
    public int mazeSizeZ;

    //Prefabs of wall and cell
    public GameObject wallPrefab;
    public GameObject cellPrefab;

    // Create the maze with prefabs
    public void createMaze(int Width, int Height)
    {
        int mazeSizeX = Width;
        int mazeSizeZ = Height;

        MazeGenerator maze = new MazeGenerator(mazeSizeX, mazeSizeZ);
        maze.generate();

        for (int x = 0; x < mazeSizeX; x++)
        {
            for (int z = 0; z < mazeSizeZ; z++)
            {

                // Add Prefab Cell
                GameObject cell = Instantiate(cellPrefab);
                cell.transform.position = new Vector3(x * 2, -1, z * 2);
                cell.transform.Rotate(90, 0, 0);
                cell.transform.parent = gameObject.transform;

                // Add Prefab Wall +z
                if (maze.cells[x, z].walls[0] == true)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(x * 2, 0, z * 2 + 1);
                    wall.transform.parent = gameObject.transform;
                }

                // Add Prefab Wall +x
                if (maze.cells[x, z].walls[1] == true)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(x * 2 + 1, 0, z * 2);
                    wall.transform.Rotate(0, 90, 0);
                    wall.transform.parent = gameObject.transform;
                }

                // Add Prefab Wall -x
                if (maze.cells[x, z].walls[2] == true)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(x * 2 - 1, 0, z * 2);
                    wall.transform.Rotate(0, 90, 0);
                    wall.transform.parent = gameObject.transform;
                }
             
                // Add Prefab Wall -z
                if (maze.cells[x, z].walls[3] == true)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(x * 2, 0, z * 2 - 1);
                    wall.transform.parent = gameObject.transform;
                }

            }
        }
    }
}