using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler {

    public int answer;
    public int q;
    public GameObject right;
    Node _questionNode;

    public void Start()
    {

    }

    public GameObject item
    {
        get
        {
            if(transform.childCount > 1)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region drop item to parent position
    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            QuestionScript.itemBeingDragged.transform.SetParent(transform);

            //snapping position
            if(answer == 0)
            {
                QuestionScript.itemBeingDragged.transform.position = transform.position;
            }
            else if (answer == 1)
            {
                Vector3 left = new Vector3(-250f, 0f, 0f);
                QuestionScript.itemBeingDragged.transform.position = transform.position - left;
				QuestionScript.itemBeingDragged.GetComponent<Image> ().color = this.GetComponent<Image> ().color;

            }
            else if (answer == 2)
            {
                Vector3 right = new Vector3(250f, 0f, 0f);
                QuestionScript.itemBeingDragged.transform.position = transform.position - right;
				QuestionScript.itemBeingDragged.GetComponent<Image> ().color = this.GetComponent<Image> ().color;
            }
            else if (answer == 3)
            {
                Vector3 bot = new Vector3(0f, -175f, 0f);
                QuestionScript.itemBeingDragged.transform.position = transform.position - bot;
				QuestionScript.itemBeingDragged.GetComponent<Image> ().color = this.GetComponent<Image> ().color;
            }
           else if (answer == 4)
            {
                Vector3 top = new Vector3(0f, 175f, 0f);
                QuestionScript.itemBeingDragged.transform.position = transform.position - top;
				QuestionScript.itemBeingDragged.GetComponent<Image> ().color = this.GetComponent<Image> ().color;
            }
            
        }
    }
#endregion

}
