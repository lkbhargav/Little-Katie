using UnityEngine;
using System.Collections;

public class wanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	NavMeshAgent agent;
	private GameObject object1;
	Vector3 destination;
	private bool _alive;
	
	void Start() {
		_alive = true;
		agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;
	}

	void FixedUpdate()
	{
		if (_alive) {
			
			object1 = GameObject.FindWithTag("playerTag") as GameObject;
			if(Score.instance.count <= 10)
			{
				agent.speed = 1.5f;
			}
			else if(Score.instance.count > 10 && Score.instance.count <= 17)
			{
				agent.speed = 2.0f;
			}
			else
			{
				agent.speed = 3.0f;
			}
			if (Vector3.Distance (destination, object1.transform.position) > 30.0f) {
				destination = object1.transform.position;
				agent.destination = destination;
			}
			if (object1 != null)
				agent.SetDestination (object1.transform.position);
			else
				Debug.Log ("Not found!");
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}