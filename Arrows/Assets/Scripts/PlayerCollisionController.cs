using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCollisionController : NetworkBehaviour
{

    private float BOX_AREA = 1f;
    public void OnCollisionEnter(Collision coll)
    {
        
        if (coll.gameObject.tag.Contains("DestructibleBlock") & GetComponent<ArrowPlayerController>().CanMoveBlocks)
        {
            
            if (coll.gameObject.GetComponent<BlockController>().CanMoveInDirection(coll.gameObject.transform.position + transform.forward, BOX_AREA,transform.forward))
            {
               
                coll.gameObject.GetComponent<BlockController>().CmdMoveTo(coll.gameObject.transform.position + transform.forward);
               
                
            }
        }


        if (coll.gameObject.name.Contains("Speed+"))
        {
            Debug.LogError("Speed+"+ GetComponent<ArrowPlayerController>().MoveSpeed);
            GetComponent<ArrowPlayerController>().MoveSpeed += GetComponent<ArrowPlayerController>().MoveSpeed * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();

            Debug.LogError("Speed+" + GetComponent<ArrowPlayerController>().MoveSpeed);
        }

        if (coll.gameObject.name.Contains("Speed-"))
        {
            Debug.LogError("Speed-" + GetComponent<ArrowPlayerController>().MoveSpeed);
            GetComponent<ArrowPlayerController>().MoveSpeed -= GetComponent<ArrowPlayerController>().MoveSpeed * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
            Debug.LogError("Speed-" + GetComponent<ArrowPlayerController>().MoveSpeed);
        }

        if (coll.gameObject.name.Contains("Cooldown+"))
        {
            Debug.LogError("Cooldown+" + GetComponent<ArrowPlayerController>().ShootCooldown);
            GetComponent<ArrowPlayerController>().ShootCooldown += GetComponent<ArrowPlayerController>().ShootCooldown * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
            Debug.LogError("Cooldown+" + GetComponent<ArrowPlayerController>().ShootCooldown);
        }

        if (coll.gameObject.name.Contains("Cooldown-"))
        {
            Debug.LogError("Cooldown-" + GetComponent<ArrowPlayerController>().ShootCooldown);
            GetComponent<ArrowPlayerController>().ShootCooldown -= GetComponent<ArrowPlayerController>().ShootCooldown * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
            Debug.LogError("Cooldown-" + GetComponent<ArrowPlayerController>().ShootCooldown);
        }

        if (coll.gameObject.name.Contains("SpeedArrow+"))
        {
            Debug.LogError("Force+" + GetComponent<ArrowPlayerController>().ArrowForce);
            GetComponent<ArrowPlayerController>().ArrowForce += GetComponent<ArrowPlayerController>().ArrowForce * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
            Debug.LogError("Force+" + GetComponent<ArrowPlayerController>().ArrowForce);
        }

        if (coll.gameObject.name.Contains("SpeedArrow-"))
        {
            Debug.LogError("Force-" + GetComponent<ArrowPlayerController>().ArrowForce);
            GetComponent<ArrowPlayerController>().ArrowForce -= GetComponent<ArrowPlayerController>().ArrowForce * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
            Debug.LogError("Force-" + GetComponent<ArrowPlayerController>().ArrowForce);
        }

        if (coll.gameObject.name.Contains("MoveBlocks"))
        {
            GetComponent<ArrowPlayerController>().CanMoveBlocks = true;
            Debug.LogError(GetComponent<ArrowPlayerController>().CanMoveBlocks);
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
            Debug.LogError("moveblocks" + GetComponent<ArrowPlayerController>().CanMoveBlocks);
        }

        if (coll.gameObject.name.Contains("ExplosiveArrow"))
        {
            //GetComponent<ArrowPlayerController>().explosive...
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

    }  

}
