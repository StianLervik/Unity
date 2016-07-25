using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {
	public int mana;
	public weapon weaponScript;
	public int maxMana;
	public bool spell;
	public GameObject Gray;
	public GameObject SpellWindow;

	private Text manaBox;
	private bool refilling;

	// Use this for initialization
	void Start () {
		manaBox = GameObject.Find ("Mana").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && weaponScript.fire && mana >= 10) 
		{
			mana -= 10;
			StopCoroutine ("ManaRefill");
			StartCoroutine ("ManaRefill");
		}
		manaBox.text = "Mana: " + mana;

		if (mana < maxMana && !refilling) 
		{
			StartCoroutine ("ManaRefill");
		}

		if (Input.GetKeyDown ("l")) 
		{
			spell = !spell;
		}

		if (spell) {
			Gray.SetActive (true);
			SpellWindow.SetActive (true);
		} else {
			Gray.SetActive (false);
			SpellWindow.SetActive (false);
		}
	}

	IEnumerator ManaRefill ()
	{
		refilling = true;
		yield return new WaitForSeconds (3);
		for(int i = mana; i < maxMana; i++)
		{
			mana++;
			yield return new WaitForSeconds (0.1f);
		}
		refilling = false;
	}
}
