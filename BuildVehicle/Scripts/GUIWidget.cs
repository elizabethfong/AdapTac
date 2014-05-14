using UnityEngine;
using System.Collections;

public class GUIWidget : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void FadeIn()
	{
		StartCoroutine(FadeTo (1.0f, 0.5f));
	}

	public void FadeOut()
	{
		StartCoroutine(FadeTo (0.0f, 0.5f));
	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.renderer.material.color.a;

		if(aValue == 1.0f)
		{
			this.gameObject.SetActive(true);
		}

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			transform.renderer.material.color = newColor;

			yield return null;
		}

		alpha = transform.renderer.material.color.a;

		if(alpha == 0.0f)
		{
			this.gameObject.SetActive(false);
		}
	}
}
