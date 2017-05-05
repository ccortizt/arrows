using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCollisionController : NetworkBehaviour
{

    private float BOX_AREA = 1f;
    public void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.name.Contains("dblock") & GetComponent<ArrowPlayerController>().CanMoveBlocks)
        {
            if (coll.gameObject.GetComponent<BlockController>().CanMoveInDirection(coll.gameObject.transform.position + transform.forward, BOX_AREA))
            {
                coll.gameObject.GetComponent<BlockController>().CmdMoveTo(coll.gameObject.transform.position + transform.forward);
            }
        }


        if (coll.gameObject.name.Contains("Speed+"))
        {
            GetComponent<ArrowPlayerController>().MoveSpeed -= GetComponent<ArrowPlayerController>().MoveSpeed * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

        if (coll.gameObject.name.Contains("Speed-"))
        {
            GetComponent<ArrowPlayerController>().MoveSpeed += GetComponent<ArrowPlayerController>().MoveSpeed * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

        if (coll.gameObject.name.Contains("Cooldown+"))
        {
            GetComponent<ArrowPlayerController>().ShootCooldown += GetComponent<ArrowPlayerController>().ShootCooldown * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

        if (coll.gameObject.name.Contains("Cooldown-"))
        {
            GetComponent<ArrowPlayerController>().ShootCooldown -= GetComponent<ArrowPlayerController>().ShootCooldown * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

        if (coll.gameObject.name.Contains("SpeedArrow+"))
        {
            GetComponent<ArrowPlayerController>().ArrowForce += GetComponent<ArrowPlayerController>().ArrowForce * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

        if (coll.gameObject.name.Contains("SpeedArrow-"))
        {
            GetComponent<ArrowPlayerController>().ArrowForce -= GetComponent<ArrowPlayerController>().ArrowForce * 0.25f;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
        }

        if (coll.gameObject.name.Contains("MoveBlocks"))
        {
            GetComponent<ArrowPlayerController>().CanMoveBlocks = true;
            if (isClient)
                coll.gameObject.GetComponent<PowerUpController>().RpcDestroyPower();
            else 
                coll.gameObject.GetComponent<PowerUpController>().CmdDestroyPower();
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
