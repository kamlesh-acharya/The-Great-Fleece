using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GaurdAI : MonoBehaviour {

	[SerializeField]
	private List<Transform> _wayPoints;

	private NavMeshAgent _agent;
	private int currentTarget = 0;
	private bool isMovingForward = true;
	private bool isTargetReached = false;
	private Animator _animator;

	private bool isCoinTossed = false;
	private Vector3 _coinPos;

	// Use this for initialization
	void Start () {
		_agent = GetComponent<NavMeshAgent>();
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (_wayPoints.Count > 1 && _wayPoints[currentTarget] != null && isTargetReached == false && isCoinTossed == false)
		{
			_agent.SetDestination(_wayPoints[currentTarget].position);
			_animator.SetBool("Walk", true);

			if (Vector3.Distance(transform.position, _wayPoints[currentTarget].position) < 2.5f && isTargetReached == false)
			{
				isTargetReached = true;
				_animator.SetBool("Walk", false);
				StartCoroutine(WaitBeforeMove());

				if (_wayPoints.Count - 1 > currentTarget && isMovingForward)
				{
					isMovingForward = true;
					currentTarget++;
				}
				else if (0 < currentTarget)
				{
					isMovingForward = false;
					currentTarget--;
				}
				else
				{
					isMovingForward = true;
				}
			}
		}
		else
		{
			if (Vector3.Distance(transform.position, _coinPos) < 2.5f)
			{
				_animator.SetBool("Walk", false);
			}
		}
	}

	IEnumerator WaitBeforeMove()
	{
        if (isTargetReached && (currentTarget == _wayPoints.Count - 1 || currentTarget == 0))
        {
			yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
            if (isCoinTossed == false)
            {
				isTargetReached = false;
            }
		} else
        {
			if (isCoinTossed == false)
			{
				isTargetReached = false;
			}
		}
	}

	IEnumerator WaitForCoinTossed()
    {
		yield return new WaitForSeconds(Random.Range(8.0f, 10.0f));
		isTargetReached = false;
		isCoinTossed = false;
	}

	public void coinTossed(Vector3 coinPos)
    {
		isCoinTossed = true;
		_coinPos = coinPos;
		_agent.SetDestination(coinPos);
		_animator.SetBool("Walk", true);
		StartCoroutine(WaitForCoinTossed());
	}
}
