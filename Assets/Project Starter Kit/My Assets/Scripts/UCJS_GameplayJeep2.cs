using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UCJS_GameplayJeep2 : MonoBehaviour {

	public GameObject[] startPoints;

	public UCJS_ArrowDirection[] arrowDirectionScript;

	public GameObject[] Levels;
	public GameObject[] CurrentLevelVehicle;


	[Header("[Tutorial Panel]")]
	public GameObject tutorialDialogueBox;
	public Text tutorialText;
	public string [] tutrialString;
	int tutrialStringIndex;

	[Header("[Other Panels]")]
	public GameObject PuaseDailogue;
	public GameObject GamePlayControls;
	public GameObject Levelfail;
	public GameObject objectiveDialogue;
	public Text objectiveText;

//	public GameObject steeringWheelPrefabe;
//	public GameObject[] arrowsControllerPrefabe;

//	public Text currentCash;

	public GameObject mainCamera;

	[Header("[Time Counter Components]")]
	public Text timerText;
	public float[] timeLeft;

	public int levelNumber = 1;
	int currentLevel = 0;
	int currentParkingNo;
	int specialMissioniNo;

	public bool isTestingModeOn;
	public static bool isTimeStarted;
	public float currentLevelTime = 300f;
	public static bool gameOverFall = false;

	private bool isTimeEnded;

	// Use this for initialization
	void Start () {


        Time.timeScale = 1f;
        AudioListener.pause = false;

		currentLevel = PlayerPrefs.GetInt ("CurrentLevelNumberJeep2");
        
		isTimeStarted = false;
		isTimeEnded = false;
        //		PlayerPrefs.DeleteAll();

      
        UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.GamePlayJeep1);

		// for testing enable this flag from editor 
		if (isTestingModeOn){
			currentLevel = levelNumber;
		}

		// setting level times 
		currentLevelTime = (timeLeft[currentLevel]);
		timerText.text = currentLevel.ToString ("0");

		// First Turn off all Vehicles
		for (int i = 0; i < CurrentLevelVehicle.Length; i++) {
			CurrentLevelVehicle [i].SetActive (false);
		}

		CurrentLevelVehicle [currentLevel].SetActive (true);

		if (currentLevel == 0) {
			// Turn on Levels
			for (int i = 0; i<Levels.Length; i++)
			{
				if (i == (currentLevel))
				{
					Levels[i].SetActive(true);
				}
				else
				{
					Levels[i].SetActive(false);
				}
			}

			ShowTutorial ();

		} else {
			// Turn on Levels
			for (int i = 0; i<Levels.Length; i++)
			{
				if (i == (currentLevel))
				{
					Levels[i].SetActive(true);
				}
				else
				{
					Levels[i].SetActive(false);
				}
			}
		}
	
	} // end Start Method
	
	// Update is called once per frame
	void Update () {

		TimeLeft ();

		if (currentLevelTime < 0 && !isTimeEnded) {
			LevelFailed ();
			isTimeEnded = true;
		}
	}


	public void puaseButtonClicked()
	{
		 
		CurrentLevelVehicle[levelNumber].GetComponent<Rigidbody>().isKinematic = true;
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		GamePlayControls.SetActive(false);
		PuaseDailogue.SetActive(true);
//		SoundManager.PlaySound (SoundManager.NameOfSounds.PanelsClip);
		
		Debug.Log("Timescale 0f in PauseButtonClicked");
		Time.timeScale = 0f;


		AudioListener.pause = true;

	}

	public void ResumeButtonClicked()
	{ 
		Time.timeScale = 1f;

		AudioListener.pause = false;

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		GamePlayControls.SetActive(true);
		PuaseDailogue.SetActive(false);
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.GamePlayJeep1);
		CurrentLevelVehicle[levelNumber].GetComponent<Rigidbody>().isKinematic = false;
	}

	public void restart()
	{ 
		Time.timeScale = 1f;

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		PlayerPrefs.SetInt ("isRestarted", 1);

		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	public void Home()
	{ 
		Time.timeScale = 1f;

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		SceneManager.LoadScene("UCJS_MainMenu");
	}

	public void NextLevel()
	{ 
		Time.timeScale = 1f;
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		SceneManager.LoadSceneAsync("UCJS_LevelSelectionJeep2");
	}

	public void okButtonClicked(){
		Time.timeScale = 1f;


		AudioListener.pause = false;


		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);
		objectiveDialogue.SetActive (false);
		GamePlayControls.SetActive (true);
		if (!isTimeStarted) {
			isTimeStarted = true;
			InvokeRepeating ("timeChekker", 0f, 1f);
		}

//		CurrentLevelVehicle[levelNumber].GetComponent<Rigidbody>().isKinematic = false;

		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.GamePlayJeep1);
	}


	void LevelFailed(){ 
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.LevelFail);
		PlayerPrefs.SetInt ("isRestarted", 0);

    
        Debug.Log ("level Failed in GAmeplay");
		Levelfail.SetActive (true);

//		int cashPlayerPrefs = PlayerPrefs.GetInt("Cash");
//		cashPlayerPrefs -= 150;
//		PlayerPrefs.SetInt ("Cash",cashPlayerPrefs);
//		if (cashPlayerPrefs >= 0) {
//			currentCash.text = cashPlayerPrefs.ToString () + " $";
//		} else {
//			PlayerPrefs.SetInt ("Cash",00);
//			currentCash.text = " 00 $";
//		}

		
		Debug.Log("Timescale 0f in levelfail in gameplay");
		Time.timeScale = 0;
	}

	public void TimeLeft(){
		currentLevelTime -= Time.deltaTime;
		TimeInMinutes (currentLevelTime);
	}

	void TimeInMinutes(float time){
		int seconds = (int)(time % 60);
		int minutes = (int)(time / 60) % 60;

		string timerString = string.Format ("{0:00}:{1:00}", minutes, seconds);

		timerText.text = timerString;
	}

	IEnumerator disbaleAudioListner( float delay ){

		yield return new WaitForSeconds (delay);
	}

																		/// <summary>
																		/// 			LEVEL 1 TUTRIAL PORTION
																		/// </summary>

	public void HitRightButton(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		tutrialStringIndex++;
		if (tutrialStringIndex == tutrialString.Length) {// set current string to TextObject
			SkipTutrial ();
		} else {

			tutorialText.text = tutrialString [tutrialStringIndex];
		}
	}

	public void HitLeftButton(){
		UCJS_SoundManager.PlaySound (UCJS_SoundManager.NameOfSounds.Button);

		tutrialStringIndex--;
		if (tutrialStringIndex < 0) {
			tutrialStringIndex = tutrialString.Length - 1;
		}

		// set current string to TextObject
		tutorialText.text = tutrialString [tutrialStringIndex];
	}

	void SkipTutrial(){
		tutorialDialogueBox.SetActive (false);
		objectiveDialogue.SetActive (true);
		Time.timeScale = 1f;
	}

	public void ShowTutorial(){
		Debug.Log("Timescale 0f in in Show tutorial");
		Time.timeScale = 0;
		objectiveDialogue.SetActive (false);
		tutorialDialogueBox.SetActive (true);
		tutorialText.text = tutrialString [0];
	}
}
