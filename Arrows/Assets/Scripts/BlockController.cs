using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BlockController : NetworkBehaviour
{

    [Command]
    public void CmdDestroyBlock()
    {
        gameObject.GetComponent<PowerSpawner>().CmdSpawnRandomPower();
        Destroy(gameObject);
    }

    public bool CanMoveInDirection(Vector3 dir, float area, Vector3 dirRef)
    {
        Collider[] nearObjects = Physics.OverlapSphere(gameObject.transform.position, area);
        
        foreach (Collider item in nearObjects)
        {
            ////if (item.gameObject.tag.Contains("Player"))
            ////    countPlayers++;
            //if (CheckEnemyPlayerIsFront(item.transform.position, dirRef, gameObject.transform.position) && item.gameObject.name.Contains("Player(Clone)"))
            //{
            //    Debug.LogError("player infront");
            //    return false;
            //}
                            

            if (item.transform.position == dir )
            {
                Debug.LogError((item.transform.position == dir) + " " + item.transform.position + " " + dir);
                return false;
            }
                
        }

        return true;

    }

    public bool CheckEnemyPlayerIsFront(Vector3 itemPos, Vector3 dirRef, Vector3 boxPos)
    {

        if (dirRef.z != 0)
        {
            if (((boxPos + dirRef) - itemPos).z > 2 || ((boxPos + dirRef) - itemPos).z < -2)
                return false;
        }

        if (dirRef.x != 0)
        {
            if (((boxPos + dirRef) - itemPos).x > 2 || ((boxPos + dirRef) - itemPos).x < -2)
                return false;
        }

        return true; //cant move block
    }

    [Command]
    public void CmdMoveTo(Vector3 pos)
    {
        Debug.LogError("moving!");
        transform.position = pos;
    }

    [ClientRpc]
    public void RpcMoveTo(Vector3 pos)
    {
        Debug.LogError("moving!");
        transform.position = pos;
    }
}
