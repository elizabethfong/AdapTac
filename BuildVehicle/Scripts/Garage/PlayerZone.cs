using UnityEngine;
using System.Collections;

public class PlayerZone : MonoBehaviour 
{
    public enum Zone { ONE, TWO, THREE, FOUR };

    public Zone zoneID = Zone.ONE;

	void OnTriggerEnter(Collider col)
	{
		if((Model.playerCharacter.curPartCarried == null) || (Model.playerCharacter.homeZone != zoneID)) return;

		if(col.gameObject.tag == "Player")
		{
			switch(Model.playerCharacter.curPartCarried.partCategory)
			{
				case Part.PartCategory.CATEGORY_COCKPIT:
					Model.playerCharacter.hasCockpit = true;
					break;
				case Part.PartCategory.CATEGORY_ENGINE:
					Model.playerCharacter.hasEngine = true;
					break;
				case Part.PartCategory.CATEGORY_FRAME:
					Model.playerCharacter.hasFrame = true;
					break;
				case Part.PartCategory.CATEGORY_TIRE:
					Model.playerCharacter.hasTire = true;
					break;
				case Part.PartCategory.CATEGORY_WEAPON:
					Model.playerCharacter.hasWeapon = true;
					break;
				default:
					break;
			}

			Model.inventorySlotManager.AssignInventorySlot(Model.playerCharacter.curPartCarried);
			Model.playerCharacter.carriedPart.SetActive(false);
			Model.playerCharacter.curPartCarried = null;
		}
	}
}
