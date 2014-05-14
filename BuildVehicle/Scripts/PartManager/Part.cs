using UnityEngine;
using System.Collections;

public class Part 
{
	//NOTE: These enums matches what is loaded from the data.xml file.  
	//TODO: We will need to convert the string value from the xml file to its corresponding enum type...
	public enum PartCategory { CATEGORY_NONE, CATEGORY_COCKPIT, CATEGORY_ENGINE, CATEGORY_FRAME, CATEGORY_TIRE, CATEGORY_WEAPON };
	
	public enum PartID { 	PART_NONE = -1, 
							PART_COCKPIT_1, PART_COCKPIT_2, PART_COCKPIT_3, PART_COCKPIT_4, 
							PART_ENGINE_1, PART_ENGINE_2, PART_ENGINE_3, PART_ENGINE_4, 
							PART_FRAME_1, PART_FRAME_2, PART_FRAME_3, PART_FRAME_4, 
							PART_TIRE_1, PART_TIRE_2, PART_TIRE_3, PART_TIRE_4, 
							PART_WEAPON_1, PART_WEAPON_2, PART_WEAPON_3, PART_WEAPON_4 };

	public enum FrameID { 	part_Cockpit1, part_Cockpit2, part_Cockpit3, part_Cockpit4,
							part_Engine1, part_Engine2, part_Engine3, part_Engine4, 
							part_Frame1, part_Frame2, part_Frame3, part_Frame4, 
							part_Tire1, part_Tire2, part_Tire3, part_Tire4, 
							part_Weapon1, part_Weapon2, part_Weapon3, part_Weapon4 };

	public enum WeaponRange { NONE, SHORT, MEDIUM, LONG };

	//Part Attributes:
	public PartCategory partCategory = PartCategory.CATEGORY_NONE;
	public PartID partId = PartID.PART_NONE;
	public string partName = "";
	public int partRanking;
	public float partAcceleration;
	public float partBraking;
	public float partArmor;
	public float partSpeed;
	public float partDrag;
	public float partAccuracy;
	public WeaponRange partRange;
	public float partDamage;
	public string partSpecial;
	public string partTagLine = "";

	//This variable will be used to change the part icon associated with this part.  This is needed to differentiate the visual representation of this part for shuffling.
	public FrameID partIconFrameID;

	//private tk2dSpriteAnimator mPartIcon;

	public Part()
	{

	}
}
