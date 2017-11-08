using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int CoinCount;
	public Text CoinsText;

	void Start () {

		Time.timeScale = 1;
	}

	void Update () {

		CoinsText.text = ("" + CoinCount);
	}
}
