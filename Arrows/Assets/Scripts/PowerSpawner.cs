using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerSpawner : NetworkBehaviour
{

    [SerializeField]
    GameObject prefabSpeedPlus;

    [SerializeField]
    GameObject prefabSpeedMinus;

    [Command]
    public void CmdSpawnRandomPower()
    {
        //if (Random.Range(0, 10) > 5)
        //{
        //    GameObject prefab = Instantiate(prefabSpeedMinus, transform.position, Quaternion.identity);
        //    //prefab.transform.parent = transform;

        //    NetworkServer.Spawn(prefab);
        //}
        //else
        //{
        //    GameObject prefab = Instantiate(prefabSpeedPlus, transform.position, Quaternion.identity);
        //    //prefab.transform.parent = transform;

        //    NetworkServer.Spawn(prefab);
        //}

    }


}
