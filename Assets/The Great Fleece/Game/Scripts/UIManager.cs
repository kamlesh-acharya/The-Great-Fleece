using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	private static UIManager _instance;
	public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is Null!!!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
