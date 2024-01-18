using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject markar;
    public static int[,] stageInfo =
    {
        {2,2,2,2,2,2,2,2,2,2,2},
        {2,3,0,0,0,0,0,0,0,0,2},
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
        {2,0,0,0,0,0,0,0,0,4,2},
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

    private void Awake()
    {
        // Stageとキャラクターの生成
        for(int i = 0; i < stageInfo.GetLength(0); i++) 
        {
            for(int j = 0;  j < stageInfo.GetLength(1); j++)
            {
                Vector3 pos = new Vector3(i, 0f, j);
                GameObject stageObject = null;
                Instantiate(ground, pos, Quaternion.identity,this.transform);

                switch (stageInfo[i, j])
                {
                    case (int)Stage.Block: stageObject = block; break;
                    case (int)Stage.Wall: stageObject = wall; break;
                    case (int)Stage.Player: stageObject = player; break;
                    case (int)Stage.Enemy: stageObject = enemy; break;
                    case (int)Stage.Maekar: stageObject = markar;break;
                    default: break;
                }
                if(stageObject != null)
                Instantiate(stageObject, pos, Quaternion.identity, this.transform);
            }
        }
    }

    // 空いてるスペースを探し移動先を提示する。
    // ランダムで移動先を提示しているのでここを工夫しないといけない。
    public Vector3 FindSpace(Stage stage)
    {
        List<Vector2Int> moveDirections = new List<Vector2Int>();
        Vector2Int pos = FindObject(stage);

        if (stageInfo[pos.x + 1, pos.y] == (int)Stage.None) moveDirections.Add(new Vector2Int(pos.x + 1, pos.y));
        if (stageInfo[pos.x - 1, pos.y] == (int)Stage.None) moveDirections.Add(new Vector2Int(pos.x - 1, pos.y));
        if (stageInfo[pos.x, pos.y + 1] == (int)Stage.None) moveDirections.Add(new Vector2Int(pos.x, pos.y + 1));
        if (stageInfo[pos.x, pos.y - 1] == (int)Stage.None) moveDirections.Add(new Vector2Int(pos.x, pos.y - 1));

        int random = Random.Range(0, moveDirections.Count);
        UpdatePosition(stage, moveDirections[random]);
        
        Vector3 movePosition = new Vector3(moveDirections[random].x, 0f, moveDirections[random].y);
        return movePosition;
    }

    private bool CheckSpace(Vector2Int pos)
    {
        if (stageInfo[pos.x, pos.y] == (int)Stage.None) return true;
        else return false;
    }

    // Stage情報の更新
    public void UpdatePosition(Stage stage, Vector2Int direction)
    {
        // 移動前の場所をNoneにする
        Vector2Int pos = FindObject(stage);
        stageInfo[pos.x, pos.y] = (int)Stage.None;

        // 移動後の場所をアップデートする
        stageInfo[direction.x, direction.y] = (int)stage;
    }
    
    // 渡されたオブジェクトの場所を検索
    private Vector2Int FindObject(Stage stage)
    {
        Vector2Int pos = Vector2Int.zero;
        for (int i = 0; i < stageInfo.GetLength(0); i++)
        {
            for (int j = 0; j < stageInfo.GetLength(1); j++)
            {
                if (stageInfo[i, j] == (int)stage)
                {
                    pos = new Vector2Int(i, j);
                }
            }
        }
        return pos;
    }
    public Vector3 EnemyToPlayer()
    {
        List<Vector2Int> moveDirections = new List<Vector2Int>();
        Vector2Int enemyPos = FindObject(Stage.Enemy);
        Vector2Int playerPos = FindObject(Stage.Player);

        Vector2Int diff = playerPos - enemyPos;
        if (diff.x > 0)
        {
            if (CheckSpace(enemyPos + Vector2Int.right)) moveDirections.Add(enemyPos + Vector2Int.right);
        }
        if (diff.x < 0)
        {
            if (CheckSpace(enemyPos + Vector2Int.left)) moveDirections.Add(enemyPos + Vector2Int.left);
        }
        if (diff.y > 0)
        {
            if (CheckSpace(enemyPos + Vector2Int.up)) moveDirections.Add(enemyPos + Vector2Int.up);
        }
        if (diff.y < 0)
        {
            if (CheckSpace(enemyPos + Vector2Int.down)) moveDirections.Add(enemyPos + Vector2Int.down);
        }

        if (moveDirections.Count == 0) return new Vector3(enemyPos.x, 0f, enemyPos.y);

        int random = Random.Range(0, moveDirections.Count);
        UpdatePosition(Stage.Enemy, moveDirections[random]);

        Vector3 movePosition = new Vector3(moveDirections[random].x, 0f, moveDirections[random].y);
        return movePosition;
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
