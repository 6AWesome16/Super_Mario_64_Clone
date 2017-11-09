using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPickup : MonoBehaviour {

	private GameManager gm;
	public GameObject CoinManager;	
	public GameObject LifeManager;
	public GameObject StarManager;


	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}

	void Update () {

		CoinManager.GetComponent<NumberText> ().score = gm.CoinCount;
		// the coin value shown on screen is equal to the CoinCount in the GameManager

	}

	//The Yellow Coins must be tagged as YellowCoin in the inspector

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("YellowCoin")) {
			Destroy (col.gameObject);
			gm.ActualCoinValue += 1;
		}

		if (col.CompareTag ("RedCoin")) {
			Destroy (col.gameObject);
			//insert whatever happens when a red coin is obtained
		}

		if (col.CompareTag ("OneUpMushroom")) {
			Destroy (col.gameObject);
			gm.LifeCount += 1;
			LifeManager.GetComponent<NumberText> ().AddScore (1);
		//
		}
		if (col.CompareTag ("Star")) {
			Destroy (col.gameObject);
			StarManager.GetComponent<NumberText> ().AddScore (1);
			//insert whatever happens when a red coin is obtained
		}

		//Other types of objects can be tagged using this script
	}
}
