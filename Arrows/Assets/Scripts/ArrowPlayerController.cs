using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ArrowPlayerController : NetworkBehaviour
{

    public float moveSpeed;
    private Vector3 dir;

    private Rigidbody rb;

    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    //public GameObject shootParticle;

    public float shootCooldown;
    private bool isTimerActive;
    private float timer;

    public float arrowForce;

    public bool canMoveBlocks;

    public override void OnStartLocalPlayer()
    {
        GetComponent<ArrowPlayerController>().enabled = true;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        gameObject.name = "Player Local";
    }

    void Start()
    {
        //canMoveBlocks = false;
        rb = GetComponent<Rigidbody>();
        //if (GameObject.Find("Player 1") == null)
        //{
        //    gameObject.name = "Player 1";
        //    gameObject.GetComponent<Renderer>().material.color = Color.red;
        //}
        //else
        //{
        //    gameObject.GetComponent<Renderer>().material.color = Color.blue;
        //    gameObject.name = "Player 2";
        //}

    }

    void Update()
    {


        if (isTimerActive)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            //Canon.GetComponent<Renderer>().material.color = Color.red;
            timer = 0;
        } if (timer > 0)
        {

            //Canon.GetComponent<Renderer>().material.color = Color.green;
        }


        rb.velocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {

            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, 0f);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, 0f, 0f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }


        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            rb.velocity = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            rb.velocity = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootArrow();
            arrowForce = 6;
        }

        //if (Input.GetKey("space"))
        //{
        //    if (canonForce < 10)
        //        canonForce += 0.1f;
        //}

    }

    [Command]
    void CmdShoot()
    {

        var arrow = (GameObject)Instantiate(
            arrowPrefab,
            arrowSpawn.position,
            arrowSpawn.rotation);

        arrow.GetComponent<Rigidbody>().velocity = transform.forward * arrowForce;

        NetworkServer.Spawn(arrow);

        //var p1 = (GameObject)Instantiate(
        //    shootParticle,
        //    bombSpawn.position,
        //    bombSpawn.rotation);

        //NetworkServer.Spawn(p1);

        //bomb.GetComponent<BombController>().CmdExplodeBomb();

    }

    public void ShootArrow()
    {
        if (timer > 0)
            return;

        isTimerActive = false;

        CmdShoot();

        timer = shootCooldown;

        isTimerActive = true;
    }

    [Command]
    public void CmdEndGame()
    {
        //NetworkManager.singleton.ServerChangeScene("Arrows");

    }

}
