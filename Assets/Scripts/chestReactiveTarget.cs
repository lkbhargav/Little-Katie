using UnityEngine;
using System.Collections;

public class chestReactiveTarget : MonoBehaviour {

	public void ReactToHit() {
		
		chestScript behavior = GetComponent<chestScript>();
		if (behavior != null) {
			behavior.killed();
		}
	}
}
