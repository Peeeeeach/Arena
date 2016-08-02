using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	[SerializeField]private PlayerMove player;
	[SerializeField]private Monster monster;
	[SerializeField]private Bullet bullet;

	public enum GameState{Idle, Playing, GameOver};
	public GameState state = GameState.Idle;
	private int score;
	[SerializeField]private int scorePlus = 2;
	[SerializeField]private int scoreMinus = 1;
	[SerializeField]private float totalTime = 60.0f;
	public float usingTime;
	public bool timeUP;

	void Start () {
		state = GameState.Playing;
		score = 0;
		usingTime = totalTime;
		timeUP = false;
	}

	void Update () {
		if (state == GameState.Playing) {
			usingTime -= Time.deltaTime;
			if (usingTime <= 0) {
				state = GameState.GameOver;
				timeUP = true;
			}
		} else if (state == GameState.Idle) {
			
		} else if (state == GameState.GameOver) {
			player.gameObject.SetActive (false);
			if (score > PlayerPrefs.GetInt ("Best")) {
				PlayerPrefs.SetInt ("Best", score);
			}
			state = GameState.Idle;
		}
	}

	public void ScorePlus(){
		if(state == GameState.Playing)
			score += scorePlus;
	}
	public void ScoreMinus(){
		if (state == GameState.Playing) {
			if (score - scoreMinus >= 0)
				score -= scoreMinus;
			else
				score = 0;
		}
	}

	public int GetScore(){
		return score;
	}

	public void Reset(){
		score = 0;
		usingTime = totalTime;
		timeUP = false;
		state = GameState.Playing;
		player.transform.position = Vector3.zero;
		player.gameObject.SetActive (true);
		monster.AllClear ();
		bullet.AllClear ();
		monster.usedGenerateTime = monster.initialGenerateTime;
	}

	public void Exit(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
