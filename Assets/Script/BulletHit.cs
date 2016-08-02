using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {
	private Bullet bulletManager;
	private int MaxHitTimes = 4;

	void Start () {
		bulletManager = GameObject.FindObjectOfType<Bullet> ();
	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D hitInfo){
		if (hitInfo.gameObject.tag.Equals ("Wall")) {
			MaxHitTimes--;
			if (MaxHitTimes == 0) 
				bulletManager.EliminateBullet (this.gameObject);
		}
	}
}
