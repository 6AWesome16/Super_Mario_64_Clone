using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(BobombView))]
public class FieldOfViewEditor : Editor {

	void OnSceneGUI(){
		BobombView bbv = (BobombView)target;
		Handles.color = Color.white;
		Handles.DrawWireArc (bbv.transform.position, Vector3.up, Vector3.forward, 360, bbv.ViewRadius);
		Vector3 ViewAngleA = bbv.DirFromAngle (-bbv.ViewAngle / 2, false);
		Vector3 ViewAngleB = bbv.DirFromAngle (bbv.ViewAngle / 2, false);

		Handles.DrawLine (bbv.transform.position, bbv.transform.position + ViewAngleA * bbv.ViewRadius);
		Handles.DrawLine (bbv.transform.position, bbv.transform.position + ViewAngleB * bbv.ViewRadius);
	}

}
