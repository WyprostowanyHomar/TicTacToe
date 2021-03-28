using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour {

    public GameObject emptyField;
    public GameObject linePrefab;
    public GameObject Grid;
    public int boardSize = 4;
    public Vector3 boardMiddle;
    public int gamemode=1;
	void Awake()
    {
        GenerateBoard();
        
    }
    void GenerateBoard()
    {
        boardMiddle = new Vector3((boardSize - 1) / 2.0f, (boardSize - 1) / 2.0f, (boardSize - 1) / 2.0f);
        if (gamemode == 0)//standard tic tac tou
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    for (int z = 0; z < boardSize; z++)
                    {
                        Instantiate(emptyField, new Vector3(x, y, z), Quaternion.identity);
                        if (z == 0)
                        {
                            GameObject line = Instantiate(linePrefab, new Vector3(x, y, z), Quaternion.identity);
                            line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new Vector3(x, y, z), new Vector3(x, y, boardSize - 1) } );
                            line.transform.SetParent(Grid.transform);
                        }
                        if (x == 0)
                        {
                            GameObject line = Instantiate(linePrefab, new Vector3(x, y, z), Quaternion.identity);
                            line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new Vector3(x, y, z), new Vector3(boardSize-1, y, z) });
                            line.transform.SetParent(Grid.transform);
                        }
                        if (y == 0)
                        {
                            GameObject line = Instantiate(linePrefab, new Vector3(x, y, z), Quaternion.identity);
                            line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new Vector3(x, y, z), new Vector3(x, boardSize-1, z) });
                            line.transform.SetParent(Grid.transform);
                        }

                    }
                }
            }
        }
        else if (gamemode == 1) // gravity tic tac tou
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    Instantiate(emptyField, new Vector3(x, 0, y), Quaternion.identity);
                    for (int z = 0; z < boardSize; z++)
                    {
                        if (z == 0)
                        {
                            GameObject line = Instantiate(linePrefab, new Vector3(x, y, z), Quaternion.identity);
                            line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new Vector3(x, y, z), new Vector3(x, y, boardSize - 1) });
                            line.transform.SetParent(Grid.transform);
                        }
                        if (x == 0)
                        {
                            GameObject line = Instantiate(linePrefab, new Vector3(x, y, z), Quaternion.identity);
                            line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new Vector3(x, y, z), new Vector3(boardSize - 1, y, z) });
                            line.transform.SetParent(Grid.transform);
                        }
                        if (y == 0)
                        {
                            GameObject line = Instantiate(linePrefab, new Vector3(x, y, z), Quaternion.identity);
                            line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { new Vector3(x, y, z), new Vector3(x, boardSize - 1, z) });
                            line.transform.SetParent(Grid.transform);
                        }

                    }
                }
            }
        }
    }

}
