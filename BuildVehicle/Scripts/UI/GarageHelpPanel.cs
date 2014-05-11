using UnityEngine;
using System.Collections;

public class GarageHelpPanel : MonoBehaviour 
{
	public enum Mode { IDLE, HIDE, SHOW };

	public Vector3 hidePos;
	public Vector3 showPos;

	private Mode mMode = Mode.HIDE;

	void OnMouseDown()
	{
		switch(mMode)
		{
			case Mode.HIDE:
				gameObject.transform.localPosition = showPos;
				mMode = Mode.SHOW;
				break;
			case Mode.SHOW:
				gameObject.transform.localPosition = hidePos;
				mMode = Mode.HIDE;
				break;
			default:
				break;
		}
	}
}
