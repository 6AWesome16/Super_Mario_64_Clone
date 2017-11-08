using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberText : MonoBehaviour {

/// <summary>
	//The numberText Script keeps track of the visual numbers that the player sees.

	//This is an old code that someone helped me with.
	//For some reason I didn't know what it meant to comment code.
	//The person didn't tell me to comment any of this though??? Like, why? But anyway.

	//A thing to note would be that I don't know how to have the digits slowly appear on the screen.
	//For example, the number should begin in what eventually becomes the third digit's place.  

	//A current issue would be that if you change coin count in the inspector, the text
	//does not visually show that change.  There's probably an extra check that I can write
	//to make sure that the NumberText digits display the counted values.

	//Similarly, this occurs in the other UI counters as well.  I don't know how to synthesize
	//the two code values. It would have to do with the "score" int in the numberText Script,
	//but the fix I thought of made all of the values the same. I'll ask about it.

	//I'm not making three different NumberText scripts.  That would be silly.
/// </summary>

	public int score;
	public Sprite[] numberImage;
	public GameObject[] scoreDigits;

	private char[] convertedScore;

	void Start()
	{
		score = 0;
		//The score value is what gets fed through to the convertedScore
	}

	void Update()
	{
		
		int limitedScore = (int)Mathf.Min(score, 999);
		convertedScore = limitedScore.ToString().ToCharArray();
		for (int i = 0; i < convertedScore.Length; i++)
		{
			int scoreDigit = convertedScore[(convertedScore.Length - 1) - i] - 48;
			//idk why 48 is the number there.  I have no idea.
			scoreDigits[i].gameObject.GetComponent<Image>().sprite = numberImage[scoreDigit];
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
	}

	public void ResetScore()
	{
		score = 0;
		for (int i = 0; i < scoreDigits.Length; i++)
		{
			scoreDigits[i].gameObject.GetComponent<Image>().sprite = numberImage[0];
		}
	}
}
