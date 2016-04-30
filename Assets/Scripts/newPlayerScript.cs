using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;


[RequireComponent(typeof(CharacterController))]
// not absolutely needed, good programming practice
[AddComponentMenu("Control Script/FPS Input")]

public class newPlayerScript : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = -9.8f;
	public bool canJump = true;
	private int jumpCount;
	public GameObject bs1;
	public GameObject bs2;
	public GameObject bs3;
	private float timeHealth;
	private CharacterController _charController;
	private bool status = true;
	private float h1;
	// Different game objects might want to use CharacterController
	
	void Start() {
		_charController = GetComponent<CharacterController>();
	}
	
	void Update() {
		timeHealth += Time.deltaTime;
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		// Don't want diagonal movement going to fast
		
		movement.y = gravity;
		// Controls tilting. Set gravity to "0" if you want character to fly

		if (Input.GetKeyDown (KeyCode.Space) && canJump == true) {
			canJump = false;
			jumpCount = 20;
		}
		
		if (jumpCount > 0) {
			movement.y+=jumpCount;
			jumpCount--;
		}

		Vector3 pos = transform.position;
		if (pos.y < 1 && jumpCount == 0) {
			canJump =true;
		}
		
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		_charController.Move (movement);
	}

	void OnTriggerEnter(Collider other)
	{
		if(status)
		{
			h1 = timeHealth;
			status = false;
		}

		if (other.GetComponent<Collider>().tag == "enemy") {
			Score.instance.decrementLife(1*(timeHealth - h1));
			bloodStains(true);
		}
		
		if (other.GetComponent<Collider>().tag == "enemy2") {
			Score.instance.decrementLife(2*(timeHealth - h1));
			bloodStains(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		float n = 100f;
		while(n > 0)
		{
			n -= Time.deltaTime;
		}
		if (other.GetComponent<Collider>().tag == "enemy") {
			Score.instance.decrementLife(1);
			bloodStains(false);
		}
		
		if (other.GetComponent<Collider>().tag == "enemy2") {
			Score.instance.decrementLife(2);
			bloodStains(false);
		}
		status = true;
	}

	void bloodStains(bool blood)
	{
		bs1.SetActive (blood);
		bs2.SetActive (blood);
		bs3.SetActive (blood);
	}

}
