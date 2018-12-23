using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class movement : MonoBehaviour {

	public CharacterController cc;
	public float horizontalVelocity = 0f;
	public float verticalVelocity =0f;
	public float forwardVelocity =0f;
	public float mouseSensitivity = 7f;
	public Camera cam;
	private bool isGrounded2;
	public float velocity = 10f;
	public float jumpPower = 20f;
	public float jetPackPower = 1f;
	public float evade = 5f;
	public Text tx;
	public GameObject gun;
	public GameObject xxxp;
	public float range = 3000f;
	public float innerrange = 100f;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {

		// telaport
		if(Input.GetKeyDown("t")){
			Debug.Log("teleport");
			Debug.Log(transform.position.z);
			// transform.position = xxxp.transform.position;
			Teleport();
			// right now I'm teleporting in front of the gun, but later I could teleport to where the gun raycast hits, then I can teleport various distances.

			// transform.forward
		}
	


		isGrounded2 = cc.isGrounded;
		horizontalVelocity = Input.GetAxis("Horizontal") * velocity;
		forwardVelocity = Input.GetAxis("Vertical") * velocity;
		Vector3 speed = new Vector3(horizontalVelocity,verticalVelocity,forwardVelocity);
		speed = transform.rotation * speed;

		if(isGrounded2 == false){
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}

		// use mouse x and y to rotate cam

		// Debug.Log(Input.mousePosition.x);
		float xx = Input.GetAxis("Mouse X") * mouseSensitivity;
		float yy = Input.GetAxis("Mouse Y") * -mouseSensitivity;


		transform.Rotate(0f,xx,0f);
		cam.transform.Rotate(yy,0f,0f);
		gun.transform.Rotate(yy,0f,0f);



		if(Input.GetKey("space")&& isGrounded2 == false){
			// Debug.Log("new jetpack");
			verticalVelocity += jetPackPower;
			tx.GetComponent<UI>().Heat();
		}else if(!Input.GetKey("left shift")){
			tx.GetComponent<UI>().Cool();
		}


		if(Input.GetButtonDown("Jump") && isGrounded2 == true){
			verticalVelocity = 0f;
			Debug.Log("Jumpa");
			verticalVelocity += jumpPower;
		}

		if(Input.GetKey("left shift")){
			tx.GetComponent<UI>().Heat();
			forwardVelocity*= evade;
			horizontalVelocity*= evade;
			speed = new Vector3(horizontalVelocity,verticalVelocity, forwardVelocity);
			speed = transform.rotation * speed;
		}

		if(Input.GetKey("right shift")){
			Debug.Log("ground pound");
			verticalVelocity -= 5f;
			speed = new Vector3(horizontalVelocity,verticalVelocity, forwardVelocity);
			speed = transform.rotation * speed;
		}
		
		cc.Move(speed * Time.deltaTime);

	}

	void Teleport(){
		Debug.Log("last teleport");
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, innerrange)){
			Debug.Log(hit.transform.name);
			transform.position = hit.transform.position + offset;
		}else{
			transform.position = xxxp.transform.position;
		}

		
	}
	void Boost(){
		Debug.Log("last boost"); // charge attack
		// insert charge move here later
		
	}

		//DONE 

	// Jetpack
	// Teleport
	// Change Weapon
	// Gun Sounds
	// Song
	// Terrain
	// UI


		// NOT DONE

	// Story
	// Score
	// Gun Animations
	// Targets
	// AI
	// Restart Level on Engine Explode
	// Charge Attack
	// Platform Trigger  (moving)
}