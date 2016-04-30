using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject enemyPrefab2;

	private GameObject _enemy2;
	private GameObject _enemy;
	public GameObject pauseMenu;
	public GameObject panel;
	public GameObject moonSlab;
	public GameObject sideSlab;
	public GameObject oppSlab;
	public GameObject oppSlab1;
	public GameObject roofSlab;
	public GameObject camera;
	public GameObject l1;
	public GameObject l2;
	public GameObject l3;
	public GameObject l4;
	public GameObject l5;
	public GameObject l6;
	public GameObject l7;
	public GameObject l8;
	public GameObject l9;
	public GameObject l10;
	public GameObject l11;
	public GameObject l12;
	public GameObject l13;
	public GameObject l14;
	public GameObject l15;
	public GameObject l16;
	public GameObject l17;
	public GameObject l18;
	public GameObject l19;
	public Text score;
	public Text life;
	public Text money;

	//public GameObject light;

	public bool i = false;
	public GameObject light;
	public GameObject go;
	//public Camera camera;
	private int counter;
	private int lightCounter;
	private int pauseResume;
	private int storeCounter;
	private int mapCounter;


	void Start()
	{

		//light = GetComponent<Light>();
	}

	void Update() {

		if (Input.GetKeyDown ("m")) {
			counter++;
			if(counter%2 == 0)
			{
				light.SetActive(true);
				moonSlab.SetActive(false);
				sideSlab.SetActive(false);
				oppSlab.SetActive(false);
				oppSlab1.SetActive(false);
				roofSlab.SetActive(false);
				SwitchStreetLights(false);
				score.color = Color.black;
				life.color = Color.black;
				money.color = Color.black;
			}
			else
			{
				light.SetActive(false);
				moonSlab.SetActive(true);
				sideSlab.SetActive(true);
				oppSlab.SetActive(true);
				oppSlab1.SetActive(true);
				roofSlab.SetActive(true);
				SwitchStreetLights(true);
				score.color = Color.white;
				life.color = Color.white;
				money.color = Color.white;
			}
		}

		if (Input.GetKeyDown ("p")) {
			pauseResume++;
			if(pauseResume%2 == 0)
			{
				Time.timeScale = 0.0f;
				pauseMenu.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else{
				Time.timeScale = 1.0f;
				pauseMenu.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}

		if (Input.GetKeyDown ("l") && counter%2 != 0) {
			lightCounter++;
			if(lightCounter%2 == 0)
			{
				SwitchStreetLights(false);
			}
			else
			{
				SwitchStreetLights(true);
			}
		}



		if (Input.GetKeyDown ("n")) {
			mapCounter++;
			if(mapCounter%2 == 0)
			{
				camera.SetActive(false);
				go.SetActive(false);
			}
			else
			{
				go.SetActive(true);
				camera.SetActive(true);
			}
		}

		if (Input.GetKeyDown ("1")) {
			Score.instance.count += 5;
		}

		if (Input.GetKeyDown ("2")) {
			if(Input.GetKeyDown("4"))
				Score.instance.money += 30;
			Score.instance.paperMoney.text = "x"+Score.instance.money;
		}

		if (Input.GetKeyDown ("3")) {
			Score.instance.collectLife();
		}


		if (Input.GetKeyDown ("t")) {

			Score.instance.useLife();
		}

		if (Input.GetKeyDown ("v")) {
			storeCounter++;

			if(storeCounter%2 == 0)
			{
				Time.timeScale = 0.0f;
				panel.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else
			{
				Time.timeScale = 1.0f;
				panel.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}

		Vector3 pos;
		pos.x = Random.Range (-14,14);
		pos.z = Random.Range (-14,14);
//		transform.position = pos;

		if (_enemy == null && Score.instance.count < 25) {
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(pos.x,1, pos.z);
			float angle = Random.Range(0, 360);

			_enemy.transform.Rotate(0, angle, 0);
			if(_enemy2 != null)
			{
				i = true;
			}
		}

		if (_enemy2 == null && Score.instance.count < 25) {
			_enemy2 = Instantiate(enemyPrefab2) as GameObject;
			_enemy2.transform.position = new Vector3(pos.x,1, pos.z);
			float angle = Random.Range(0, 360);
			_enemy2.transform.Rotate(0, angle, 0);

		}
	}

	private void SwitchStreetLights(bool condition)
	{
		l1.SetActive(condition);
		l2.SetActive(condition);
		l3.SetActive(condition);
		l4.SetActive(condition);
		l5.SetActive(condition);
		l6.SetActive(condition);
		l7.SetActive(condition);
		l8.SetActive(condition);
		l9.SetActive(condition);
		l10.SetActive(condition);
		l11.SetActive(condition);
		l12.SetActive(condition);
		l13.SetActive(condition);
		l14.SetActive(condition);
		l15.SetActive(condition);
		l16.SetActive(condition);
		l17.SetActive(condition);
		l18.SetActive(condition);
		l19.SetActive(condition);
	}
}