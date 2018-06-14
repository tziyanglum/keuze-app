using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectScript : MonoBehaviour {

	public GameObject option;
    public GameObject options;
	public GameObject container;
	public Text title;
    public Text howmuch;

    public void Check(Node unit)
    {
        string sub = unit.Name;
        //Debug.Log(sub);
        title.text = sub;
        title.name = sub;

		foreach (Transform child in container.transform) {
			GameObject.Destroy(child.gameObject);
		}

        for(int i = 0; i < unit.Children.Count; i++)
        {
            Node _option;
            _option = unit.Children[i];
            //Debug.Log(_option);

            GameObject opt = (GameObject)Instantiate(option, transform.position, Quaternion.identity);
            OptionScript os = opt.GetComponent<OptionScript>(); 
            os.node = _option;
			//Debug.Log(os.node.Name);

            opt.transform.SetParent(container.transform);
            opt.name = _option.Name;
            opt.GetComponentInChildren<Text>().text = _option.Name;
            
        }
        
       ScrollSnapRect ssr = options.GetComponent<ScrollSnapRect>();

        if (ssr._pageCount > 0)
        {
            ssr.LerpToPage(0);
            ssr.SetPagePositions();
        }
           
    }

    void Update()
    {
        ScrollSnapRect ssr = options.GetComponent<ScrollSnapRect>();
        // how many objects are in the folder
        howmuch.text = (ssr._currentPage + 1) + " / " + ssr._pageCount;

    }
}
