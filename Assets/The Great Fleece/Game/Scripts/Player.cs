using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

	private NavMeshAgent _agent;
	private Animator _animator;
	private Vector3 _target;
	[SerializeField]
	private GameObject _coinPrefab;
	[SerializeField]
	private AudioClip _coidAudioClip;
	private bool isCoinTossed = false;


	// Use this for initialization
	void Start () {
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if(Physics.Raycast(rayOrigin, out hitInfo))
            {
				_target = hitInfo.point;
				_agent.SetDestination(_target);
				_animator.SetBool("Walk", true);
            }
        }
		
		if(Vector3.Distance(transform.position, _target) <= 1.0f)
        {
			_animator.SetBool("Walk", false);
		}

		if (Input.GetMouseButtonDown(1) && isCoinTossed == false)
		{
			Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			if (Physics.Raycast(rayOrigin, out hitInfo))
			{
				isCoinTossed = true;
				_target = hitInfo.point;
				_animator.SetTrigger("Throw");
				Instantiate(_coinPrefab, _target, Quaternion.identity);
				AudioSource.PlayClipAtPoint(_coidAudioClip, _target);
				SendAIToCoinSpot(_target);
			}
		}
	}

	void SendAIToCoinSpot(Vector3 coinPos)
    {
		GameObject[] allGaurds = GameObject.FindGameObjectsWithTag("Guard1");
		for(int i = 0; i < allGaurds.Length; i++)
        {
			allGaurds[i].GetComponent<NavMeshAgent>().SetDestination(coinPos);
			allGaurds[i].GetComponent<GaurdAI>().coinTossed(coinPos);
        }
    }
}
