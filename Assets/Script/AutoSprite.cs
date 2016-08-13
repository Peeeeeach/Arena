using UnityEngine;
using System.Collections;

public class AutoSprite : MonoBehaviour
{
    public Sprite[] Front, Back, Left, Right;
    private int DirectionState = 0;
    private int NumState;
    //	public GameObject Front,Back,Left,Right;
    public float Least;
    private float LastTime;
    private Vector3 speed;
    public float gap;
    // Use this for initialization
    void Start()
    {
        NumState = 0;
        DirectionState = 0;
        LastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "PlayerSquare")
            speed = GetComponentInParent<Rigidbody2D>().velocity;
        else speed = GetComponent<Rigidbody2D>().velocity;

        if (speed.magnitude > Least)
        {
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.left)) < 45)
            {
                if (DirectionState != 1)
                {
                    LastTime = Time.time;
                    DirectionState = 1;
                    NumState = 0;
                }
                else if (Time.time - LastTime > gap)
                {
                    NumState = (NumState + 1) % (Left.Length);
                    LastTime = Time.time;
                }
            }
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.right)) < 45)
            {
                if (DirectionState != 2)
                {
                    LastTime = Time.time;
                    DirectionState = 2;
                    NumState = 0;
                }
                else if (Time.time - LastTime > gap)
                {
                    NumState = (NumState + 1) % (Right.Length);
                    LastTime = Time.time;
                }
            }
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.down)) < 45)
            {
                if (DirectionState != 3)
                {
                    LastTime = Time.time;
                    DirectionState = 3;
                    NumState = 0;
                }
                else if (Time.time - LastTime > gap)
                {
                    NumState = (NumState + 1) % (Front.Length);
                    LastTime = Time.time;
                }
            }
            if (Mathf.Abs(Vector3.Angle(speed, Vector3.up)) < 45)
            {
                if (DirectionState != 4)
                {
                    LastTime = Time.time;
                    DirectionState = 4;
                    NumState = 0;
                }
                else if (Time.time - LastTime > gap)
                {
                    NumState = (NumState + 1) % (Back.Length);
                    LastTime = Time.time;
                }
            }
            if (DirectionState == 1) gameObject.GetComponent<SpriteRenderer>().sprite = Left[NumState];
            if (DirectionState == 2) gameObject.GetComponent<SpriteRenderer>().sprite = Right[NumState];
            if (DirectionState == 3) gameObject.GetComponent<SpriteRenderer>().sprite = Front[NumState];
            if (DirectionState == 4) gameObject.GetComponent<SpriteRenderer>().sprite = Back[NumState];
        }
    }
}
