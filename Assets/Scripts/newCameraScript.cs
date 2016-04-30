using UnityEngine;
using System.Collections;

// Idea is to move capsule (vertical, horizontal, diagonal) according to captured mouse input data
// First person character roughly equal to camera
// - Create a capsule.
// - Add the MouseLook script to the capsule.
//   -> Set the mouse look to use MouseX. (You want to only turn character but not tilt it)
// - Add FPSInput script to the capsule
//     CharacterController component will be automatically added.
//
// - Create a camera. Make the camera a child of the capsule. Position in the head and reset the rotation.
// - Add a MouseLook script to the camera.
//  

[AddComponentMenu("Control Script/Mouse Look")]
// Click "Add Component" button to see result
public class newCameraScript : MonoBehaviour {
	public enum RotationAxes {
		// data structure to help remember while coding
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;
	
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;
	
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;
	
	private float _rotationX = 0;
	
	void Start() {
		// keep rigid body at stable rotation
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
			body.freezeRotation = true;
	}
	
	void Update() {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			
			transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
			// rotation around a coordinate system: example: rotation around X coordinate by angle [some value]
		}
		else {
			float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;
			
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
			//Clamp keeps values with defined range
			
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}
