using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour 
{
	public enum PlayerCharacterEnum { MISS_TEAK, FERMIUM, NOMRENCH, ROCKIE };

	public static PlayerCharacterEnum selectedCharacter;
	public static PlayerCharacter playerCharacter;

	public static PartManager partManager;
	public static InventorySlotsManager inventorySlotManager;
}
