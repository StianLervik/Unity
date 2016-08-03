using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellWindow : MonoBehaviour {
	public HUD hudScript;
	public InputField Bar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("l")) 
		{
			Bar.Select ();
			Bar.ActivateInputField ();
		}
	}
}
