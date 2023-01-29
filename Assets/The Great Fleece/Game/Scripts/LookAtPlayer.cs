using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	[SerializeField]
	private Transform target;
	[SerializeField]
	private Transform startCamera;
	
	void Start()
    {
		transform.position = startCamera.position;
		transform.rotation = startCamera.rotation;
    }

	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
	}
}
