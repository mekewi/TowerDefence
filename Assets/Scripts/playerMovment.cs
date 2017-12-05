using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour {
	public Rigidbody PlayerRigidBody;
	public Transform playerTarget;
	public float ForceSpeed;
	// Use this for initialization
	void Awake () {
		PlayerRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartPlay(){
		PlayerRigidBody.useGravity = true;
	}
	void FixedUpdate () {
		playerTarget.position = transform.position;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if (moveVertical > 0 || moveVertical < 0) {
			PlayerRigidBody.AddForce ((playerTarget.forward*moveVertical) * ForceSpeed);
		}
		if (moveHorizontal > 0 || moveHorizontal < 0) {
			PlayerRigidBody.AddForce ((playerTarget.right*moveHorizontal) * ForceSpeed);
		}
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag.Equals ("Bullet")) {
			Destroy (collision.gameObject);
			GamePlayBusses.instance.HealthAmount--;
//			float amount = 
			GetComponent<MeshRenderer> ().materials[0].color = new Color (1, GamePlayBusses.instance.HealthAmount / GamePlayBusses.instance.Health, GamePlayBusses.instance.HealthAmount / GamePlayBusses.instance.Health);
		}
		if (collision.gameObject.tag.Equals ("Coins")) {
			Destroy (collision.gameObject);
			GamePlayBusses.instance.CollectedCoins++;
			AudioHandler.instance.Coins ();

		}

	}
	void OnTriggerEnter(Collider triggerObject) {
	}

}
