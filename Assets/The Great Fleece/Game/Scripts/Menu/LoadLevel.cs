using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

	[SerializeField]
	private Image _progressBar;
	// Use this for initialization
	void Start () {
		StartCoroutine(LoadLevelAsync());
	}
	
	IEnumerator LoadLevelAsync()
    {
		yield return null;

		AsyncOperation _loadScene = SceneManager.LoadSceneAsync("Main");

		while (!_loadScene.isDone)
        {
			_progressBar.fillAmount = _loadScene.progress;
			Debug.Log("_loadScene.progress= " + _loadScene.progress);
            yield return new WaitForEndOfFrame();
        }
    }
}
