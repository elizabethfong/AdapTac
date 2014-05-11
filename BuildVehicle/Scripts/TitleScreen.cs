using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	private float mScreenStartTime;

	// Use this for initialization
	void Start () 
	{
		mScreenStartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > mScreenStartTime + 3)
		{
			GA.API.Design.NewEvent("TitleScreen:Play Pressed");
			AutoFade.LoadLevel("TitleScreen", 0.75f, 0.75f, Color.black);
		}
	}
}
