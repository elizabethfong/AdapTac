using UnityEngine;
using System.Collections;

public class InventorySlotsManager : MonoBehaviour 
{
	public GameObject[] slots;

	private int slotIndex = 0;
	private int MAX_SLOTS = 5;

	void Start()
	{
		Model.inventorySlotManager = this;
	}

	public void AssignInventorySlot(Part pPart)
	{
		if(slotIndex == MAX_SLOTS) return;

		string frameName = "";

		switch(pPart.partIconFrameID)
		{
		case Part.FrameID.part_Cockpit1:
			frameName = "Inventory_Cockpit1";
			break;
		case Part.FrameID.part_Cockpit2:
			frameName = "Inventory_Cockpit2";
			break;
		case Part.FrameID.part_Cockpit3:
			frameName = "Inventory_Cockpit3";
			break;
		case Part.FrameID.part_Cockpit4:
			frameName = "Inventory_Cockpit4";
			break;
		case Part.FrameID.part_Engine1:
			frameName = "Inventory_Engine1";
			break;
		case Part.FrameID.part_Engine2:
			frameName = "Inventory_Engine2";
			break;
		case Part.FrameID.part_Engine3:
			frameName = "Inventory_Engine3";
			break;
		case Part.FrameID.part_Engine4:
			frameName = "Inventory_Engine4";
			break;
		case Part.FrameID.part_Frame1:
			frameName = "Inventory_Frame1";
			break;
		case Part.FrameID.part_Frame2:
			frameName = "Inventory_Frame2";
			break;
		case Part.FrameID.part_Frame3:
			frameName = "Inventory_Frame3";
			break;
		case Part.FrameID.part_Frame4:
			frameName = "Inventory_Frame4";
			break;
		case Part.FrameID.part_Tire1:
			frameName = "Inventory_Tire1";
			break;
		case Part.FrameID.part_Tire2:
			frameName = "Inventory_Tire2";
			break;
		case Part.FrameID.part_Tire3:
			frameName = "Inventory_Tire3";
			break;
		case Part.FrameID.part_Tire4:
			frameName = "Inventory_Tire4";
			break;
		case Part.FrameID.part_Weapon1:
			frameName = "Inventory_Weapon1";
			break;
		case Part.FrameID.part_Weapon2:
			frameName = "Inventory_Weapon2";
			break;
		case Part.FrameID.part_Weapon3:
			frameName = "Inventory_Weapon3";
			break;
		case Part.FrameID.part_Weapon4:
			frameName = "Inventory_Weapon4";
			break;
		default:
			break;
		}

		if(frameName != "")
		{
			tk2dSprite spriteAnim = slots[slotIndex].GetComponent<tk2dSprite>();
			spriteAnim.SetSprite(frameName);

			slotIndex++;
		}
	}
}
