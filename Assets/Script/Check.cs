using UnityEngine;
using System.Collections;

public class Check : MonoBehaviour {
    public bool On;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(On);
	
	}
    void OnMouseEnter()
    {
        On = true;
    }
    void OnMouseExit()
    {
        On = false;
    }

}
