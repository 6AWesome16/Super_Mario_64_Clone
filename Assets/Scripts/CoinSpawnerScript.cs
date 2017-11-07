using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour {

	public Transform normalCoin;
	public Transform floatingCoin;
	public int spawnType = 0;


	// 0 = grounded single coin
	// 1 = floating single coin
	// 2 = grounded line
	// 3 = floating line
	// 4 = floating vertical line
	// 5 = grounded ring
	// 6 = floating ring
	// 7 = floating vertical ring



	// Use this for initialization
	void Start () {

		// grounded single coin
		if (spawnType == 0) {
			Instantiate (normalCoin, transform.position, Quaternion.identity, transform);
			// grounded line
		}
		// floating single coin
		else if (spawnType == 1) {
			Instantiate (floatingCoin, transform.position, Quaternion.identity, transform);
		// grounded line
		} else if (spawnType == 2) {
			float coinSpace = -2f;
			for (int i = 0; i < 5; i++) {
				Instantiate (normalCoin, transform.position + transform.forward * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 1f;
			}
		// floating line
		} else if (spawnType == 3) {
			float coinSpace = -2f;
			for (int i = 0; i < 5; i++) {
				Instantiate (floatingCoin, transform.position + transform.forward * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 1f;
			}
		// floating vertical line
		} else if (spawnType == 4) {
			float coinSpace = -2f;
			for (int i = 0; i < 5; i++) {
				Instantiate (floatingCoin, transform.position + transform.up * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 1f;
			}
		// grounded ring
		} else if (spawnType == 5) {
			float coinSpace = -0.5f;
			for (int i = 0; i < 2; i++) {
				Instantiate (normalCoin, transform.position + transform.forward * coinSpace + transform.right * 1f, Quaternion.identity, transform);
				Instantiate (normalCoin, transform.position + transform.forward * coinSpace + transform.right * -1f, Quaternion.identity, transform);
				Instantiate (normalCoin, transform.position + transform.right * coinSpace + transform.forward * 1f, Quaternion.identity, transform);
				Instantiate (normalCoin, transform.position + transform.right * coinSpace + transform.forward * -1f, Quaternion.identity, transform);
				coinSpace = coinSpace + 1f;
			}
		// floating ring
		} else if (spawnType == 6) {
			float coinSpace = -0.5f;
			for (int i = 0; i < 2; i++) {
				Instantiate (floatingCoin, transform.position + transform.forward * coinSpace + transform.right * 1f, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.forward * coinSpace + transform.right * -1f, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.right * coinSpace + transform.forward * 1f, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.right * coinSpace + transform.forward * -1f, Quaternion.identity, transform);
				coinSpace = coinSpace + 1f;
			}
		// floating vertical ring
		} else if (spawnType == 7) {
			float coinSpace = -0.5f;
			for (int i = 0; i < 2; i++) {
				Instantiate (floatingCoin, transform.position + transform.up * coinSpace + transform.right * 1f, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.up * coinSpace + transform.right * -1f, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.right * coinSpace + transform.up * 1f, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.right * coinSpace + transform.up * -1f, Quaternion.identity, transform);
				coinSpace = coinSpace + 1f;
			}
		}


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
