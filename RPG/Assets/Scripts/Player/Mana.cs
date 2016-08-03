using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mana : MonoBehaviour {
	public Scrollbar scMana;
	public HUD hudScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scMana.size = hudScript.mana / 100.0f;
	}
}
