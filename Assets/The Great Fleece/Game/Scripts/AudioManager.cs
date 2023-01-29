using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;
	public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is Null!!!");
            }

            return _instance;
        }
    }

    [SerializeField]
    private AudioSource voiceOver;

    private void Awake()
    {
        _instance = this;
    }

    public void playAudioForVO(AudioClip audioClip)
    {
        voiceOver.PlayOneShot(audioClip);
    }
}

