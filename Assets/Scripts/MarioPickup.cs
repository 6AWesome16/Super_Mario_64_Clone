using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPickup : MonoBehaviour {

	private GameManager gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}

	//The Coins must be tagged as YellowCoin in the inspector

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("YellowCoin")) {
			Destroy (col.gameObject);
			gm.CoinCount += 1;
		}
	}
}
