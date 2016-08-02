using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour {
	[SerializeField]private GameObject Monsterprefab;
	[SerializeField]private PlayerMove player;
	private List<GameObject> MonsterList = new List<GameObject> ();
	private Rigidbody2D rigid;

	public float windowHeight = 0;
	public float Radius = 0;
	public float GenerateDis = 1.5f;
	public float MonsterMoveSpeed = 1.0f;
	private float timer = 0;
	public float initialGenerateTime = 2.0f;
	public float usedGenerateTime;
	public float timeScale = 0.95f;
	private Vector3 PlayerPos;

	void Start () {
		windowHeight = Camera.main.ViewportToWorldPoint (Vector3.up).y * 2;
		Radius = windowHeight / 2.0f * 0.9f;
		timer = 0;
		usedGenerateTime = initialGenerateTime;
	}

	void Update () {
//		if (Input.GetKeyDown (KeyCode.Space) == true)
//			MonsterGenerate ();
		if (Time.time - timer > usedGenerateTime) {
			timer = Time.time;
			MonsterGenerate ();
		}
	}

	//初始化怪物
	public void InitializeMonster(int stage){
		
	}

	//生成一个怪物
	private void MonsterGenerate(){
		GameObject monster = (GameObject)Instantiate (Monsterprefab, new Vector3 (0, windowHeight, 0), Quaternion.identity);
		ResetMonster (monster);
		MonsterList.Add (monster);
	}

	//重置怪物位置
	public void ResetMonster(GameObject monster){
		if (monster == null)
			return;
		Vector3 NewPos;
		do {
			PlayerPos = player.GetPlayerPosition ();
			float RandomRadius = 0;
			RandomRadius = Random.Range (0, Radius);
			NewPos = new Vector3 (Random.Range (-100, 100), Random.Range (-100, 100), 0).normalized * RandomRadius;
		} while(Vector3.Distance (PlayerPos, NewPos) < GenerateDis);
		monster.transform.position = NewPos;
		rigid = monster.GetComponent<Rigidbody2D>();
		rigid.velocity = new Vector3 (Random.Range (-100, 100), Random.Range (-100, 100), 0).normalized * MonsterMoveSpeed;
	}

	//消灭怪物
	public void EliminateMonster(GameObject monster){
		Destroy (monster);
		MonsterList.Remove (monster);
		if (usedGenerateTime > 0.5f) {
			usedGenerateTime *= timeScale;
		}
		/*for (int i = MonsterList.Count - 1; i >= 0; i--) {
			if (MonsterList [i] == null) 
				MonsterList.RemoveAt (i);
		}*/
	}

	//清空怪物
	public void AllClear(){
		for (int i = MonsterList.Count - 1; i >= 0; i--) {
			Destroy (MonsterList [i]);
		}
		MonsterList.Clear ();
	}
}