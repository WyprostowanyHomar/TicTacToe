using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isItWhitesTurn = true;
    private int boardSize; //we declare it in board generator
    int[,,] boardArray;
    public GameObject whiteTokken;
    public GameObject blackTokken;
    public GameObject emptyField;
    int gamemode;
    private Vector3[] directions = {new Vector3(1,0,0), new Vector3(0, 1, 0), new Vector3(0, 0, 1),
        new Vector3(1, 1, 0), new Vector3(1, -1, 0), new Vector3(1, 0, 1), new Vector3(1, 0, -1), new Vector3(0, 1, 1), new Vector3(0, -1, 1),
        new Vector3(1,1,1),new Vector3(-1,1,1),new Vector3(1,-1,1),new Vector3(1,1,-1),};
    void Start()
    {
        BoardGenerator boardGenerator = GetComponent<BoardGenerator>();
        boardSize = boardGenerator.boardSize;
        boardArray = new int[boardSize,boardSize,boardSize];
        for(int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                for (int z = 0; z < boardSize; z++)
                {
                    boardArray[x, y, z] = 0;
                }
            }
        }
        gamemode = boardGenerator.gamemode;
    }

    // 0 oznacza puste pole, 1 oznacza biały kolor, -1 oznacza czarny kolor
    public void InsertTokken(Vector3 tokkenPosition)
    {
        if (isItWhitesTurn)
        {
            boardArray[(int)tokkenPosition.x, (int)tokkenPosition.y, (int)tokkenPosition.z] = 1;
            Instantiate(whiteTokken, tokkenPosition, Quaternion.identity);
        }
        else
        {
            boardArray[(int)tokkenPosition.x, (int)tokkenPosition.y, (int)tokkenPosition.z] = -1;
            Instantiate(blackTokken, tokkenPosition, Quaternion.identity);
        }
        if (gamemode == 1)
            if ((int)tokkenPosition.y < boardSize - 1)
                Instantiate(emptyField, tokkenPosition + Vector3.up, Quaternion.identity);
        CheckWinCondition(tokkenPosition);
    }
    bool CheckWinCondition(Vector3 tokkenPosition) 
    {
        foreach(Vector3 direction in directions)
        {
            int howManyTokkens=1;//liczymy obecną pozycję
            //w jedną stronę
            int i=1;
            Vector3 lookedPosition = tokkenPosition + i * direction;

            while (!((int)lookedPosition.x < 0 || (int)lookedPosition.y < 0 || (int)lookedPosition.z < 0 ||
                (int)lookedPosition.x > boardSize - 1 || (int)lookedPosition.y > boardSize - 1 || (int)lookedPosition.z > boardSize - 1))
            {
                if (boardArray[(int)lookedPosition.x, (int)lookedPosition.y, (int)lookedPosition.z] == 1 && isItWhitesTurn)
                    howManyTokkens++;

                if (boardArray[(int)lookedPosition.x, (int)lookedPosition.y, (int)lookedPosition.z] == -1 && !isItWhitesTurn)
                    howManyTokkens++;
                i++;
                lookedPosition = tokkenPosition + i*direction;
            }


            //w drtugą strronę
            i = 1;
            lookedPosition = tokkenPosition - i * direction;

            while (!((int)lookedPosition.x < 0 || (int)lookedPosition.y < 0 || (int)lookedPosition.z < 0 ||
                (int)lookedPosition.x > boardSize - 1 || (int)lookedPosition.y > boardSize - 1 || (int)lookedPosition.z > boardSize - 1))
            {
                if (boardArray[(int)lookedPosition.x, (int)lookedPosition.y, (int)lookedPosition.z] == 1 && isItWhitesTurn)
                    howManyTokkens++;

                if (boardArray[(int)lookedPosition.x, (int)lookedPosition.y, (int)lookedPosition.z] == -1 && !isItWhitesTurn)
                    howManyTokkens++;
                i++;
                lookedPosition = tokkenPosition - i * direction;
            }

            if (howManyTokkens == boardSize)
            {
                Debug.Log("You Won");
                return true;
            }
        }
        NextTurn();
        return false;
    }
    private void NextTurn()
    {
        isItWhitesTurn = !isItWhitesTurn;
    }
}
