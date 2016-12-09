using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour
{

    new Rigidbody rigidbody;
    Vector3 velocity;



    public bool grounded = true;
    public int jumpSpeed = 1;
    public int health = 100;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * 20;
        
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public override void OnStartLocalPlayer()
    {
        gameObject.GetComponentInChildren<Camera>().enabled = true;
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Projectile")
        {
            health -= 5;
        }
    }
}