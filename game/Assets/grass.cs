using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grass : MonoBehaviour {
	Sprite[] stage = new Sprite[5]; // = Resources.Load<Sprite>("Sprites/droplet");

	int i = 0;
	Vector3 orig;

	// Use this for initialization
	void Start () {
		stage[0] = Resources.Load<Sprite>("Sprites/dirt");
		stage[1] = Resources.Load<Sprite>("Sprites/tilled_dirt");
		stage[2] = Resources.Load<Sprite>("Sprites/seedling");
		stage[3] = Resources.Load<Sprite>("Sprites/full_plant");

		orig = GetComponent<Transform> ().localScale;
		//GameObject.Find("karma").GetComponent<Text>().text = "Karma 50";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MemeDestroy () {

		yield return new WaitForSeconds (2);
		i = 0;
		GetComponent<BoxCollider2D> ().enabled = true;
		GetComponent<SpriteRenderer> ().sprite = stage[i];
		GetComponent<Transform> ().localScale = orig;

	}
	void OnMouseDown()
	{
		/*Do your stuff here*/

		if (i == 4) {
			gamestate.karma_count = gamestate.karma_count + Random.Range (1, 50);
			GameObject.Find ("karma").GetComponent<Text> ().text = "Karma " + gamestate.karma_count;
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/" +  Random.Range (1, 28));
			GetComponent<Transform> ().localScale *= 6;
			i = 0;
			GetComponent<SpriteRenderer> ().sortingOrder = gamestate.karma_count;
			GetComponent<BoxCollider2D> ().enabled = false;

			StartCoroutine(MemeDestroy());
		} else
		{
			GetComponent<SpriteRenderer> ().sprite = stage[i];
			GetComponent<Transform> ().localScale = orig;
		}
		i++;



	}

}
