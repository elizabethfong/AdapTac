using UnityEngine;
using System.Collections;

/*
 * This class will be used for the Library parts panel and in-game help panel.
 */

public class PartPanel : MonoBehaviour 
{
	private tk2dSpriteAnimator mPartIcon;
	private tk2dSpriteAnimator mPartPanel;

	public GameObject partIcon;
	public GameObject partPanel;
	public Part.FrameID frameID;

	void Start()
	{
		mPartIcon = partIcon.GetComponent<tk2dSpriteAnimator>();
		mPartPanel = partPanel.GetComponent<tk2dSpriteAnimator>();
	}

	public void SetPanel(Part.PartID pPartId, Part.FrameID pFrameId)
	{
		try
		{
			mPartPanel.SetFrame((int)pPartId);
			mPartIcon.SetFrame((int)pFrameId);
		}
		catch
		{
		}
	}
}
