using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UCJS_GUIManager : MonoBehaviour {
		[SerializeField]
		private GameObject tipsPanel;

	[SerializeField]
	private GameObject pausePanel;

	//	[SerializeField]
	//	private GameObject finalDestination;

//	public GameObject loadingScreen;

	// Use this for initialization
	void Start () {
		InitializePanels ();
		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {

	}

	void InitializePanels(){
		AudioListener.pause = true;

		//		tipsPanel.SetActive (true);
		
		
		Debug.Log("Timescale 0f in gui manager initializepanels");
		Time.timeScale = 0;

		pausePanel.SetActive (false);
	}

	public void ShowPausePanel(){ 
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		Debug.Log("Timescale 0f in gui manager showpausepanel");
		Time.timeScale = 0;
		AudioListener.pause = true;
		//		SoundManager.PlaySound (SoundManager.NameOfSounds.MainMenu);
		pausePanel.SetActive (true);
	}

	public void HidePausePanel(){
		Time.timeScale = 1;
		AudioListener.pause = false;
		//		SoundManager.PlaySound (SoundManager.NameOfSounds.Button);
		pausePanel.SetActive (false);
	}

	public void HideTipsPanel(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		Time.timeScale = 1;
		AudioListener.pause = false;
		tipsPanel.SetActive (false);
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.GamePlayJeep1);
	}


	public void GotoHomeMenu(){
		 SceneManager.LoadSceneAsync ("UCJS_MainMenu");
	}

	public void RestartLevel(){ 
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void GoToNextLevel(){ 
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
//		loadingScreen.SetActive (true);
		SceneManager.LoadSceneAsync (System.String.Empty);
	}
}
