using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

	public Text ScoreText;
	public static float score = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score: " + score;
	}

	public void IncreaseScore(float amount){
		score += amount;
	}
}
