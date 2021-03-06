﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

/// <summary>
	//A current issue would be that if you change coin count in the inspector, the text
	//does not visually show that change.  There's probably an extra check that I can write
	//to make sure that the NumberText digits display the counted values.

	//Similarly, this occurs in the other UI counters as well.  I don't know how to synthesize
	//the two code values. It would have to do with the "score" int in the numberText Script,
	//but the fix I thought of made all of the values the same. I'll ask about it.

	//I'm not making three different NumberText scripts.  That would be silly.
/// </summary>

	public int globalTimer = 0;
	// global timer!

	public int ActualCoinValue;
	// this internally keeps track of the coins that the player has
	public int CoinCount;
	//This internally keeps track of the coin value that is shown on screen.
	public int LifeCount;
	//This internally keeps track of the lives that the player currently has.
	public int StarCount;
	//This internally keeps track of the stars that the player currently has.

	public GameObject LifeManager;
	public GameObject StarManager;

	void Start () {
	}
		

	void Update () {

		globalTimer++; // increment global timer by 1 every frame
		// if it's greater than 64, reset to zero
		if (globalTimer > 64) {
			globalTimer = 0;
		}

		// the ActualCoinValue is incremented every time mario picks something up
		// check out the MarioPickup script for more
		if (CoinCount < ActualCoinValue) {
			// every four frames increment the CoinCount by one if it's lower than the ActualCoinValue
			if (globalTimer % 4 == 0) {
				CoinCount++;
			}
		}
		// up to the actual coin value
		if (CoinCount >= ActualCoinValue) {
			CoinCount = ActualCoinValue;
		}

		//LifeCount currently defined in inspector since nothing can kill Mario
		//He is immortal.

		if (LifeCount == 0) {
			//Mario DIES
		}
	}
}
