using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject youwin;
	public GameObject youlose;
	public GameObject door;
	public Text countt;
	public int count=0;
	private string ct;
	public static Score instance = null;
	public float life = 100f;
	public Image healthBar;
	public Text healthMessage;
	public Text paperMoney;
	public int money;
	public Text extraLife;
	public int lifeCounter;
	public bool sTimerStatus = true;
	private int counter;
	public float stimer;
	public Text showTime;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	public void moneyCollected()
	{
		counter = Random.Range (1,10);
		if (counter % 5 == 0)
			money += 20;
		else
			money += 10;
		string m = money.ToString ();
		paperMoney.text = "x"+money;
	}

	public void decrementLife(float i)
	{
		if (i == 1)
			life -= 0.5f;
		else if(i == 2)
			life -= 1f;

		if (life <= 0) {
			dead();
		}
	}

	public void collectLife()
	{
		if (life < 100) {
			life = Mathf.Min (100, life + 5);
		}
	}

	public void addLife()
	{
		if (life < 100) {
			life = Mathf.Min(100,life+25);
			money -= 150;
		} else {
			if (lifeCounter < 4) {
				lifeCounter++;
				money -= 150;
			}
			extraLife.text = "x" + lifeCounter;
		}

		paperMoney.text = "x"+money;
	}

	public void buyCoin()
	{
		money -= 500;
		scoring ();
		paperMoney.text = "x"+money;
	}

	public void scoring()
	{
		count++;
		ct = count.ToString();
		countt.text = "x"+ct;
		if(count >= 25)
		{
			Vector3 p = door.transform.position;
			p.z = -1.7f;
			door.transform.position = p;
			//youwin.SetActive(true);
		}
	}

	public void negating()
	{
		count = count - 1;
		ct = count.ToString();
		//countt.text = "Score: " + ct;
		countt.text = "x"+ct;
		if(count < 0)
		{
			dead();
		}
	}

	public void useLife()
	{
		if (lifeCounter > 0) {
			lifeCounter--;
			if (life < 100) {
				life = Mathf.Min(100,life+25);
			}
		}
	}

	public void dead()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Application.LoadLevel (3);
	}

	void FixedUpdate()
	{
		if (sTimerStatus) {
			stimer += Time.deltaTime;
			stimer = Mathf.Round(stimer*100f)/100f;
			showTime.text = "Time Elapsed: " + stimer + " seconds";
		}
	}

	// Update is called once per frame
	void Update () {
		if (life >= 0) {
			healthBar.rectTransform.localScale = new Vector3 (life / 100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
			healthMessage.text = "Health: "+life+"%";
		}
	}
}
