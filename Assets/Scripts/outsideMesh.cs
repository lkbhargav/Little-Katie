using UnityEngine;
using System.Collections;

public class outsideMesh : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("playerTag")) {
			Debug.Log("dead");
			Score.instance.dead();
		}
	}
}
