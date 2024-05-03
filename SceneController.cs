using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public static SceneController instance;

	public void Awake(){
		if (instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else{
			Destroy(gameObject);
		}
	}

	public void nextBoss(){
		SceneManager.LoadSceneAsync(1);
	}
	
	public void loadBoss(string sceneName){
		SceneManager.LoadSceneAsync(sceneName);
	}
}
