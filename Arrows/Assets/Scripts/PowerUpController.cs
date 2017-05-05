using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUpController : NetworkBehaviour
{

    [Command]
    public void CmdDestroyPower()
    {
        Destroy(gameObject);
    }

    [ClientRpc]
    public void RpcDestroyPower()
    {
        Destroy(gameObject);
    }
}
