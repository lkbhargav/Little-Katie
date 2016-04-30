using UnityEngine;
using System.Collections;

public class chestScript : MonoBehaviour {

	public GameObject particle;
	public GameObject coin;
	public GameObject devil;
	public GameObject life;
	public AudioClip mySound;
	private AudioSource source;
	private int coins;
	public GameObject destructionPrefab;

	void Awake () {
		
		source = GetComponent<AudioSource>();
		
	}

	public void killed()
	{
		coins = Random.Range (1,15);
		GameObject d = Instantiate (destructionPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;//destructionPrefab;


		GameObject pe = Instantiate (particle, gameObject.transform.position, Quaternion.identity) as GameObject;
		Destroy (pe, 5);

		Vector3 pos = transform.position;
		pos.y = 2f;
		transform.position = pos;
		if (coins % 5 == 0) {
			GameObject de = Instantiate (devil, gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy(de,30);
		}else if(coins%9 == 0)
		{
			Debug.Log("Life Pack");
			GameObject ld = Instantiate (life, gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy(ld,30);
		}
		else {
			GameObject co = Instantiate (coin, gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy(co,30);
		}
		Destroy (gameObject);
		Destroy (d,2);
	}
}