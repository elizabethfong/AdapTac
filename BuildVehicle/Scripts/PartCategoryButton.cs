using UnityEngine;
using System.Collections;

public class PartCategoryButton : GUIButton 
{
	public Part.PartCategory category;

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

		
		if(buttonPress)
		{
			audio.PlayOneShot(buttonPress);
		}

		LibraryPartsPanel libPartsPanelScript = transform.parent.GetComponent<LibraryPartsPanel>();
		libPartsPanelScript.ShowPanels(category);
	}
}
