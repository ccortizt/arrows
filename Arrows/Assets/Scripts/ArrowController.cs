using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ArrowController : NetworkBehaviour
{


    public ParticleSystem hurtParticle;
    public float explodeDelay;
    public float explodeArea;

    void Start()
    {
        //hurtParticle = gameObject.GetComponent<ParticleSystem>();
    }

    public void OnCollisionEnter(Collision coll)
    {
        Debug.Log("collision" + coll.gameObject.name.Contains("Player"));
        if (coll.gameObject.name.Contains("Player"))
        {
           
            if (isClient)
            {
                coll.gameObject.GetComponent<PlayerHealth>().RpcTakeDamage(1);
            }
            else
            {
                coll.gameObject.GetComponent<PlayerHealth>().CmdTakeDamage(1);
            }
        }

        if (coll.gameObject.name.Contains("dblock"))
        {
            coll.gameObject.GetComponent<BlockController>().CmdDestroyBlock();
        }

        Debug.Log(coll.gameObject.name);
        if (isClient)
            RpcDestroyArrow();
        else
            CmdDestroyArrow();

    }


    [Command]
    public void CmdDestroyArrow()
    {
        Destroy(gameObject);

    }


    [ClientRpc]
    public void RpcDestroyArrow()
    {
        Destroy(gameObject);

    }

    public IEnumerator waitExplode()
    {
        yield return new WaitForSeconds(explodeDelay);
        Destroy(gameObject);
    }

    

}
