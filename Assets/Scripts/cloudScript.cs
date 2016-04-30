using UnityEngine;
using System.Collections;

public class cloudScript : MonoBehaviour {

		public GameObject applePrefab;
		
		public float speed = 4f;
		
		public float leftAndRightEdge = 12f;
		
		public float chanceToChangeDirections = 0.1f;
		
		//public float secondsBetweenChestDrops = 4f;

	public int i = 2;

	// Use this for initialization
	void Start () {
		InvokeRepeating("DropChest", 4f, 10f);
	}

	void DropChest()
	{
		GameObject Chest = Instantiate(applePrefab) as GameObject;
		Chest.transform.position = transform.position;
		Destroy (Chest,15);
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		i = Random.Range (1,10);
		if (i % 4 == 0) {
			pos.x += speed * Time.deltaTime;
		} else {
			pos.z += speed * Time.deltaTime;
		}
		transform.position = pos;
				
		if (pos.x < -leftAndRightEdge)
			speed = Mathf.Abs (speed);
		else if (pos.x > leftAndRightEdge)
			speed = -Mathf.Abs (speed);

		if (pos.z < -leftAndRightEdge)
			speed = Mathf.Abs (speed);
		else if (pos.z > leftAndRightEdge)
			speed = -Mathf.Abs (speed);
	}

}
