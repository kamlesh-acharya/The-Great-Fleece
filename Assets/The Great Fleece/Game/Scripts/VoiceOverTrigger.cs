using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour {

	[SerializeField]
	private AudioClip _audioClip;
	

	void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player")
        {
			//AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
			AudioManager.Instance.playAudioForVO(_audioClip);
			Destroy(gameObject.GetComponent<Collider>());
		}
    }
	
}
