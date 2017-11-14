using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour {

	public Transform normalCoin;
	public Transform floatingCoin;

	public Transform mario; // assign in Inspector!

	public enum SpawnerType {
		SingleGrounded,
		SingleFloating,
		LineGrounded,
		LineFloating,
		VerticalLineFloating,
		RingGrounded,
		RingFloating,
		VerticalRingFloating
	}

	public SpawnerType myCurrentType = SpawnerType.SingleGrounded;



	// Use this for initialization
	void Start () {

		// grounded single coin
		if (myCurrentType == SpawnerType.SingleGrounded) {
			Instantiate (normalCoin, transform.position, Quaternion.identity, transform);
			// grounded line
		}
		// floating single coin
		else if (myCurrentType == SpawnerType.SingleFloating) {
			Instantiate (floatingCoin, transform.position, Quaternion.identity, transform);
		// grounded line
		} else if (myCurrentType == SpawnerType.LineGrounded) {
			float coinSpace = -4f;
			for (int i = 0; i < 5; i++) {
				Instantiate (normalCoin, transform.position + transform.forward * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 2f;
			}
		// floating line
		} else if (myCurrentType == SpawnerType.LineFloating) {
			float coinSpace = -4f;
			for (int i = 0; i < 5; i++) {
				Instantiate (floatingCoin, transform.position + transform.forward * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 2f;
			}
		// floating vertical line
		} else if (myCurrentType == SpawnerType.VerticalLineFloating) {
			float coinSpace = -4f;
			for (int i = 0; i < 5; i++) {
				Instantiate (floatingCoin, transform.position + transform.up * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 2f;
			}
		// grounded ring
		} else if (myCurrentType == SpawnerType.RingGrounded) {
			float coinSpace = -2f;
			for (int i = 0; i < 2; i++) {
				Instantiate (normalCoin, transform.position + transform.forward * coinSpace, Quaternion.identity, transform);
				Instantiate (normalCoin, transform.position + transform.right * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 4f;
			}
			Instantiate (normalCoin, transform.position + transform.forward * 1.5f + transform.right * 1.5f, Quaternion.identity, transform);
			Instantiate (normalCoin, transform.position + transform.forward * -1.5f + transform.right * 1.5f, Quaternion.identity, transform);
			Instantiate (normalCoin, transform.position + transform.forward * 1.5f + transform.right * -1.5f, Quaternion.identity, transform);
			Instantiate (normalCoin, transform.position + transform.forward * -1.5f + transform.right * -1.5f, Quaternion.identity, transform);
		// floating ring
		} else if (myCurrentType == SpawnerType.RingFloating) {
			float coinSpace = -2f;
			for (int i = 0; i < 2; i++) {
				Instantiate (floatingCoin, transform.position + transform.forward * coinSpace, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.right * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 4f;
			}
			Instantiate (floatingCoin, transform.position + transform.forward * 1.5f + transform.right * 1.5f, Quaternion.identity, transform);
			Instantiate (floatingCoin, transform.position + transform.forward * -1.5f + transform.right * 1.5f, Quaternion.identity, transform);
			Instantiate (floatingCoin, transform.position + transform.forward * 1.5f + transform.right * -1.5f, Quaternion.identity, transform);
			Instantiate (floatingCoin, transform.position + transform.forward * -1.5f + transform.right * -1.5f, Quaternion.identity, transform);
		// floating vertical ring
		} else if (myCurrentType == SpawnerType.VerticalRingFloating) {
			float coinSpace = -2f;
			for (int i = 0; i < 2; i++) {
				Instantiate (floatingCoin, transform.position + transform.up * coinSpace, Quaternion.identity, transform);
				Instantiate (floatingCoin, transform.position + transform.right * coinSpace, Quaternion.identity, transform);
				coinSpace = coinSpace + 4f;
			}
			Instantiate (floatingCoin, transform.position + transform.up * 1.5f + transform.right * 1.5f, Quaternion.identity, transform);
			Instantiate (floatingCoin, transform.position + transform.up * -1.5f + transform.right * 1.5f, Quaternion.identity, transform);
			Instantiate (floatingCoin, transform.position + transform.up * 1.5f + transform.right * -1.5f, Quaternion.identity, transform);
			Instantiate (floatingCoin, transform.position + transform.up * -1.5f + transform.right * -1.5f, Quaternion.identity, transform);
		}


		
	}
	
	// Update is called once per frame
	void Update () {

		// lod script
		// if distance to mario is beyond a certain level check all of the children (coins) and turn off mesh renderer
//		if (Vector3.Distance (transform.position, mario.position) >= 20f) {
//			foreach (MeshRenderer r in GetComponentsInChildren(typeof(MeshRenderer))) {
//				r.enabled = false;
//			}
//		} else {
//			foreach (MeshRenderer r in GetComponentsInChildren(typeof(MeshRenderer))) {
//				r.enabled = true;
//			}
//		}
		
	}
}
