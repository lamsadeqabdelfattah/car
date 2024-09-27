using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UCJS_DestinationScriptJeep1 : MonoBehaviour {
//	public Image parking;
//	public GameObject arrowsObject;

	public GameObject cameraObject;

//	public GameObject mapmarker;

	public GameObject ParentObject;

//	public GameObject[] dummyVehicles;
//	public Transform[] dummyVehiclesPosition;

	public GameObject currentVehicle;
//	public GameObject CurrentVehicleSpawnPosition;

	public UCJS_GameplayJeep1 gamePlayScript;

	public bool isParkingFill;
	public bool isServiceStationParking;
	public bool isFinalPoint;

	public delegate void resetimage();
	public static resetimage ResetParkingImage;

	private int currentParking;


	void OnEnable(){
		//ResetParkingImage += resetParkingImage;
	}
	void OnDisable(){
		//	ResetParkingImage -= resetParkingImage;
		//	resetParkingImage ();
	}

	// Use this for initialization
	void Awake () {
//		parking.fillAmount = 0f;
//		parking.gameObject.SetActive(false);
		isParkingFill = false;
	}


	void Start(){
		
		currentVehicle.SetActive (true);
//		Time.timeScale = 1f;
//		currentVehicle.transform.localPosition = CurrentVehicleSpawnPosition.transform.position;
//		currentVehicle.transform.localEulerAngles = CurrentVehicleSpawnPosition.transform.eulerAngles;
		currentVehicle.GetComponent<RCC_CarControllerV3> ().canControl = true;
	}


	void resetParkingImage(){
//		parking.fillAmount = 0f;
//		parking.gameObject.SetActive(false);
	}


	void OnTriggerEnter(Collider other)
	{
		//		mapmarker.GetComponent<MapMarker> ().isActive = true;
		if (other.gameObject.tag.Equals("Player"))
        {
            UCJS_SoundManager.PlaySound(UCJS_SoundManager.NameOfSounds.CoinCollect);
            SwapSpots();
		}
	}


//	void OnTriggerStay(Collider other)
//	{
//		parking.gameObject.SetActive(true);
//		if (other.gameObject.tag.Equals("Player"))
//		{
////			mapmarker.GetComponent<MapMarker> ().isActive = false;
//
//			if (parking.fillAmount < 1  && !isParkingFill)
//			{
//				parking.fillAmount += Time.deltaTime * 0.25f;
//			}
//			else if  (!isParkingFill)
//			{
//				isParkingFill = true;
//
////				currentVehicle.SetActive (false);
//				resetParkingImage ();
//
////				this.gameObject.GetComponent<MapMarker> ().isActive = false;
//				SwapSpots();
//			}
//		}
//	}

//	void OnTriggerExit(Collider other)
//	{
////		mapmarker.GetComponent<MapMarker> ().isActive = true;
//		if (other.gameObject.tag.Equals("Player"))
//		{
//			resetParkingImage ();
//		}
//	}

	private void SwapSpots()
	{
//		parking.gameObject.SetActive(false);
		gamePlayScript.GamePlayControls.SetActive (false);
//		cameraObject.SetActive (true);

		StartCoroutine (SwapPoints (0f));
	}
	IEnumerator SwapPoints( float delay ){
		if (!isFinalPoint) {
//			cameraObject.SetActive (false);

			gamePlayScript.GamePlayControls.SetActive (true);

		} else {
			
			yield return new WaitForSeconds (1.5f);
            gamePlayScript.GamePlayControls.SetActive(false);
//			currentVehicle.GetComponent<Rigidbody>().isKinematic = true;
		}


        UCJS_GameplayJeep1.isTimeStarted = false;
		gamePlayScript.CancelInvoke ("timeChekker");

		ParentObject.GetComponent<UCJS_StopHandlerScriptJeep1> ().ActivateNewSpot ();
	}

}

