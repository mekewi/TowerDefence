using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform target;
	public float speed ; 
	// Use this for initialization
	void Start () {
		
	}
	public void Seek(Transform _target){
		target = _target;
	}
	// Update is called once per frame
	void Update () {
		if (target == null) {
			Destroy (gameObject);
			return;
		}
		Vector3 followDir = target.position - transform.position;
		float distance = speed * Time.deltaTime;
		if (followDir.magnitude <= distance) {
			HitPlayer ();
//			return;
		}
		transform.Translate (followDir.normalized * distance, Space.World);
	}
	public void HitPlayer(){
//		Destroy (gameObject);
	}
}
