using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUI_text : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("Text1").GetComponent<Text>().text = string.Format("Custo: {0} | Dano{1}",5,2);
		GameObject.FindGameObjectWithTag("Text2").GetComponent<Text>().text = string.Format("Custo: {0} | Dano{1}",10,3);
		GameObject.FindGameObjectWithTag("Text3").GetComponent<Text>().text = string.Format("Custo: {0} | Dano{1}",15,4);
		GameObject.FindGameObjectWithTag("Text4").GetComponent<Text>().text = string.Format("Custo: {0} ",20);
		GameObject.FindGameObjectWithTag("Text5").GetComponent<Text>().text = string.Format("Custo: {0} | Dano{1}",30 ,6);
	}
}
