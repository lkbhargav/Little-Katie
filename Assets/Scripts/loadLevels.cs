using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadLevels : MonoBehaviour {
	public GameObject instructionsText;
	public GameObject storyText;
	public GameObject controlsText;
	public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void exitGame()
	{
		Application.Quit();
	}

	public void restartGame()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void resumeGame()
	{
		Time.timeScale = 1.0f;
		pauseMenu.SetActive (false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void story()
	{
		storyText.SetActive(true);
	}

	public void okButton()
	{
		storyText.SetActive(false);
		instructionsText.SetActive(false);
		controlsText.SetActive (false);
	}

	public void instructions()
	{
		instructionsText.SetActive(true);
	}

	public void controls()
	{
		controlsText.SetActive (true);
	}

	public void startGame()
	{
		Application.LoadLevel (1);
	}

	public void pauseMenuStartScreen()
	{
		Time.timeScale = 1.0f;
		Application.LoadLevel (0);
	}

	public void startScreen()
	{
		Application.LoadLevel (0);
	}
}
