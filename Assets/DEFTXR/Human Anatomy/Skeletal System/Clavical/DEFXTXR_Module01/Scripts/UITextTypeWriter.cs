using UnityEngine;
using System.Collections;
using TMPro;

public class UITextTypeWriter : MonoBehaviour
{
	TextMeshProUGUI txt;
	
	string story;

	void Awake()
	{
		txt = this.GetComponent<TextMeshProUGUI>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.125f);
		}
	}
}
