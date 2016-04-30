using UnityEngine;
using System.Collections;

public class cloudScript2 : MonoBehaviour {

	public GameObject chestPrefab;

	public float rightAndLeftEdge = 16f;

	private int i;

	private float speed = 3f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Movement",2f, 10f);
	}

	void Movement()
	{
		Vector3 pos = transform.position;
		pos.x = Random.Range (-14,14);
		pos.z = Random.Range (-14,14);
		transform.position = pos;
		GameObject chest = Instantiate(chestPrefab) as GameObject;
		Destroy (chest,15);
		chest.transform.position = transform.position;

	}

	void Update()
	{
		Vector3 pos = transform.position;
		i = Random.Range (1,10);
		if (i % 4 == 0) {
			pos.x += speed * Time.deltaTime;
		} else {
			pos.z += speed * Time.deltaTime;
		}
		transform.position = pos;
	}
}