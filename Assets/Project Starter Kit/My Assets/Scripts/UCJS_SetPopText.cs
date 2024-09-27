using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCJS_SetPopText : MonoBehaviour {

	public GameObject floatingTextPrefabe;
	public Animator floatingTextanimator;

	// Use this for initialization
	void Start () {
		floatingTextPrefabe.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void ShowFloatingText (){
		StartCoroutine (JustWait (5.0f));
	}

	IEnumerator JustWait(float wait){
		floatingTextPrefabe.SetActive (true);

		yield return new WaitForSeconds (wait);

		floatingTextPrefabe.SetActive (false);
	}
}
