using UnityEngine;
using System.Collections;

public class FireballRotate : MonoBehaviour {
    private Vector3 speed;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        speed = GetComponent<Rigidbody2D>().velocity;
//        Debug.Log(Mathf.Atan2(speed.y, speed.x));
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(speed.y,speed.x)*360/2/Mathf.PI);
/*        if (Mathf.Abs(Vector3.Angle(speed, Vector3.left)) < 45) transform.rotation = Quaternion.Euler(0,0,180);
        if (Mathf.Abs(Vector3.Angle(speed, Vector3.right)) < 45) transform.rotation = Quaternion.Euler(0,0,0); 
        if (Mathf.Abs(Vector3.Angle(speed, Vector3.down)) < 45) transform.rotation = Quaternion.Euler(0,0,-90);
        if (Mathf.Abs(Vector3.Angle(speed, Vector3.up)) < 45) transform.rotation = Quaternion.Euler(0,0,90);
*/
    }
}
