using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class UCJS_StopHandlerScriptJeep1 : MonoBehaviour {
	public GameObject[] SequenceViseStops;

	public UCJS_ArrowDirection[] arrowDirectionScript;

	public GameObject currentVehicle;
	public GameObject CurrentVehicleSpawnPosition;
	public GameObject[] civilionPickupscripts;
	public GameObject[] civilionDropScripts;

//	public Text currentCash;

	public GameObject LevelCompletePanel;
	public GameObject rccMainCamera;
	public GameObject Controls;
	public GameObject objectiveDialogue;
	public Text objectiveText;
	public string [] ObjectiveString;

	public int currentIndex = 0;
	public int currentLevel = 0;


	// Use this for initialization
	void Awake () {

	}

	void Start(){
		currentIndex = 0;

		if (SequenceViseStops.Length>0){
			ActivateCurrentStop(currentIndex);
		}

		currentLevel = PlayerPrefs.GetInt ("CurrentLevelNumberJeep1",0);
		
		
		currentVehicle.SetActive (true);
		currentVehicle.transform.localPosition = CurrentVehicleSpawnPosition.transform.position;
		currentVehicle.transform.localEulerAngles = CurrentVehicleSpawnPosition.transform.eulerAngles;
		currentVehicle.GetComponent<RCC_CarControllerV3> ().canControl = true;
	}


	void Update(){
		
	}


	public void ActivateCurrentStop(int index){
		for (int i = 0; i < SequenceViseStops.Length; i++) {
			if (i == (index)) {
				SequenceViseStops [i].SetActive (true);


				arrowDirectionScript[currentLevel].GetComponent<UCJS_ArrowDirection> ().lookAtGameObject.transform.position = SequenceViseStops [i].transform.position;
				arrowDirectionScript[currentLevel].GetComponent<UCJS_ArrowDirection> ().lookAtGameObject.transform.eulerAngles = SequenceViseStops [i].transform.eulerAngles;

                if (index == 0)
                {
                    objectiveText.text = ObjectiveString[0];
                    objectiveDialogue.SetActive(true);
                }
//				Time.timeScale = 0f;
				Time.timeScale = 1f;		// No need to show dialogue boxes in start of parkings
			} else {
				SequenceViseStops [i].SetActive (false);
			}
		}

	}


	public void ActivateNewSpot( ){

		currentIndex++;

		if (SequenceViseStops.Length > (currentIndex)) {
			ActivateCurrentStop (currentIndex);
		} else {
			StartCoroutine (GameCompleted ());
		}
	}


	IEnumerator  GameCompleted(){
		yield return new WaitForSeconds (0f);

		showGameOver ();
	}


	public void showGameOver()
	{
		Controls.SetActive(false);

        
        int currentLevel;
		currentLevel = PlayerPrefs.GetInt ("CurrentLevelNumberJeep1", 0);

		int totalLevelUnlocked = PlayerPrefs.GetInt ("TotalLevelUnlockedJeep1", 1);

		currentLevel += 1;
		if ( totalLevelUnlocked<=currentLevel) {
			if (totalLevelUnlocked < 10) {
				totalLevelUnlocked+=1;
				PlayerPrefs.SetInt ("TotalLevelUnlockedJeep1", totalLevelUnlocked);
			}
		}

		Debug.Log("Timescale 0f in showGameOver in Stophandler");
		Time.timeScale = 0;
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.LevelComplete);
		LevelCompletePanel.SetActive(true);

	}


	IEnumerator DelayInTimeforLevelCompleteSound(float delay){
		yield return new WaitForSeconds (delay);
	}
}