using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LibraryPartsPanel : MonoBehaviour 
{
	public GameObject[] partPanels;
	public bool shufflePartsAtStart = true;

	private Part[] cockpitParts;
	private Part[] engineParts;
	private Part[] frameParts;
	private Part[] tireParts;
	private Part[] weaponParts;

	void Start()
	{
		//Debug.Log("LibraryPartsPanel::Start()");
		InitializePanels();

		if(shufflePartsAtStart)
		{
			ShuffleParts();
			ShufflePanels();
		}

		ShowPanels(Part.PartCategory.CATEGORY_COCKPIT);

		gameObject.SetActive(false);
	}

	void Awake()
	{

	}

	private void Shuffle(Part[] pArray)
	{
		for (int t = 0; t < pArray.Length; t++ )			
		{			
			Part tmp = pArray[t];			
			int r = Random.Range(t, pArray.Length);			
			pArray[t] = pArray[r];			
			pArray[r] = tmp;			
		}
	}

	public void ShuffleParts()
	{
		//We will want to shuffle all part icons in the PartManager.  This updates the actual tables in the PartManager.  This makes it consistent from screen to screen.
		Model.partManager.ShufflePartIcons(Part.PartCategory.CATEGORY_COCKPIT);
		Model.partManager.ShufflePartIcons(Part.PartCategory.CATEGORY_ENGINE);
		Model.partManager.ShufflePartIcons(Part.PartCategory.CATEGORY_FRAME);
		Model.partManager.ShufflePartIcons(Part.PartCategory.CATEGORY_TIRE);
		Model.partManager.ShufflePartIcons(Part.PartCategory.CATEGORY_WEAPON);
	}

	private void InitializePanels()
	{
		Dictionary<string, Part> partTable = Model.partManager.GetPartCategoryTable(Part.PartCategory.CATEGORY_COCKPIT);
		
		int i = 0;
		cockpitParts = new Part[partTable.Count];
		foreach(Part part in partTable.Values)
		{
			cockpitParts[i++] = part;
		}

		partTable = Model.partManager.GetPartCategoryTable(Part.PartCategory.CATEGORY_ENGINE);
		
		i = 0;
		engineParts = new Part[partTable.Count];
		foreach(Part part in partTable.Values)
		{
			engineParts[i++] = part;
		}

		partTable = Model.partManager.GetPartCategoryTable(Part.PartCategory.CATEGORY_FRAME);
		
		i = 0;
		frameParts = new Part[partTable.Count];
		foreach(Part part in partTable.Values)
		{
			frameParts[i++] = part;
		}
		
		partTable = Model.partManager.GetPartCategoryTable(Part.PartCategory.CATEGORY_TIRE);
		
		i = 0;
		tireParts = new Part[partTable.Count];
		foreach(Part part in partTable.Values)
		{
			tireParts[i++] = part;
		}
		
		partTable = Model.partManager.GetPartCategoryTable(Part.PartCategory.CATEGORY_WEAPON);
		
		i = 0;
		weaponParts = new Part[partTable.Count];
		foreach(Part part in partTable.Values)
		{
			weaponParts[i++] = part;
		}
	}

	public void ShufflePanels()
	{
		Shuffle(cockpitParts);
		Shuffle(engineParts);
		Shuffle(frameParts);
		Shuffle(tireParts);
		Shuffle(weaponParts);
	}

	public void ShowPanels(Part.PartCategory pCategory)
	{
		PartPanel panelScript;
		int i;
		Part part;

		switch(pCategory)
		{
			case Part.PartCategory.CATEGORY_COCKPIT:
				for(i = 0; i < cockpitParts.Length; i++)
				{
					part = cockpitParts[i];
					panelScript = partPanels[i].GetComponent<PartPanel>();
					panelScript.SetPanel(part.partId, part.partIconFrameID);
				}
				break;
			case Part.PartCategory.CATEGORY_ENGINE:
				for(i = 0; i < engineParts.Length; i++)
				{
					part = engineParts[i];
					panelScript = partPanels[i].GetComponent<PartPanel>();
					panelScript.SetPanel(part.partId, part.partIconFrameID);
				}
				break;
			case Part.PartCategory.CATEGORY_FRAME:
				for(i = 0; i < frameParts.Length; i++)
				{
					part = frameParts[i];
					panelScript = partPanels[i].GetComponent<PartPanel>();
					panelScript.SetPanel(part.partId, part.partIconFrameID);
				}
				break;
			case Part.PartCategory.CATEGORY_TIRE:
				for(i = 0; i < tireParts.Length; i++)
				{
					part = tireParts[i];
					panelScript = partPanels[i].GetComponent<PartPanel>();
					panelScript.SetPanel(part.partId, part.partIconFrameID);
				}
				break;
			case Part.PartCategory.CATEGORY_WEAPON:
				for(i = 0; i < weaponParts.Length; i++)
				{
					part = weaponParts[i];
					panelScript = partPanels[i].GetComponent<PartPanel>();
					panelScript.SetPanel(part.partId, part.partIconFrameID);
				}
				break;
			default:
				break;
		}
	}
}
