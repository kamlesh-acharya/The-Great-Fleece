using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour {
    [SerializeField]
    private GameObject _WinCutScene;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.Instance.HasCard == true)
        {
            GameManager.Instance.HasCard = true;
            _WinCutScene.SetActive(true);
        }
        else
        {
            Debug.Log("You must grab the key card");
        }
    }
}
