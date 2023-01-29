using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour {
    [SerializeField]
    private GameObject _grabKeyCardCutScene;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.Instance.HasCard == false)
        {
            GameManager.Instance.HasCard = true;
            _grabKeyCardCutScene.SetActive(true);
            StartCoroutine(DeactivateTheCutScene());
        }
    }

    IEnumerator DeactivateTheCutScene()
    {
        yield return new WaitForSeconds(6.0f);
        _grabKeyCardCutScene.SetActive(false);
    }
}
