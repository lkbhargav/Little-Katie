using UnityEngine;
using System.Collections;

public class devilScript : MonoBehaviour {


	void Update()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "playerTag") {
			Destroy (gameObject);
			Score.instance.negating();
		}
	}
}
