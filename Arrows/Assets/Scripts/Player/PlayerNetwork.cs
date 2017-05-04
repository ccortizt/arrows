using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerNetwork : NetworkBehaviour {

    public override void OnStartLocalPlayer()
    {
        GetComponent<PlayerController>().enabled = true;
       
        GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    
}
