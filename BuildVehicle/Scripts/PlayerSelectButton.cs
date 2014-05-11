using UnityEngine;
using System.Collections;

public class PlayerSelectButton : GUIButton 
{
	public Model.PlayerCharacterEnum characterType;

	public virtual void OnMouseDown()
	{
		Hashtable scaleDown = new Hashtable();
		scaleDown.Add("scale", mScaleDown);
		scaleDown.Add("time", 0.10f);
		
		Hashtable scaleUp = new Hashtable();
		scaleUp.Add("scale", mScaleUp);
		scaleUp.Add("time", 0.10f);
		scaleUp.Add("delay", 0.15f);
		
		iTween.ScaleTo(gameObject, scaleDown);
		iTween.ScaleTo(gameObject, scaleUp);
		
		if(audio.clip != null)
		{
			audio.PlayOneShot(audio.clip);
		}
		
		Model.selectedCharacter = characterType;
		PlayerSelectScreen.inst.SelectCharacter(characterType);
		PlayerSelectScreen.inst.UpdateCharacterInfoPanel(characterType);
	}
}
