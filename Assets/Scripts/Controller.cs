using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

public class Controller : MonoBehaviour {

	public TextAsset classes;

    public GameObject options;
    public GameObject option;
    public GameObject container;
    public Text title;

    //public Color[] backgroundColor;

    public GameObject[] layers;
    public GameObject[] blocks;

    //private List<Node> check;

    public Node selected;

    private ScrollSnapRect ssr;

	void Awake () {
        ssr = options.GetComponent<ScrollSnapRect>();
        
		XDocument classdoc = XDocument.Parse(classes.text); 
        List<Node> units = LoadUnits(classdoc.Descendants("Units").Elements("Unit"));
        //DebugTree(units);
        //check = units;

        SubjectScript ss = layers[0].GetComponent<SubjectScript>();
        ss.Check(units[0]);


	}

    void Update(){
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Whichlayer();
        }

    }
	
    public static List<Node> LoadUnits(IEnumerable<XElement> units)
    {  
        return units.Select(x => new Node()
        {
            Name = x.Attribute("Name").Value,
            Children = LoadUnits(x.Elements("Unit")),
        }).ToList();
    }

    public void Whichlayer(){
        int index = ssr._currentPage + 1;
        GameObject block = blocks[index - 1];
        block.GetComponentInChildren<Text>().text =  selected.Name;

        GameObject layer = layers[index];
        layer.SetActive(false);

        //Debug.Log(layer.name);
        SubjectScript ss = layer.GetComponent<SubjectScript>();
        ss.Check(selected);
        layer.SetActive(true);

    }


    private void DebugTree(List<Node> units)
    {
        foreach (var unit in units)
        {
            Debug.Log(unit.Name);
            DebugTree(unit.Children); 
        }
    }
}

public class Node
{
    public string Name { get; set; }
    public List<Node> Children { get; set; }
}

