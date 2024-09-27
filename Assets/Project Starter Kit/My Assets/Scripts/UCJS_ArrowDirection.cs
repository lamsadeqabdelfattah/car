using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCJS_ArrowDirection : MonoBehaviour {

	public Transform lookAtGameObject;

	private int currentLevel;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetPosition = new Vector3 (lookAtGameObject.transform.localPosition.x,
			lookAtGameObject.transform.localPosition.y,
			lookAtGameObject.transform.localPosition.z);
		

		// Rotate the camera every frame so it keeps looking at the target
//		transform.LookAt(targetPosition);
		transform.LookAt (targetPosition);
	}
}
