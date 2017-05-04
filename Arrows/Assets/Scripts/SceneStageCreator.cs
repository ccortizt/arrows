using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneStageCreator : NetworkBehaviour
{

    private int xSize;
    private int ySize;

    [SerializeField]
    GameObject prefabIndestructibleBlock;

    [SerializeField]
    GameObject prefabDestructibleBlock;

    private bool[,] stage;


    void Start()
    {
        xSize = 22;
        //ySize = 19;
        ySize = 16;
     
        SetStageSize();

        InitializeStage();
        CreateFixedWalls();
        InstantiateWalls();

        InstantiateExternalWalls();
        CreateDestructibleWalls();
    }

    private void CreateDestructibleWalls()
    {
         for (int i = 0; i < xSize; i ++)
             for (int j = 0; j < ySize; j ++)
             {

                 if (Random.Range(1, 10) < 4.5f) //6
                 {
                     if (stage[i, j] == false && !IsFreeSpace(i, j))
                     {
                         GameObject block = Instantiate(prefabDestructibleBlock, new Vector3(i, 0f, j), Quaternion.identity);
                         block.transform.parent = transform;
                         block.name = "dblock" + i + "_" + j;
                         NetworkServer.Spawn(block);
                     }
                 }
             }
    }


    bool IsFreeSpace(int x, int y)
    {


        if (x == 0 & y == 0 || x == xSize -1 & y == 0 || x == 0 & y == ySize -1 || x == xSize -1 & y == ySize -1)
        {
            return true;
        }

        if (x == 1 & y == 0 || x == 0 & y == 1 || x == xSize - 2 & y == 0 || x == xSize -1 & y == 1)
        {
            return true;
        }

        if (x == 0 & y == ySize - 2 || x == 1 & y == ySize - 1 || x == xSize - 2 & y == ySize - 1 || x == xSize - 1 & y == ySize - 2)
        {
            return true;
        }

        return false;
    }
    
    void Update()
    {

    }

    private void SetStageSize()
    {
        stage = new bool[xSize, ySize];
    }

    private void InitializeStage()
    {
        for (int i = 0; i < xSize; i++)
            for (int j = 0; j < ySize; j++)
                stage[i, j] = false;
    }

    private void CreateFixedWalls()
    {
        for (int i = 1; i < xSize; i += 3)
            for (int j = 1; j < ySize; j += 3)
            {
                //
                if (i % 2  == j % 2 )
                {
                    stage[i, j] = true;
                    //if(i + 1 < xSize)
                    stage[i + 1, j] = true;
                    // if (j + 1 < xSize)
                    stage[i, j + 1] = true;
                    // if (i + 1 < xSize & j + 1 < ySize)
                    stage[i + 1, j + 1] = true;
                }
               
                
            }

    }

    private void InstantiateWalls()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                if (stage[i, j] == true)
                {
                    GameObject block = Instantiate(prefabIndestructibleBlock, new Vector3(i, 0f, j), Quaternion.identity);
                    block.transform.parent = transform;
                    block.name = "iblock" + i + "_" + j;
                    NetworkServer.Spawn(block);
                }
            }
        }
    }

    private void InstantiateExternalWalls()
    {

        int j = ySize;
        for (int i = -1; i < xSize; i ++)
        {
            GameObject block = Instantiate(prefabIndestructibleBlock, new Vector3(i, 0, j), Quaternion.identity);
            block.transform.parent = transform;
            NetworkServer.Spawn(block);
        }


        j = -1;
        for (int i = -1; i < xSize; i ++)
        {
            GameObject block = Instantiate(prefabIndestructibleBlock, new Vector3(i, 0, j), Quaternion.identity);
            block.transform.parent = transform;
            NetworkServer.Spawn(block);
        }

        j = -1;
        for (int i = -1; i < ySize + 1; i ++)
        {
            GameObject block = Instantiate(prefabIndestructibleBlock, new Vector3(j, 0, i), Quaternion.identity);
            block.transform.parent = transform;
            NetworkServer.Spawn(block);
        }

        j = xSize;
        for (int i = -1; i < ySize + 1; i ++)
        {
            GameObject block = Instantiate(prefabIndestructibleBlock, new Vector3(j, 0, i), Quaternion.identity);
            block.transform.parent = transform;
            NetworkServer.Spawn(block);
        }

    }



}
