using UnityEngine;
using System.Collections;

public class MonsterHit : MonoBehaviour {
	[SerializeField] private GameObject BurnPrefab;
	//private PlayerMove player;
	private GameObject Burn;
	//private GameObject Die;
	private Monster monster;
	private Rigidbody2D rigid;
	private GameManager manager;

	private float BurnTime = 1.0f;

	void Start () {
		//player = GameObject.FindObjectOfType <PlayerMove>();
		rigid = this.GetComponent<Rigidbody2D> ();
		monster = GameObject.FindObjectOfType<Monster> ();
		manager = GameObject.FindObjectOfType<GameManager> ();
		//Die = GameObject.FindGameObjectWithTag ("MonsterDie");
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
			//Die.GetComponent<AudioSource> ().Play ();
			this.GetComponent<AudioSource>().Play();
			Burn = (GameObject)Instantiate (BurnPrefab, this.transform.position, Quaternion.identity);
			Destroy (Burn, BurnTime);
		}
	}
}
