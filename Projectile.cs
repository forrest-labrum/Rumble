using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Projectile : NetworkBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider collisionInfo)
    {
        Destroy(gameObject);
    }
}
