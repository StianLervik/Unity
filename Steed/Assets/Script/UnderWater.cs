using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour {

    public bool IsUnder = false;

    void OnTriggerEnter(Collider collider)
    {
		IsUnder = true;
		print ("Collision");
    }

	void Update(){
		if (IsUnder) {
		}
	}
}
