using UnityEngine;
using System.Collections;

public class ShelfTriggerBox : MonoBehaviour 
{
	public Part.PartCategory partCetegory = Part.PartCategory.CATEGORY_NONE;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			//Debug.Log("Enter...");
			Model.playerCharacter.curTriggerBox = partCetegory;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			//Debug.Log("Exit...");
			Model.playerCharacter.curTriggerBox = Part.PartCategory.CATEGORY_NONE;
		}
	}
}
