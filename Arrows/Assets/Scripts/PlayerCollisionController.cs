using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCollisionController : NetworkBehaviour
{


    public void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.name.Contains("dblock") & GetComponent<ArrowPlayerController>().canMoveBlocks)
        {
            if (coll.gameObject.GetComponent<BlockController>().CanMoveInDirection(coll.gameObject.transform.position + transform.forward, 1))
            {
                coll.gameObject.GetComponent<BlockController>().CmdMoveTo(coll.gameObject.transform.position + transform.forward);
                //coll.gameObject.transform.position += transform.forward;
            }
        }
    }

  

}
