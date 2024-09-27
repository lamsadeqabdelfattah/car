using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UCJS_MainMenuManager : MonoBehaviour {

	public GameObject mainMenuPanel;
	public Button continuee;

   

//	public GameObject loadingScreen;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		if (PlayerPrefs.GetInt("CurrentLevelNumberJeep1", 0) == 0)
			continuee.interactable = false;
		else continuee.interactable = true;
		AudioListener.pause = false;
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.MainMenu);
    
//		PlayerPrefs.DeleteAll();

	}

	// Update is called once per frame
	void Update () {

	}

	public void LevelSelection(){ 
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		//		AudioListener.pause = true;

//		loadingScreen.SetActive (true);
		SceneManager.LoadSceneAsync ("UCJS_GameplayJeep1");

	}

	public void MoreApps(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		//Application.OpenURL (System.String.Empty);
	}

	public void RateUs(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		//Application.OpenURL ("");
	}

    
    
}

