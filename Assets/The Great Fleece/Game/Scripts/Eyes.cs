using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {
    [SerializeField]
    private GameObject _gameOverCutscene;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Gaurds Activated");
            _gameOverCutscene.SetActive(true);
        }
    }
}
