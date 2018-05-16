using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Text : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TowersCreateUiText();

	}
	void TowersCreateUiText(){
		/*	//	GameObject.Find("Canvas").transform.Find("TD").transform.Find("TowerSpotsGUIs").transform.Find("tbtns").transform.Find("btn_Tower1").transform.Find("Text").
		var root = FindObjectOfType<TowerButtonsPositions>();
		foreach(Transform child in root)
		{
			if (child.childCount >= 1)
			{
				foreach(Transform subchild in child.transform)
				{
					if (subchild.gameObject.name == "Text")
					{
						subchild.gameObject.transform.GetComponent<Text>().text = "";
						break;
					}
				}
			}
		}*/
		GameObject.FindGameObjectWithTag("Text1").GetComponent<Text>().text = string.Format ("Custo: {0} \n Dano: {1}", 5 , 2);
		GameObject.FindGameObjectWithTag("Text2").GetComponent<Text>().text = string.Format ("Custo: {0} \n Dano: {1}", 10 , 3);
		GameObject.FindGameObjectWithTag("Text3").GetComponent<Text>().text = string.Format ("Custo: {0} \n Dano: {1}", 15 ,4);
		GameObject.FindGameObjectWithTag("Text4").GetComponent<Text>().text = string.Format ("Custo: {0} \n Dano: {1}", 20 , "--");
		GameObject.FindGameObjectWithTag("Text5").GetComponent<Text>().text = string.Format ("Custo: {0} \n Dano: {1}", 30 , 6);

	}

}
