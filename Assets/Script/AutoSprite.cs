using UnityEngine;
using System.Collections;

public class AutoSprite : MonoBehaviour {
    public Sprite Front,Back,Left,Right;
//	public GameObject Front,Back,Left,Right;
    public float Least;
    private Vector3 speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "PlayerSquare")
            speed = GetComponentInParent<Rigidbody2D>().velocity;
        else speed = GetComponent<Rigidbody2D>().velocity;
        if (speed.magnitude>Least)
        {
			if (Mathf.Abs (Vector3.Angle (speed, Vector3.left)) < 45) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Left;
//				Front.SetActive(false);
//				Back.SetActive (false);
//				Left.SetActive (true);
//				Right.SetActive (false);
			}
			if (Mathf.Abs (Vector3.Angle (speed, Vector3.right)) < 45) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Right;
//				Front.SetActive(false);
//				Back.SetActive (false);
//				Left.SetActive (false);
//				Right.SetActive (true);
			}
			if (Mathf.Abs (Vector3.Angle (speed, Vector3.down)) < 45) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Front;
//				Front.SetActive(true);
//				Back.SetActive (false);
//				Left.SetActive (false);
//				Right.SetActive (false);
			}
			if (Mathf.Abs (Vector3.Angle (speed, Vector3.up)) < 45) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Back;
//				Front.SetActive(false);
//				Back.SetActive (true);
//				Left.SetActive (false);
//				Right.SetActive (false);
			}
        }
	}
}
