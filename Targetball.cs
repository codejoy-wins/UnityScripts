using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	// Having trouble increasing the score

public class Targetball : MonoBehaviour {

	public float health = 100f;
	public GameObject middle;

	// Use this for initialization
	void Start () {
		// Score cat = middle.GetComponent<Score>();
		// cat.IncreaseScore(5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Die();
		}
	}

	public void TakeDamage(float amount){
		health -= amount;
	}

	void Die(){
		Destroy(gameObject);
		// how do I change the score right here?
		// can I log what hit me??
	}
}
