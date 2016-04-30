using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class saveScore : MonoBehaviour {
	public InputField name;
	public Text tTime;
	public GameObject hsf;
	private string n;
	public Text playerName;
	public Text bestTime;
	Dictionary<string, float> scores;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.DeleteAll();
//		if (Score.instance.stimer > PlayerPrefs.GetFloat ("Time", Score.instance.stimer)) {
//			hsf.SetActive (true);
//		} else {
//			hsf.SetActive(false);
//		}
		tTime.text = "Total Time: "+Score.instance.stimer.ToString()+" seconds";
		playerName.text = "Best Player: "+PlayerPrefs.GetString("Name");
		bestTime.text = "Best Time: "+PlayerPrefs.GetFloat("Time");
	}

	public void save()
	{
		n = name.ToString ();
		scores [n] = Score.instance.stimer;
		if (Score.instance.stimer > PlayerPrefs.GetFloat ("Time", Score.instance.stimer)) {
			PlayerPrefs.SetString ("Name", n);
			PlayerPrefs.SetFloat ("Time", Score.instance.stimer);
		}
	}
}
