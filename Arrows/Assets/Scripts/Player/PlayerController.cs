using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{

    public float moveSpeed;
    private Vector3 dir;
    private float phoneAcceleration = 3.2f;
    private Rigidbody rb;

    public GameObject bombPrefab;
    public Transform bombSpawn;
    public GameObject shootParticle;
    public GameObject fullCanon;
    public GameObject Canon;

    public float canonCooldown;
    private bool isTimerActive;
    private float timer;
    private float timerTwo;

    public float canonForce;
    private float rotateSpeed = 30.0f;

    private float t = 0;

    [SyncVar]
    Vector3 realPosition = Vector3.zero;
    [SyncVar]
    Quaternion realRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GameObject.Find("Player 1") == null)
        {
            gameObject.name = "Player 1";
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            gameObject.name = "Player 2";
        }

    }

    void Update()
    {
        t = t + 0.01f;
        fullCanon.transform.rotation = Quaternion.Euler(0, 0, 90 * t);

        if (isLocalPlayer)
        {
            realPosition = transform.position;
            realRotation = transform.rotation;
            CmdSync(transform.position, transform.rotation);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, realPosition, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, Time.deltaTime);
        }
       

        if (isTimerActive)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            //Canon.GetComponent<Renderer>().material.color = new Color(0,0.99f,0.28f,1);
            Canon.GetComponent<Renderer>().material.color = Color.red;
            timer = 0;
        } if (timer > 0)
        {
            //Canon.GetComponent<Renderer>().material.color = new Color(0.95f,0,0,1);
            Canon.GetComponent<Renderer>().material.color = Color.green;
        }

        

#if UNITY_ANDROID

        //Phone Movement

        float Horizontal = Input.acceleration.x;
        float Vertical = Input.acceleration.y;

        if (Horizontal < -0.2 || Horizontal > 0.2 || Vertical < -0.2 || Vertical > 0.2)
        {            
            Vector3 movement = new Vector3(Horizontal, Vertical, 0);            
            rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * moveSpeed);
        }

        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }

        
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary && canonForce < 10)
            {
                canonForce += 0.1f;

            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Debug.Log(canonForce);
                ShootBoomb();
            }

        }

        //if (Input.touchCount == 1)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    // Handle finger movements based on touch phase.
        //    switch (touch.phase)
        //    {
                
        //        case TouchPhase.Began:                    

        //            break;

        //        // Determine direction by comparing the current touch position with the initial one.
        //        case TouchPhase.Moved:
        //            //direction = touch.position - startPos;
                    
        //            break;

        //        // Report that a direction has been chosen when the finger is lifted.
        //        case TouchPhase.Ended:
        //            ShootBoomb();
        //            break;
        //    }
        //} 
  
#else

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed);
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rb.MovePosition(transform.position - transform.right * Time.deltaTime * moveSpeed);
        }


        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            rb.MovePosition(transform.position + transform.up * Time.deltaTime * moveSpeed);
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            rb.MovePosition(transform.position - transform.up * Time.deltaTime * moveSpeed);
        }

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(canonForce);
            ShootBoomb();
            canonForce = 6;
        }

        if (Input.GetKey("space"))
        {
            if (canonForce < 10)
                canonForce += 0.1f;
        }

#endif

    }

    [Command]
    void CmdFire()
    {

        var bomb = (GameObject)Instantiate(
            bombPrefab,
            bombSpawn.position,
            bombSpawn.rotation);
        
        bomb.GetComponent<Rigidbody>().velocity = bombSpawn.transform.forward * canonForce;

        NetworkServer.Spawn(bomb);

        var p1 = (GameObject)Instantiate(
            shootParticle,
            bombSpawn.position,
            bombSpawn.rotation);

        NetworkServer.Spawn(p1);

        bomb.GetComponent<BombController>().CmdExplodeBomb();

    }

    public void ShootBoomb()
    {
        if (timer > 0)
            return;

        isTimerActive = false;

        CmdFire();

        timer = canonCooldown;

        isTimerActive = true;
    }

    [Command]
    void CmdSync(Vector3 position, Quaternion rotation)
    {
        realPosition = position;
        realRotation = rotation;
    }

}
