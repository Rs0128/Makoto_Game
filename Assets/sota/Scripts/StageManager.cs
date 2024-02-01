using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class StageManager : MonoBehaviour
{
    
    public static int[,] stageInfo =
    {
        {2,2,2,2,2,2,2,2,2,2,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,0,2},
        {2,2,2,2,2,2,2,2,2,2,2}
    };
    
    public static int[,] makerinfo=
 {
        {2,2,2,2,2,2,2,2,2,2,2},
        {2,0,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,5,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,5,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,5,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,5,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,5,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,5,0,5,0,5,0,5,0,5,2},
        {2,0,1,0,1,0,1,0,1,0,2},
        {2,0,0,5,0,5,0,5,0,4,2},
        {2,2,2,2,2,2,2,2,2,2,2}
    };


    public enum Stage
    {
        None,
        Block,
        Wall,
        Player,
        Enemy,
        Maekar
    }

    public enum Direction
    {
        Left, Right, Up, Down
    }

    public enum ExplodePattern
    {
        Horizontal,
        Vertical,
        Cross
    }

    public Vector3 RandomBombPosition()
    {
        List<Vector3> list = new List<Vector3>();
        for(int i = 0; i < makerinfo.GetLength(0); i++)
        {
            for(int j = 0; j < makerinfo.GetLength(1); j++)
            {
                if(makerinfo[i,j] == (int)Stage.Maekar) 
                {
                    list.Add(new Vector3(i, 0f, j));
                } 
            }
        }

        return list[Random.Range(0, list.Count)];
    }

    public List<Vector3> ExplodePosition(int pattern, Vector3 bombPos)
    {
        Vector2Int pos = new Vector2Int((int)bombPos.x, (int)bombPos.z);
        List<Vector3> positions = new List<Vector3>();
        positions.Add(bombPos);
        switch (pattern)
        {
            case ((int)ExplodePattern.Horizontal):
                for (int i = pos.x + 1; i < stageInfo.GetLength(0); i++)
                {
                    if (stageInfo[i, pos.y] == (int)Stage.Block || stageInfo[i, pos.y] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(i, 0f, pos.y));
                    }
                }
                for (int i = pos.x - 1; i > 0; i--)
                {
                    if (stageInfo[i, pos.y] == (int)Stage.Block || stageInfo[i, pos.y] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(i, 0f, pos.y));
                    }
                }
                break;

            case ((int)ExplodePattern.Vertical):
                for (int i = pos.y + 1; i < stageInfo.GetLength(1); i++)
                {
                    if (stageInfo[pos.x, i] == (int)Stage.Block || stageInfo[pos.x, i] == (int)Stage.Wall) break;
                    else
                    {
                        positions.Add(new Vector3(pos.x, 0f, i));
                    }
                }
                for (int i = pos.y - 1; i > 0; i--)
                {
                    if (stageInfo[pos.x, i] == (int)Stage.Block || stageInfo[pos.x, i] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(pos.x, 0f, i));
                    }
                }
                break;

            case ((int)ExplodePattern.Cross):
                for (int i = pos.y + 1; i < stageInfo.GetLength(1); i++)
                {
                    if (stageInfo[pos.x, i] == (int)Stage.Block || stageInfo[pos.x, i] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(pos.x, 0f, i));
                    }
                }
                for (int i = pos.y - 1; i > 0; i--)
                {
                    if (stageInfo[pos.x, i] == (int)Stage.Block || stageInfo[pos.x, i] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(pos.x, 0f, i));
                    }
                }
                for (int i = pos.x + 1; i < stageInfo.GetLength(0); i++)
                {
                    if (stageInfo[i, pos.y] == (int)Stage.Block || stageInfo[i, pos.y] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(i, 0f, pos.y));
                    }
                }
                for (int i = pos.x - 1; i > 0; i--)
                {
                    if (stageInfo[i, pos.y] == (int)Stage.Block || stageInfo[i, pos.y] == (int)Stage.Wall) break;
                    //if(stageInfo[i, pos.y] != (int)Stage.Block && stageInfo[i, pos.y] != (int)Stage.Wall)
                    else
                    {
                        positions.Add(new Vector3(i, 0f, pos.y));
                    }
                }
                break;
        }

        return positions;
    }
}
