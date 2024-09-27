using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UCJS_VehicleSelector : MonoBehaviour {

	public GameObject[] vehicleList;
	private int index;

	public GameObject loadingScreen;

	public GameObject disableButton;

	// Use this for initialization
	void Awake () {
		
//		for (int i = 0; i < transform.childCount; i++) {
//			truckList[i]=transform.GetChild(i).gameObject;ee
//		}

		 // turn off every vehicle
		foreach (GameObject go in vehicleList) {
			go.SetActive (false);
		}
		
		// turn on a vehicle at scene start
		index = PlayerPrefs.GetInt ("VehicleModeSelected",0);
		vehicleList [index].SetActive (true);
//
//		if (vehicleList [index]) {
//			vehicleList [index].SetActive (true);
//			if (truckTransform != null) {
//				truckTransform.playerTransform = vehicleList [index].transform;
//			}
//		}
	}

	void Start()
	{
		Time.timeScale = 1f;
        AudioListener.pause = false;

      
        UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.JeepSelection);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleLeft(){

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		// toggle off the current modle
		vehicleList[index].SetActive(false);

		index--;
		if (index < 0) {
			index = vehicleList.Length - 1;
		}

		if (index >= 3 && index <= vehicleList.Length) {
			disableButton.GetComponent<Button>().interactable = false;
		} else {
			disableButton.GetComponent<Button>().interactable = true;
		}

		// toggle on the new model
		vehicleList[index].SetActive (true);
		
		PlayerPrefs.SetInt ("VehicleModeSelected",index);
        UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.JeepSelection);

    }

	public void ToggleRight(){

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		// toggle off the current modle
		vehicleList[index].SetActive(false);

		index++;
		if (index == vehicleList.Length) {
			index = 0;
		}

		if (index >= 3 && index <= vehicleList.Length) {
			disableButton.GetComponent<Button>().interactable = false;
		} else {
			disableButton.GetComponent<Button>().interactable = true;
		}

		// toggle on the new model
		vehicleList[index].SetActive (true);
		PlayerPrefs.SetInt("VehicleModeSelected", index);
        UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.JeepSelection);
    }

	public void ConfirmSelectButton(){

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
//		AudioListener.pause = true;
		loadingScreen.SetActive (true);
		index = PlayerPrefs.GetInt ("VehicleModeSelected");
		

		switch (index)
		{
			case 0:
				SceneManager.LoadSceneAsync ("UCJS_LevelSelectionJeep1");
				break;
			case 1:
				SceneManager.LoadSceneAsync("UCJS_LevelSelectionJeep2");
				break;
        }
        UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.JeepSelection);
    }

	public void GotoMainMenu(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
//		AudioListener.pause = true;
		loadingScreen.SetActive (true);
		
		SceneManager.LoadSceneAsync ("UCJS_MainMenu");
	}
}
