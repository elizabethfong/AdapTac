using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
	private float mScreenStartTime;

	// Use this for initialization
	void Start () 
	{
		mScreenStartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > mScreenStartTime + 2 )
		{
			AutoFade.LoadLevel("StudioScreen", 0.5f, 0.5f, Color.black);
		}
	}
}
