using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour {
	public string levelName = "";
	public AudioClip buttonPress;

	public Vector3 mScaleDown = new Vector3(0.85f, 0.85f, 0.85f);
	public Vector3 mScaleUp = new Vector3(1.0f, 1.0f, 1.0f);

	public virtual void OnMouseDown()
	{
		Hashtable scaleDown = new Hashtable();
		scaleDown.Add("scale", mScaleDown);
		scaleDown.Add("time", 0.10f);

		Hashtable scaleUp = new Hashtable();
		scaleUp.Add("scale", mScaleUp);
		scaleUp.Add("time", 0.10f);
		scaleUp.Add("delay", 0.15f);

		iTween.ScaleTo(gameObject, scaleDown);
		iTween.ScaleTo(gameObject, scaleUp);

		if(buttonPress)
		{
			audio.PlayOneShot(buttonPress);
		}

		if(levelName != "")
		{
			AutoFade.LoadLevel(levelName, 1.0f, 1.0f, Color.black);
		}
	}
}
