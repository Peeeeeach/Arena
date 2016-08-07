using UnityEngine;
using System.Collections;

public class AutoSprite : MonoBehaviour {
    public Sprite Front,Back,Left,Right;
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
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.left)) < 45) gameObject.GetComponent<SpriteRenderer>().sprite = Left;
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.right)) < 45) gameObject.GetComponent<SpriteRenderer>().sprite = Right;
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.down)) < 45) gameObject.GetComponent<SpriteRenderer>().sprite = Front;
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.up)) < 45) gameObject.GetComponent<SpriteRenderer>().sprite = Back;
        }
	}
}
