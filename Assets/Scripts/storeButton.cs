using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class storeButton : MonoBehaviour {

	public int m;
	public int c;

	public void buyCoin()
	{
		m = Score.instance.money;
		if (m >= 500) {
			Score.instance.buyCoin();
		}
	}

	public void buyLife()
	{
		m = Score.instance.money;
		if (m >= 150) {
			m -= 150;
			Score.instance.addLife();
		}
	}
}
