using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour 
{
	public PlayerZone.Zone homeZone = PlayerZone.Zone.ONE;

	public Part.PartCategory curTriggerBox = Part.PartCategory.CATEGORY_NONE;
	public Part curPartCarried = null;

	[HideInInspector]
	public GameObject carriedPart;

	public bool hasCockpit = false;
	public bool hasEngine = false;
	public bool hasFrame = false;
	public bool hasTire = false;
	public bool hasWeapon = false;

	// Use this for initialization
	void Start () 
	{
		//TODO: Switch 3D model according to playerCharacter selected.

		Model.playerCharacter = this;
		//carriedPart.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
