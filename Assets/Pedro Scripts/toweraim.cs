using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toweraim : MonoBehaviour {
	 


	//
	//protected float speed = 5f;

  //[SerializeField]
  //protected Transform rotTower;
	[SerializeField]
	protected float range = 1.5f;


	void Start(){
		
	}
	void Update (){ 

	
		var enemies  = GameObject.FindGameObjectsWithTag ("Enemy"); 
		foreach (GameObject enemy in enemies)
		{
			float  distanceToTarget = Vector3.Distance(transform.position,enemy.transform.position);
			if (distanceToTarget < range) {
				Vector3 targetDir = enemy.transform.position - transform.position;
				float angle = Mathf.Atan2(targetDir.y ,targetDir.x) * Mathf.Rad2Deg + 90f ;
				Quaternion q = Quaternion.AngleAxis( angle, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards(transform.rotation , q , 180f);

			}	
		}	
		}
		
	void  OnDrawGizmosSelected(){
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}



}

