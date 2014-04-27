using UnityEngine;
using System.Collections;

public class LibraryRulesLeftButton : GUIButton 
{
	public GameObject parentObj;

	private void PageLeft()
	{
		LibraryRulesPanel panelScript = parentObj.GetComponent<LibraryRulesPanel>();
		panelScript.PageLeft();
	}

	public override void OnMouseDown()
	{
		if(parentObj != null)
		{
			LibraryRulesPanel panelScript = parentObj.GetComponent<LibraryRulesPanel>();

			if(panelScript != null)
			{
				int pageIndex = panelScript.GetPageIndex();

				if(pageIndex > 0)
				{
					Hashtable scaleDown = new Hashtable();
					scaleDown.Add("scale", mScaleDown);
					scaleDown.Add("time", 0.10f);
					
					Hashtable scaleUp = new Hashtable();
					scaleUp.Add("scale", mScaleUp);
					scaleUp.Add("time", 0.10f);
					scaleUp.Add("delay", 0.15f);
					scaleUp.Add("oncomplete", "PageLeft");
					
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
