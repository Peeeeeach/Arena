using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	[SerializeField]private Text textScore = null;
	[SerializeField]private Text textBest = null;
	[SerializeField]private Text textTime = null;

	public int score{
		set{
			textScore.text = "Score:" + value.ToString();
		}
	}

	public int best{
		set{
			textBest.text = "Best:" + value.ToString ();
		}
	}

	public float time{
		set{
			textTime.text = "Time:" + value.ToString ("0.0");
		}
	}
}
