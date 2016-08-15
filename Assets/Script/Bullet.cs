using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
	[SerializeField]private GameObject BulletPrefab;
	[SerializeField]private PlayerMove player;
	[SerializeField]private float SpaceTime;
	public AudioSource FireAudio;
	private List<GameObject> BulletList = new List<GameObject> ();
	private GameManager manager;
    public Check myCheck;
//	private List<int> hitTimes = new List<int> ();

	private Rigidbody2D rigid;
	public float BulletSpeed = 3.0f;
	public int maxHitTimes = 4;

	void Start () {
		manager = GameObject.FindObjectOfType<GameManager> ();
	}

	void Update () {
//		Debug.Log (Input.mousePosition);
//		if (Input.GetKeyDown (KeyCode.Space) == true)
		if (Input.GetMouseButtonDown (0) == true && manager.state == GameManager.GameState.Playing && myCheck.On) {
			//source.PlayOneShot(FireAudio);
			FireAudio.Play();
			StartCoroutine (GenerateBullet ());
		}
	}

	//生成螺旋子弹
	private IEnumerator GenerateBullet(){
		Vector3 NewPos;
		NewPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		NewPos.z = 0;
		for (int i = 0; i <= 9; i++) {
			if (manager.state == GameManager.GameState.Idle)
				yield break;
			GameObject bullet = (GameObject)Instantiate (BulletPrefab, NewPos, Quaternion.identity);	//第二个参数改动
			rigid = bullet.GetComponent<Rigidbody2D> ();
			Vector3 tempVector = new Vector3 (Mathf.Cos (0.2f * i * Mathf.PI), Mathf.Sin (0.2f * i * Mathf.PI), 0).normalized;
			rigid.velocity = tempVector * BulletSpeed;
			BulletList.Add (bullet);
//			hitTimes.Add (0);
			yield return new WaitForSeconds (SpaceTime);
		}
	}

	//消灭指定子弹
	public void EliminateBullet(GameObject bullet){
		Destroy (bullet);
		BulletList.Remove (bullet);
//		int i = BulletList.IndexOf (bullet);;
//		hitTimes.RemoveAt (i);
	}

	//清空子弹
	public void AllClear(){
		for (int i = BulletList.Count - 1; i >= 0; i--) {
			Destroy (BulletList [i]);
		}
		BulletList.Clear ();
	}
}
