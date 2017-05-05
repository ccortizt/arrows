using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerSpawner : NetworkBehaviour
{

    [SerializeField]
    GameObject prefabMoveBlocks;

    [SerializeField]
    GameObject prefabExplosive;

    [SerializeField]
    GameObject prefabSpeedPlus;

    [SerializeField]
    GameObject prefabSpeedMinus;

    [SerializeField]
    GameObject prefabCooldownPlus;

    [SerializeField]
    GameObject prefabCooldownMinus;

    [SerializeField]
    GameObject prefabArrowPlus;

    [SerializeField]
    GameObject prefabArrowMinus;

    [Command]
    public void CmdSpawnRandomPower()
    {

        float prob = Random.Range(0, 10);

        if (Random.Range(0, 10) <= 5)
        {
            if (prob > 0 && prob <= 1)
            {
                GameObject prefab = Instantiate(prefabSpeedMinus, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 1 && prob <= 2)
            {
                GameObject prefab = Instantiate(prefabSpeedPlus, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 2 && prob <= 3)
            {
                GameObject prefab = Instantiate(prefabCooldownMinus, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 3 && prob <= 4)
            {
                GameObject prefab = Instantiate(prefabCooldownPlus, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 4 && prob <= 5)
            {
                GameObject prefab = Instantiate(prefabMoveBlocks, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 5 && prob <= 6)
            {
                GameObject prefab = Instantiate(prefabExplosive, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 6 && prob <= 7)
            {
                GameObject prefab = Instantiate(prefabArrowPlus, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            if (prob > 7 && prob <= 8)
            {
                GameObject prefab = Instantiate(prefabArrowMinus, transform.position, Quaternion.identity);
                NetworkServer.Spawn(prefab);
            }

            
        }



    }


}
