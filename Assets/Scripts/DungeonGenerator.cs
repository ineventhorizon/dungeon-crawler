using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }

    public Vector2 size;
    public int startPos = 0;
    public GameObject room;
    public Vector2 offset;

    List<Cell> board;
    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateDungeon()
    {
        for(int i =0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currentCell.visited)
                {
                    var newRoom = Instantiate(room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBeh>();
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i + j * size.x)].status);
                    newRoom.name += " " + i + "-" + j;
                }
                
            }
        }
    }

    void MazeGenerator()
    {
        board = new List<Cell>();
        for(int i = 0; i < size.x; i++)
        {
            //Debug.Log(i);
            for(int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int k = 0;

        while (k < 1000)
        {
            k++;
            board[currentCell].visited = true;

            if(currentCell == board.Count -1)
            {
                break;
            }

            //check neighbors
            List<int> neigbors = CheckNeighbors(currentCell);

            if(neigbors.Count == 0)
            {
                if(path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neigbors[Random.Range(0, neigbors.Count)];

                if (newCell > currentCell)
                {
                    if(newCell -1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }
            }
        }
        GenerateDungeon();
    }
    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //up
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }
        //down
        if (cell + size.x < board.Count  && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }
        //right
        if ((cell+1) % size.x != 0  && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }
        //left
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell -1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell -1));
        }
        return neighbors;
    }
}
