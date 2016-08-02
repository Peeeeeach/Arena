using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	[SerializeField]GameManager manager;
	[SerializeField]HUD hudRunningScore;
	[SerializeField]HUD hudMenuInformation;
	[SerializeField]GameMenu menu;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (manager.state) {
		case GameManager.GameState.GameOver:
			break;
		case GameManager.GameState.Idle:
			ShowMenu (manager.timeUP);
			SetMenuInformation (manager.GetScore ());
			break;
		case GameManager.GameState.Playing:
			HideMenu ();
			SetRunningScore (manager.GetScore ());
			break;
		}
	}

	public void SetRunningScore(int score){
		if (hudRunningScore != null) {
			hudRunningScore.score = score;
			hudRunningScore.time = manager.usingTime;
		}
	}

	public void SetMenuInformation(int score){
		if (hudMenuInformation != null) {
			hudMenuInformation.score = score;
			hudMenuInformation.best = PlayerPrefs.GetInt ("Best");
		}
	}

	private void HideMenu(){
		menu.gameObject.SetActive (false);
	}

	private void ShowMenu(bool timeUP){
		menu.gameObject.SetActive (true);
		if (timeUP) {
			menu.TIMEUP.gameObject.SetActive (true);
			menu.YOUDIED.gameObject.SetActive (false);
		} else {
			menu.TIMEUP.gameObject.SetActive (false);
			menu.YOUDIED.gameObject.SetActive (true);
		}
	}
}
