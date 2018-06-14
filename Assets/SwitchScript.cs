using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	public int screenIndex;
	public GameObject classes;

	public void SwitchImage(){
		ScrollSnapRect ssr = classes.GetComponent<ScrollSnapRect>();
		ssr.LerpToPage(screenIndex);
	}
}
