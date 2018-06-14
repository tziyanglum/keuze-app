using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour {

	public GameObject _controller;
	Controller controller;
	public Node node;

	void Start(){
		_controller = GameObject.Find("Controller");
		controller = _controller.GetComponent<Controller>();
	}

	public void Selected(){
		controller.selected = node;
		//Debug.Log(controller.selected.Name);
		controller.Whichlayer();
	}
}
