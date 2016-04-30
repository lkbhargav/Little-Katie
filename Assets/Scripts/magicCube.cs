using UnityEngine;
using System.Collections;

public class magicCube : MonoBehaviour {

	public GameObject youwin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("playerTag")) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			if (Score.instance.count >= 25) {
				Score.instance.sTimerStatus = false;
			}
			Application.LoadLevel(2);
		}
	}
}










