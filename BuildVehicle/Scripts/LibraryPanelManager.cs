using UnityEngine;
using System.Collections;

public class LibraryPanelManager : MonoBehaviour {

	public GameObject rulesContainer;
	public GameObject partsContainer;

	public void ShowRulesPanel()
	{
		rulesContainer.SetActive(true);
		partsContainer.SetActive(false);
	}
	
	public void ShowPartsPanel()
	{
		rulesContainer.SetActive(false);
		partsContainer.SetActive(true);
	}
}
