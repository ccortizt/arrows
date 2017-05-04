using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {

    public const int maxHealth = 5;

    [SyncVar]
    public int currentHealth = maxHealth;
    
    [SerializeField] 
    Text healthLabel;

    [SerializeField]
    Text healthLabel2;
    
    [Command]
    public void CmdTakeDamage(int amount)
    {
        Debug.Log(gameObject.name + " " + currentHealth);
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            EndGame();
        }

        healthLabel.text = currentHealth.ToString();
        healthLabel2.text = currentHealth.ToString();
       
    }

    [ClientRpc]
    public void RpcTakeDamage(int amount)
    {
        Debug.Log(gameObject.name + " " + currentHealth);
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            EndGame();
        }

        healthLabel.text = currentHealth.ToString();
        healthLabel2.text = currentHealth.ToString();

    }

    private void EndGame()
    {
        gameObject.GetComponent<ArrowPlayerController>().CmdEndGame();
        //var EndHud = (GameObject)Instantiate(Resources.Load("Prefabs/EndGameGUI"), Vector3.zero, Quaternion.identity);
        //EndHud.name = "EndGameGUI";
        //if (gameObject.name.Contains("1"))
        //    EndHud.transform.FindChild("Panel/Lose").gameObject.SetActive(true);
        //else
        //    EndHud.transform.FindChild("Panel/Win").gameObject.SetActive(true);

        //var objects = GameObject.FindGameObjectsWithTag("Player");
        //foreach (var obj in objects)
        //{
        //    obj.SetActive(false);
        //}
    }

   
}
