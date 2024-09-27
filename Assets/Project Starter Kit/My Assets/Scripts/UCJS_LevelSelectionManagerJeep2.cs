using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UCJS_LevelSelectionManagerJeep2 : MonoBehaviour {

	public GameObject[] lockImages;
	public Button[] levelSlidesButtons;

	public GameObject loadingScreen;

	private int totalUnlockedLevel = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;

        AudioListener.pause = false;

    
        UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.JeepSelection);
        loadingScreen.SetActive (false);

//		PlayerPrefs.SetInt ("TotalLevelUnlocked", 10);  /// Just for Testing Purpose
//		PlayerPrefs.DeleteAll();

		InactiveAllButtons ();

		CheckUnlockedLevels ();

	}



	void CheckUnlockedLevels(){
		totalUnlockedLevel = PlayerPrefs.GetInt ("TotalLevelUnlockedJeep2", 1);

		// turn off all lock images
		for (int i = 0; (i < totalUnlockedLevel && i < lockImages.Length); i++) {
			lockImages [i].SetActive (false);
			levelSlidesButtons [i].interactable = true;
		}

		// unlock all levels
//		if (totalUnlockedLevel > 9) {
//			unlockAllLevels.SetActive (false);
//		}

		// turn off locked buttons
		for (int i = 0; i < levelSlidesButtons.Length; i++) {
			if (i >= totalUnlockedLevel) {
				levelSlidesButtons [i].interactable = false;
			}
		}
	}

	void InactiveAllButtons(){
		for (int i = 0; i < lockImages.Length; i++) {
			lockImages [i].SetActive (true);
			levelSlidesButtons [i].interactable = false;
		}
	}

	public void LevelClicked(int index){ 
		index--;
		PlayerPrefs.SetInt ("CurrentLevelNumberJeep2", index);
		loadingScreen.SetActive (true);
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
        UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.JeepSelection);
        SceneManager.LoadSceneAsync ("UCJS_GameplayJeep2");
	}

	public void Home(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
        UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.JeepSelection);
        SceneManager.LoadSceneAsync ("UCJS_MainMenu");
	}
}
