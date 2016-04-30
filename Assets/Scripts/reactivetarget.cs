using UnityEngine;
using System.Collections;
public class reactivetarget : MonoBehaviour {

	public GameObject money;
	private int counter;
	public float t = 0f;
	private bool status;

	void Update()
	{

	}

	private IEnumerator Die() {
		Destroy(this.gameObject);
		counter = Random.Range (1,10);

		if (counter % 3 == 0) 
		{
			GameObject ml = Instantiate (money, gameObject.transform.position, Quaternion.identity) as GameObject;//destructionPrefab;
			Destroy(ml, 10);
		}
		yield return new WaitForSeconds(3.0f);
	}
	
	public void ReactToHit() {

		wanderingAI behavior = GetComponent<wanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine (Die ());
	}
}
