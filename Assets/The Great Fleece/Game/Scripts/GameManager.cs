using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class GameManager : MonoBehaviour {

	private static GameManager _instance;
	public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is Null!!!");
            }

            return _instance;
        }
    }

    private bool _hasCard = false;
    [SerializeField]
    private PlayableDirector introCutscene;

    public bool HasCard { get { return _hasCard; } set { _hasCard = value; }}

    private void Awake()
    {
        _instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 62.0f;
        }
    }
}
