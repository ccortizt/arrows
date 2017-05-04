using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BombController : NetworkBehaviour {


    public ParticleSystem hurtParticle;
    public float explodeDelay;
    public float explodeArea;

    void Start()
    {
        hurtParticle = gameObject.GetComponent<ParticleSystem>();
    }
    
    public void OnDestroy()
    {
        Collider[] nearObjects = Physics.OverlapSphere(gameObject.transform.position, explodeArea);

        foreach (Collider item in nearObjects)
        {

            if (item.gameObject.name.Contains("Player"))
            {
                
                var hit = item.gameObject;
                //print("hurt!! " + item.gameObject.name +" " +item.gameObject.GetInstanceID() );
                var health = hit.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    //health.TakeDamage(1);
                }
            }
                
        }

        hurtParticle.Play();       
        
    }


    [Command]
    public void CmdExplodeBomb()
    {
        Destroy(gameObject, explodeDelay);
        //StartCoroutine("waitExplode");
    }

    public IEnumerator waitExplode()
    {
        yield return new WaitForSeconds(explodeDelay);
        Destroy(gameObject);
    }
   
}
