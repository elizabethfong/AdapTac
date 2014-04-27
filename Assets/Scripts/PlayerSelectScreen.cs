using UnityEngine;
using System.Collections;

public class PlayerSelectScreen : MonoBehaviour 
{
	public GameObject nomrenchButton;
	public GameObject fermiumButton;
	public GameObject rockieButton;
	public GameObject missTeakButton;

	public GameObject infoPanel;

	private GameObject mLastSelectedButton;

	public static PlayerSelectScreen inst;

	// Use this for initialization
	void Start () 
	{
		mLastSelectedButton = nomrenchButton;

		InitializeCharacterButtons();
		UpdateCharacterInfoPanel(Model.selectedCharacter);

		inst = this;
	}
	
	private void InitializeCharacterButtons()
	{
		Model.selectedCharacter = Model.PlayerCharacterEnum.NOMRENCH;
		mLastSelectedButton = nomrenchButton;

		SetHighlightEnabled(nomrenchButton, true);
		SetHighlightEnabled(fermiumButton, false);
		SetHighlightEnabled(rockieButton, false);
		SetHighlightEnabled(missTeakButton, false);
	}

	private void SetHighlightEnabled(GameObject pButton, bool pEnabled = false)
	{
		tk2dSprite highlight = pButton.GetComponent<tk2dSprite>();

		if(pEnabled)
		{
			highlight.scale = new Vector3(1,1,1);
		}
		else
		{
			highlight.scale = new Vector3(0,0,0);
		}
	}

	public void UpdateCharacterInfoPanel(Model.PlayerCharacterEnum pSelectedCharacter)
	{
		tk2dSpriteAnimator infoPanelAnimator = infoPanel.GetComponent<tk2dSpriteAnimator>();

		switch(Model.selectedCharacter)
		{
			case Model.PlayerCharacterEnum.FERMIUM:
				infoPanelAnimator.Play("FermiumInfo");
				break;
			case Model.PlayerCharacterEnum.NOMRENCH:
				infoPanelAnimator.Play("NomrenchInfo");
				break;
			case Model.PlayerCharacterEnum.MISS_TEAK:
				infoPanelAnimator.Play("MissTeakInfo");
				break;
			case Model.PlayerCharacterEnum.ROCKIE:
				infoPanelAnimator.Play("RockieInfo");
				break;
			default:
				break;
		}
	}

	public void SelectCharacter(Model.PlayerCharacterEnum pSelectedCharacter)
	{
		switch(Model.selectedCharacter)
		{
			case Model.PlayerCharacterEnum.FERMIUM:
				SetHighlightEnabled(nomrenchButton, false);
				SetHighlightEnabled(fermiumButton, true);
				SetHighlightEnabled(rockieButton, false);
				SetHighlightEnabled(missTeakButton, false);
				break;
			case Model.PlayerCharacterEnum.NOMRENCH:
				SetHighlightEnabled(nomrenchButton, true);
				SetHighlightEnabled(fermiumButton, false);
				SetHighlightEnabled(rockieButton, false);
				SetHighlightEnabled(missTeakButton, false);
				break;
			case Model.PlayerCharacterEnum.MISS_TEAK:
				SetHighlightEnabled(nomrenchButton, false);
				SetHighlightEnabled(fermiumButton, false);
				SetHighlightEnabled(rockieButton, false);
				SetHighlightEnabled(missTeakButton, true);
				break;
			case Model.PlayerCharacterEnum.ROCKIE:
				SetHighlightEnabled(nomrenchButton, false);
				SetHighlightEnabled(fermiumButton, false);
				SetHighlightEnabled(rockieButton, true);
				SetHighlightEnabled(missTeakButton, false);
				break;
			default:
				break;
		}
	}
}
