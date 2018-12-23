using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// scene manager

public class UI : MonoBehaviour {


	public float temp;
	public float heatLimit = 1000f;
	// public float score = 0f;
	// public Text scoreText;
	public Text tempText;
	
	void Update () {
		tempText.text = "Jet Pack Temperature: " + temp;


		if(temp <= 1){
			temp = 1;
		}

		if(temp >= heatLimit){
			Explode();
		}

	}
	void Explode(){
		Debug.Log("BOOM!");
		Score.score = 0f;
		SceneManager.LoadScene("SampleScene");
		// reload scene
	}
	
	public void Heat(){
		temp++;
	}

	public void Cool(){
		temp--;
	}

}
