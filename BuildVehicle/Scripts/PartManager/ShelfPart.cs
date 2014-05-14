using UnityEngine;
using System.Collections;

public class ShelfPart : MonoBehaviour 
{
	public Part.PartCategory partCategory;
	public Part.PartID partId;
	private bool mIsActive = true;

	void Start()
	{
		//TODO: Initialize part visual from the PartManager
		Part part = PartManager.inst.GetPart(partCategory, partId);

		string frameName = "";
		
		switch(part.partIconFrameID)
		{
			case Part.FrameID.part_Cockpit1:
				frameName = "part_Cockpit1";
				break;
			case Part.FrameID.part_Cockpit2:
				frameName = "part_Cockpit2";
				break;
			case Part.FrameID.part_Cockpit3:
				frameName = "part_Cockpit3";
				break;
			case Part.FrameID.part_Cockpit4:
				frameName = "part_Cockpit4";
				break;
			case Part.FrameID.part_Engine1:
				frameName = "part_Engine1";
				break;
			case Part.FrameID.part_Engine2:
				frameName = "part_Engine2";
				break;
			case Part.FrameID.part_Engine3:
				frameName = "part_Engine3";
				break;
			case Part.FrameID.part_Engine4:
				frameName = "part_Engine4";
				break;
			case Part.FrameID.part_Frame1:
				frameName = "part_Frame1";
				break;
			case Part.FrameID.part_Frame2:
				frameName = "part_Frame2";
				break;
			case Part.FrameID.part_Frame3:
				frameName = "part_Frame3";
				break;
			case Part.FrameID.part_Frame4:
				frameName = "part_Frame4";
				break;
			case Part.FrameID.part_Tire1:
				frameName = "part_Tire1";
				break;
			case Part.FrameID.part_Tire2:
				frameName = "part_Tire2";
				break;
			case Part.FrameID.part_Tire3:
				frameName = "part_Tire3";
				break;
			case Part.FrameID.part_Tire4:
				frameName = "part_Tire4";
				break;
			case Part.FrameID.part_Weapon1:
				frameName = "part_Weapon1";
				break;
			case Part.FrameID.part_Weapon2:
				frameName = "part_Weapon2";
				break;
			case Part.FrameID.part_Weapon3:
				frameName = "part_Weapon3";
				break;
			case Part.FrameID.part_Weapon4:
				frameName = "part_Weapon4";
				break;
			default:
				break;
		}
		
		if(frameName != "")
		{
			tk2dSprite spriteAnim = this.gameObject.GetComponent<tk2dSprite>();
			spriteAnim.SetSprite(frameName);
		}
	}
	
	public void Reset()
	{
		mIsActive = true;
		gameObject.SetActive(true);
	}

	void OnMouseDown()
	{
		if(!mIsActive || Model.playerCharacter.curPartCarried != null) return;

		switch(partCategory)
		{
			case Part.PartCategory.CATEGORY_COCKPIT:
				if(Model.playerCharacter.hasCockpit) return;
				break;
			case Part.PartCategory.CATEGORY_ENGINE:
				if(Model.playerCharacter.hasEngine) return;
				break;
			case Part.PartCategory.CATEGORY_FRAME:
				if(Model.playerCharacter.hasFrame) return;
				break;
			case Part.PartCategory.CATEGORY_TIRE:
				if(Model.playerCharacter.hasTire) return;
				break;
			case Part.PartCategory.CATEGORY_WEAPON:
				if(Model.playerCharacter.hasWeapon) return;
				break;
			default:
				break;
		}

		if(Model.playerCharacter.curTriggerBox == partCategory)
		{
			mIsActive = false;
			gameObject.SetActive(false);
			//Debug.Log(partId);

			//Debug.Log(partCategory + " " + partId);

			Part part = PartManager.inst.GetPart(partCategory, partId);

			if(part == null) return;

			//Debug.Log(part.partCategory + " " + part.partId + " " + part.partIconFrameID);

			Model.playerCharacter.curPartCarried = part;
			Model.playerCharacter.carriedPart.SetActive(true);

			string frameName = "";
			
			switch(part.partIconFrameID)
			{
				case Part.FrameID.part_Cockpit1:
					frameName = "part_Cockpit1";
					break;
				case Part.FrameID.part_Cockpit2:
					frameName = "part_Cockpit2";
					break;
				case Part.FrameID.part_Cockpit3:
					frameName = "part_Cockpit3";
					break;
				case Part.FrameID.part_Cockpit4:
					frameName = "part_Cockpit4";
					break;
				case Part.FrameID.part_Engine1:
					frameName = "part_Engine1";
					break;
				case Part.FrameID.part_Engine2:
					frameName = "part_Engine2";
					break;
				case Part.FrameID.part_Engine3:
					frameName = "part_Engine3";
					break;
				case Part.FrameID.part_Engine4:
					frameName = "part_Engine4";
					break;
				case Part.FrameID.part_Frame1:
					frameName = "part_Frame1";
					break;
				case Part.FrameID.part_Frame2:
					frameName = "part_Frame2";
					break;
				case Part.FrameID.part_Frame3:
					frameName = "part_Frame3";
					break;
				case Part.FrameID.part_Frame4:
					frameName = "part_Frame4";
					break;
				case Part.FrameID.part_Tire1:
					frameName = "part_Tire1";
					break;
				case Part.FrameID.part_Tire2:
					frameName = "part_Tire2";
					break;
				case Part.FrameID.part_Tire3:
					frameName = "part_Tire3";
					break;
				case Part.FrameID.part_Tire4:
					frameName = "part_Tire4";
					break;
				case Part.FrameID.part_Weapon1:
					frameName = "part_Weapon1";
					break;
				case Part.FrameID.part_Weapon2:
					frameName = "part_Weapon2";
					break;
				case Part.FrameID.part_Weapon3:
					frameName = "part_Weapon3";
					break;
				case Part.FrameID.part_Weapon4:
					frameName = "part_Weapon4";
					break;
				default:
					break;
			}
			
			if(frameName != "")
			{
				//Debug.Log(frameName);
				tk2dSprite spriteAnim = Model.playerCharacter.carriedPart.GetComponent<tk2dSprite>();
				spriteAnim.SetSprite(frameName);
				//Debug.Log(spriteAnim.spriteId);
			}
		}
	}
}
