using UnityEngine;
using System.Collections;

public class sm : MonoBehaviour {
	public GameObject title;

	// Update is called once per frame
	void FixedUpdate () {
		int n;
		n = Random.Range (1,10);
		if (n % 9 == 0) {
			title.SetActive(false);
		} else {
			title.SetActive(true);
		}
	}
}
