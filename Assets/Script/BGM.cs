using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {
	private AudioSource Audio = null;
	private GameManager manager = null;

	void Start () {
//		PlayerPrefs.SetInt ("Best", 0);
		manager = GameObject.FindObjectOfType<GameManager> ();
		Audio = this.GetComponent<AudioSource> ();
	}

	void Update () {
		switch (manager.state) {
		case GameManager.GameState.Idle:
			Audio.volume = 0.3f;
			break;
		case GameManager.GameState.Playing:
			Audio.volume = 0.8f;
			break;
		case GameManager.GameState.GameOver:
			break;
		}
	}
}
