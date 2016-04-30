using UnityEngine;
using System.Collections;

public class coinScript : MonoBehaviour {

	private AudioSource audio;
	public AudioClip collected;
	void Awake () {
		audio = GetComponent<AudioSource> ();
	}

	void Update()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "playerTag") {
			audio.Play();
			Destroy (gameObject);
			Score.instance.scoring();
		}

	}
}
