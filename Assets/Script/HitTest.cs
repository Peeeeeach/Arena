using UnityEngine;
using System.Collections;

public class HitTest : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S) == true) {
			this.transform.Translate (new Vector3 (0, -1, 0) * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D hitInfo){
		if (hitInfo.gameObject.tag.Equals ("Wall")) {
//			Debug.Log("惊了"+count);
		}
	}
}
