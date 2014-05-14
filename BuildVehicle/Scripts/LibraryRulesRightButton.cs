using UnityEngine;
using System.Collections;

public class LibraryRulesRightButton : GUIButton 
{
	public GameObject parentObj;

	private void PageRight()
	{
		LibraryRulesPanel panelScript = parentObj.GetComponent<LibraryRulesPanel>();
		panelScript.PageRight();
	}

	public override void OnMouseDown()
	{
		if(parentObj != null)
		{
			LibraryRulesPanel panelScript = parentObj.GetComponent<LibraryRulesPanel>();
			
			if(panelScript != null)
			{
				int pageIndex = panelScript.GetPageIndex();
				
				if(pageIndex < panelScript.rulesPages.Length - 1)
				{					
					Hashtable scaleDown = new Hashtable();
					scaleDown.Add("scale", mScaleDown);
					scaleDown.Add("time", 0.10f);
					
					Hashtable scaleUp = new Hashtable();
					scaleUp.Add("scale", mScaleUp);
					scaleUp.Add("time", 0.10f);
					scaleUp.Add("delay", 0.15f);
					scaleUp.Add("oncomplete", "PageRight");
					
					iTween.ScaleTo(gameObject, scaleDown);
					iTween.ScaleTo(gameObject, scaleUp);
					
					if(buttonPress)
					{
						audio.PlayOneShot(buttonPress);
					}
				}
			}
		}
	}
}
