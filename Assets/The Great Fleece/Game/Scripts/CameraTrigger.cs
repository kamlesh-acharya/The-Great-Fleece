using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	[SerializeField]
	private Transform _myCamera;

	private void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player")
        {
			Debug.Log("Trigger Activated");
			Camera.main.transform.position = _myCamera.transform.position;
			Camera.main.transform.rotation = _myCamera.transform.rotation;
        }
    }
}
