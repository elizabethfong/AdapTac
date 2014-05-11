using UnityEngine;
using System.Collections;

public class LibraryRulesPanel : GUIWidget {

	public GameObject[] rulesPages;
	public GameObject leftPageButton;
	public GameObject rightPageButton;

	private int mCurrentPageIndex = 0;

	//Note: We want to disable or fade out the left arrow button if the index is equal to 0.
	//		And we want to disable or fade out the right arrow budding if the index is equal to the length of 'rulesPages' minus 1.

	void Awake()
	{
	}

	public int GetPageIndex()
	{
		return mCurrentPageIndex;
	}

	public void PageRight()
	{
		int prevPageIndex = mCurrentPageIndex;
		mCurrentPageIndex++;

		if(mCurrentPageIndex <= rulesPages.Length - 1)
		{
			GameObject tempPage = rulesPages[prevPageIndex];
			tempPage.SetActive(false);

			tempPage = rulesPages[mCurrentPageIndex];
			tempPage.SetActive(true);

			leftPageButton.SetActive(true);
		}
		/*else
		{
			mCurrentPageIndex = rulesPages.Length - 1;
			rightPageButton.SetActive(false);
		}*/

		if(mCurrentPageIndex == rulesPages.Length - 1)
		{
			rightPageButton.SetActive(false);
		}
	}

	public void PageLeft()
	{
		int prevPageIndex = mCurrentPageIndex;
		mCurrentPageIndex--;
		
		if(mCurrentPageIndex >= 0)
		{
			GameObject tempPage = rulesPages[prevPageIndex];
			tempPage.SetActive(false);
			
			tempPage = rulesPages[mCurrentPageIndex];
			tempPage.SetActive(true);

			rightPageButton.SetActive(true);
		}
		/*else
		{
			mCurrentPageIndex = 0;
			leftPageButton.SetActive(false);
		}*/

		if(mCurrentPageIndex == 0)
		{
			leftPageButton.SetActive(false);
		}
	}
}
