using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource BGM;

/// <summary>
	// This music script will be adjusted as we continue to make progress!  For now this is the basic script that we have.
	// One thing I'd like to fix is that there's a very quick pause before the audio loops. Hardly even noticable.
/// </summary>

	void Start () {
		BGM.Play();

		//For loop testing purposes...
		//BGM.time = 142f;

	}
	
	// Update is called once per frame
	void Update () {
		if (BGM.time >= 143.8f) { //143.8 is the float for the time of the song.  When the song gets to the end...
			BGM.time = 74f; //We loop back to the part of the song that doesn't have the intro in it.
	}
}
}
