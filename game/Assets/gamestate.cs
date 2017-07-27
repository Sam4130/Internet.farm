using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamestate : MonoBehaviour {
	public static int karma_count = 0;
	bool restart_flag = false;
	// Use this for initialization
	void Start () {
		GameObject.Find ("karma").GetComponent<Text> ().text = "Karma " + gamestate.karma_count;
	}
	IEnumerator gameover () {

		yield return new WaitForSeconds (30);
		GameObject.Find ("GameEnd").GetComponent<Text> ().enabled = true;
		GameObject.Find ("GameEnd").GetComponent<Text> ().text = "Game Over!  Score " + karma_count;
		restart_flag = true;


	}
	IEnumerator restart () {
		yield return new WaitForSeconds (3);
		GameObject.Find ("GameEnd").GetComponent<Text> ().enabled = false;
		GameObject.Find ("karma").GetComponent<Text> ().text = "Karma " + gamestate.karma_count;
		karma_count = 0;

	}

	// Update is called once per frame
	void Update () {
		if (karma_count > 0) {
			StartCoroutine(gameover());
		}
		if (restart_flag) {
			restart_flag = false;
			StartCoroutine (restart ());
		}
	}
}
