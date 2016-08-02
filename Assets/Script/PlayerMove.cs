using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	private Rigidbody2D rigid;
	private GameManager manager;

	public float move_speed = 6.0f;
	public float move_force = 2.0f;
	public float force_scale = 1.5f;

	void Start () {
		rigid = this.GetComponent<Rigidbody2D> ();
		manager = GameObject.FindObjectOfType<GameManager> ();
	}

	void Update () {
//		Vector3 input = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
//		this.transform.Translate (input * move_speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.A) == true) {
			if(rigid.velocity.x <= 0)
				rigid.AddForce (new Vector3(-1,0,0) * move_force, ForceMode2D.Force);
			else
				rigid.AddForce (new Vector3(-1,0,0) * move_force * force_scale, ForceMode2D.Force);
		}
		if (Input.GetKey (KeyCode.W) == true) {
			if(rigid.velocity.y >= 0)
				rigid.AddForce (new Vector3(0,1,0) * move_force, ForceMode2D.Force);
			else
				rigid.AddForce (new Vector3(0,1,0) * move_force * force_scale, ForceMode2D.Force);
		}
		if (Input.GetKey (KeyCode.D) == true) {
			if(rigid.velocity.x >= 0)
				rigid.AddForce (new Vector3(1,0,0) * move_force, ForceMode2D.Force);
			else
				rigid.AddForce (new Vector3(1,0,0) * move_force * force_scale, ForceMode2D.Force);
		}
		if (Input.GetKey (KeyCode.S) == true) {
			if(rigid.velocity.y <= 0)
				rigid.AddForce (new Vector3(0,-1,0) * move_force, ForceMode2D.Force);
			else
				rigid.AddForce (new Vector3(0,-1,0) * move_force * force_scale, ForceMode2D.Force);
		}
	}

	public Vector3 GetPlayerPosition(){
		return this.transform.position;
	}

	void OnCollisionEnter2D(Collision2D hitInfo){
		if (hitInfo.gameObject.tag.Equals ("Bullet")) {
			manager.state = GameManager.GameState.GameOver;
		}
	}
}