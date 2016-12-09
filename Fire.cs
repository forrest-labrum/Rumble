using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Fire : NetworkBehaviour
{
    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float Bullet_Forward_Force;

	void Start ()
    {
	
	}

    GameObject Temporary_Bullet_Handler;

    void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.parent = Bullet_Emitter.transform;
            Physics.IgnoreCollision(Temporary_Bullet_Handler.GetComponent<SphereCollider>(), Bullet_Emitter.transform.parent.gameObject.GetComponent<BoxCollider>());

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            float vert = Input.GetAxisRaw("Vertical");
            float hor = Input.GetAxisRaw("Horizontal");

            Temporary_RigidBody.AddForce(new Vector3(hor, 0, vert == 0 && hor == 0 ? -1 : vert) * Bullet_Forward_Force);
        }
    }

    
}