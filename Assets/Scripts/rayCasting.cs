using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;

public class rayCasting : MonoBehaviour {
	public Texture pointer;
	private Camera _camera;
	//public Gameobject ReactiveTarget; 
	//want to address camera in code
	//attach script to camera
	private Thread t1;
	public AudioClip mySound;
	public AudioClip boxesSound;
	public AudioClip shellFalling;
	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	void Start() {
		_camera = GetComponent<Camera>();
		//want to be able to access other components attached to camera
		Cursor.lockState = CursorLockMode.Locked;
		//two Cursor states: Locked and Unlock
		Cursor.visible = false;
		//Press ESC to bring back cursor
		t1 = new Thread (functionInside){Name = "Thread 1"};
	}
	
	void OnGUI() {
		//every Monobehaviour automatically responds to an OnGUI() method
		//appears on top of 3D screen
		//runs every frame, right after 3D scene rendered
		int size = 18;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.DrawTexture(new Rect(posX, posY, size, size), pointer,ScaleMode.ScaleAndCrop,true,1f);
	}

	private void functionInside()
	{
		if (Input.GetMouseButtonDown (0)) {
			// 0 is value for left mouse
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			//create ray at point using ScreenPointToRay()
			RaycastHit hit;
			//data structure that contains info about what happened
			if (Physics.Raycast (ray, out hit)) {
				//out allows passing more than one value (pass by reference)
				//Raycast puts info into referenced var
				GameObject hitObject = hit.transform.gameObject;
				//retrieve object hit by ay
				reactivetarget target = hitObject.GetComponent<reactivetarget> ();
				chestReactiveTarget chestTarget = hitObject.GetComponent<chestReactiveTarget> ();
				//find ReactiveTarget on object
				if (target != null) {
					source.PlayOneShot(mySound);
					target.ReactToHit ();

					//calls method of target
				} else if (chestTarget != null)
				{
					source.PlayOneShot(boxesSound);
					chestTarget.ReactToHit ();
				}
				else{
					source.PlayOneShot(shellFalling);
				}
			}
		}
	}

	void Update() {
		//keep checking for mouse depress
			functionInside();
	}
}















