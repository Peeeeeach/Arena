using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
	[SerializeField]private Button buttonRestart = null;
	[SerializeField]private Button buttonQuit = null;
	public Text YOUDIED = null;
	public Text TIMEUP = null;

	private GameManager manager;

	void Start () {
		manager = GameObject.FindObjectOfType<GameManager> ();
		if (buttonRestart != null) {
			buttonRestart.onClick.AddListener (ButtonRestartClickHandler);
		}
		if (buttonQuit != null) {
			buttonQuit.onClick.AddListener (ButtonQuitClickHandler);
		}
	}

	void Update () {
			if (manager.timeUP) {
				TIMEUP.gameObject.SetActive (true);
				YOUDIED.gameObject.SetActive (false);
			} else {
				TIMEUP.gameObject.SetActive (false);
				YOUDIED.gameObject.SetActive (true);
			}
	}

	private void ButtonRestartClickHandler(){
		manager.Reset ();
	}

	private void ButtonQuitClickHandler(){
		manager.Exit ();
	}
}
