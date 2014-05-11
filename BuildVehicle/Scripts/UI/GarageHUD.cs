using UnityEngine;
using System.Collections;

public class GarageHUD : MonoBehaviour 
{
	[HideInInspector]
	public GameObject ready, set, go, playerIcon;

	public enum ScreenState { WAITING, READY, SET, GO, ACTIVE, PAUSED };
	private tk2dSpriteAnimator mSelectedIconScript;
	private ScreenState state = ScreenState.WAITING;
	// Use this for initialization
	void Start () 
	{
		//Initialize Selected Player Icon
		mSelectedIconScript = playerIcon.GetComponent<tk2dSpriteAnimator>();

		switch(Model.selectedCharacter)
		{
			case Model.PlayerCharacterEnum.FERMIUM:
				mSelectedIconScript.SetFrame((int)Model.PlayerCharacterEnum.FERMIUM);
				break;
			case Model.PlayerCharacterEnum.MISS_TEAK:
				mSelectedIconScript.SetFrame((int)Model.PlayerCharacterEnum.MISS_TEAK);
				break;
			case Model.PlayerCharacterEnum.NOMRENCH:
				mSelectedIconScript.SetFrame((int)Model.PlayerCharacterEnum.NOMRENCH);
				break;
			case Model.PlayerCharacterEnum.ROCKIE:
				mSelectedIconScript.SetFrame((int)Model.PlayerCharacterEnum.ROCKIE);
				break;
			default:
				break;
		} 

		//Initialize READY, SET, GO! text
		ready.SetActive(false);
		set.SetActive(false);
		go.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float gameTime = Time.time;

		switch(state)
		{
		case ScreenState.WAITING:
			break;
		case ScreenState.READY:
			break;
		case ScreenState.SET:
			break;
		case ScreenState.GO:
			break;
		case ScreenState.ACTIVE:
			break;
		case ScreenState.PAUSED:
			break;
		default:
			break;
		}
	}
}
