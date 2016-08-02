using UnityEngine;
using System.Collections;

public class MonsterHit : MonoBehaviour {
	private Monster monster;
	private Rigidbody2D rigid;
	private GameManager manager;

	void Start () {
		rigid = this.GetComponent<Rigidbody2D> ();
		monster = GameObject.FindObjectOfType<Monster> ();
		manager = GameObject.FindObjectOfType<GameManager> ();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hitInfo){
		if (hitInfo.gameObject.tag.Equals ("Wall")) {
//			Debug.Log ("Gay!");
			Vector3 direc = this.transform.position;
			Vector3 newSpeed = Vector3.zero;
			if (direc.x >= 0 && direc.y >= 0) {
				newSpeed = new Vector3 (Random.Range (-100, -40), Random.Range (-100, -40), 0).normalized;
			} else if (direc.x < 0 && direc.y >= 0) {
				newSpeed = new Vector3 (Random.Range (40, 100), Random.Range (-100, -40), 0).normalized;
			} else if (direc.x >= 0 && direc.y < 0) {
				newSpeed = new Vector3 (Random.Range (-100, -40), Random.Range (40, 100), 0).normalized;
			} else {
				newSpeed = new Vector3 (Random.Range (40, 100), Random.Range (40, 100), 0).normalized;
			}
			rigid.velocity = newSpeed * monster.MonsterMoveSpeed;
//			monster.ResetMonster(this.gameObject);
		}

		if (hitInfo.gameObject.tag.Equals ("Player")) {
			manager.ScoreMinus ();
			monster.EliminateMonster (this.gameObject);
		}

		if (hitInfo.gameObject.tag.Equals ("Bullet")) {
			manager.ScorePlus ();
			monster.EliminateMonster (this.gameObject);
		}
	}
}
