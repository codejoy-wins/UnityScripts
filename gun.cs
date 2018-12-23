using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

	// my gun is animating in the direction I'm clicking instead of where the actual center is.

	public AudioSource aud;
	public AudioSource aud2;
	public Animation ani;

	public float fireRate = .5f;
	public float nextFire = 0f;
	public GameObject shotgun;
	public GameObject machinegun;
	public bool gunner = true;
	public Camera cam;
	public float range = 2000f;
	public float AkDamage = 1f;
	public float ShotgunDamage = 10f;

	// public Animation ani;  what a catastrophe!

	// add timer.  add bouncy ball
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("mouse 0") && Time.time > nextFire){
			// Debug.Log("auto firing");
			nextFire = Time.time + fireRate;
			if(gunner == true){
				Shoot();
				// ani.Play(); no fully auto anim yet
				
			}
		}
		if(gunner == false && Input.GetKeyDown("mouse 0")){
				Shotgun();
				ani.Play("Pump");
				Debug.Log(transform.rotation.x);
				//fix rotation?
			}

		if(Input.GetKeyDown("y") || Input.GetKeyDown("q")|| Input.GetKeyDown("e")){
			ChangeWeapon();
		}
	}

	void Shoot(){
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);
			Targetball target = hit.transform.GetComponent<Targetball>();
			// Scorekeeper score = hit.transform.GetComponent<Scorekeeper>();

			if(target != null){
				Debug.Log("target is live");
				target.TakeDamage(AkDamage);
				Score.score+=AkDamage;
				// score.IncreaseScore(AKDamage);
			}
		}
		// Debug.Log("aking");
		aud.Play();
		// ani.Play("Recoil"); 
	}

	void Shotgun(){
		aud2.Play();
		Debug.Log("boom shotty");
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);
			Targetball target = hit.transform.GetComponent<Targetball>();
			if(target != null){
				Debug.Log("target is live");
				target.TakeDamage(ShotgunDamage);
				Score.score+=ShotgunDamage;
			}
		}
	}

	void ChangeWeapon(){
		Debug.Log("changing weapons");

		if(gunner == true){
			shotgun.SetActive(true);
			machinegun.SetActive(false);
			gunner = false;
		}else{
			shotgun.SetActive(false);
			machinegun.SetActive(true);
			gunner = true;
		}
	}
}
