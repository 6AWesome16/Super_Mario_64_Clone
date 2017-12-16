using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPickup : MonoBehaviour {

	private GameManager gm;
	public GameObject CoinManager;	
	public GameObject LifeManager;
	public GameObject StarManager;

	public AudioClip coin;
	public AudioClip mush;

/// <summary>
	// Mario picks lots of stuff up using this script.
	// Things must be tagged in the inspector for Mario's pickup to work!

	// For some reason, Mario controls the coin sound.  It's the only way I know it will work.
	// If we need to change it later, we can!
/// </summary>


	void Start () {
		//The Game Manager NEEDS to be tagged as GameController
		gm = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();	
	}

	void Update () {
		CoinManager.GetComponent<NumberText> ().score = gm.CoinCount;

		// the coin value shown on screen is equal to the CoinCount in the GameManager

	}

	//The Yellow Coins must be tagged as YellowCoin in the inspector

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("YellowCoin")) {
			AudioSource ourAudio = GetComponent<AudioSource> ();
			ourAudio.PlayOneShot (coin);
			Destroy (col.gameObject);
			gm.ActualCoinValue += 1;
		}

		if (col.CompareTag ("RedCoin")) {
			Destroy (col.gameObject);
			//insert whatever happens when a red coin is obtained
		}

		if (col.CompareTag ("OneUpMushroom")) {
			AudioSource ourAudio = GetComponent<AudioSource> ();
			ourAudio.PlayOneShot (mush);
			Destroy (col.gameObject);
			gm.LifeCount += 1;
			LifeManager.GetComponent<NumberText> ().AddScore (1);
		//
		}
		if (col.CompareTag ("Star")) {
			Destroy (col.gameObject);
			StarManager.GetComponent<NumberText> ().AddScore (1);
			GameObject.Find ("MusicManager").GetComponent<AudioSource> ().clip = GameObject.Find ("MusicManager").GetComponent<MusicManager>().StarMusic;
			GameObject.Find ("MusicManager").GetComponent<MusicManager>().BGM.Play();
		}

		//Other types of objects can be tagged using this script
	}
		
}
