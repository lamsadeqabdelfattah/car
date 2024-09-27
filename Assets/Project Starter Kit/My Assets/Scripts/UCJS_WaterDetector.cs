using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UCJS_WaterDetector : MonoBehaviour {

//	public Text currentCash;

	public GameObject levelFailPanel;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals ("Player")) {
			Debug.Log ("level Failed in water detector");
			levelFailPanel.SetActive (true);
			
			Debug.Log("Timescale 0f in waterDetector");
			Time.timeScale = 0f;

			//int cashPlayerPrefs = PlayerPrefs.GetInt("Cash");
			//cashPlayerPrefs -= 180;
			//PlayerPrefs.SetInt ("Cash",cashPlayerPrefs);
			//currentCash.text = cashPlayerPrefs.ToString() + " $";
			//if (cashPlayerPrefs >= 0) {
			//	currentCash.text = cashPlayerPrefs.ToString () + " $";
			//} else {
			//	currentCash.text = " 00 $";
			//}
		}
	}
}
