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

    public bool CanMoveInDirection(Vector3 dir, float area)
    {
        Collider[] nearObjects = Physics.OverlapSphere(gameObject.transform.position, area);

        foreach (Collider item in nearObjects)
        {
            if (item.transform.position == dir)
                return false;
                //Debug.LogError("this: " + item.name +" "+item.transform.position);
        }
        return true;

    }

    [Command]
    public void CmdMoveTo(Vector3 pos)
    {
        transform.position = pos;
    }
}
