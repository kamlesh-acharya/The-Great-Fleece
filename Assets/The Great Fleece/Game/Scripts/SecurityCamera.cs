using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour {
    [SerializeField]
    private GameObject _gameOverCutscene;
    [SerializeField]
    private Animator _animator;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Cameras Activated");
            Renderer renderer = GetComponent<Renderer>();
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.3f);
            renderer.material.SetColor("_TintColor", color);
            _animator.enabled = false;
            StartCoroutine(AlertRoutine());
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverCutscene.SetActive(true);
    }
}
