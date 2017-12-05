using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
	public AudioSource Effects;
	public static AudioHandler instance;
	public AudioClip Gun;
	public AudioClip Coin;

	// Use this for initialization
	void Start () {
	}
	public void PlayerShootGun(){
		Effects.PlayOneShot (Gun);
	}
	public void Coins(){
		Effects.PlayOneShot (Coin);
	}

	public void Awake(){
		instance = this;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
