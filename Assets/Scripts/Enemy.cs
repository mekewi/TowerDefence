using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int hitRange;
	public bool startLookToTarget;
	public Transform centerOfRotate;
	public float rotateSpeed;
	public GameObject BulletObject;
	public Transform FirePosition;
	public float fireRate;
	public float fireCountDown;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("updateTarget",0, 0.5f);
	}
	public void updateTarget(){
		float DistanceBetweenPlayer = Vector3.Distance (transform.position, GamePlayBusses.instance.playerObject.transform.position);
		if (DistanceBetweenPlayer <= hitRange) {
			startLookToTarget = true;
		} else {
			startLookToTarget = false;
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, hitRange);
	}
	// Update is called once per frame
	void Update () {
		if (startLookToTarget) {
			Vector3 dir = GamePlayBusses.instance.playerObject.transform.position - transform.position;
			Quaternion RotateToPosition = Quaternion.LookRotation (dir);
			Vector3 rotation = Quaternion.Lerp (centerOfRotate.rotation, RotateToPosition, Time.deltaTime * rotateSpeed).eulerAngles;
			centerOfRotate.rotation = Quaternion.Euler (rotation);
			if (fireCountDown <= 0f) {
				Shoot ();
				fireCountDown = 1f / fireRate;
			}
			fireCountDown -= Time.deltaTime;
		}
	}
	public void Shoot(){
		Debug.Log ("Fireee");
		GameObject bullet = Instantiate (BulletObject,FirePosition.position,FirePosition.rotation);
		Bullet bulletScript = bullet.GetComponent<Bullet> ();
		bulletScript.Seek (GamePlayBusses.instance.playerObject.transform);
		AudioHandler.instance.PlayerShootGun ();

		if (bulletScript != null) {
			
		}
	}
}
