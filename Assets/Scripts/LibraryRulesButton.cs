using UnityEngine;
using System.Collections;

public class LibraryRulesButton : GUIButton {

	public GameObject mainUIContainer;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void OnMouseDown()
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

		//GameObject parent = this.transform.parent.transform.parent.gameObject;
		
		if(mainUIContainer != null)
		{
			LibraryPanelManager libraryPanelManager = mainUIContainer.GetComponent<LibraryPanelManager>();
			
			if(libraryPanelManager != null)
			{
				libraryPanelManager.ShowRulesPanel();
			}
		}
		
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
