using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toweraim : MonoBehaviour {
	 
	protected Weapon1Control wapon1;

	protected Weapon2Control wapon2;

	protected Weapon3Control wapon3; 

	protected Weapon4Control wapon4;

	protected Weapon5Control wapon5; 





	//
	//protected float speed = 5f;

  //[SerializeField]
  //protected Transform rotTower;
	[SerializeField]
	protected float range = 1.5f;


	void Start(){
		/*wapon1 = GameObject.FindGameObjectWithTag("Weapon1").GetComponent <Weapon1Control> ();	
		wapon2 = GameObject.FindGameObjectWithTag("Weapon2").GetComponent <Weapon2Control> ();
		wapon3 = GameObject.FindGameObjectWithTag("Weapon3").GetComponent <Weapon3Control> ();
		wapon4 = GameObject.FindGameObjectWithTag("Weapon4").GetComponent <Weapon4Control> ();	
		wapon5 = GameObject.FindGameObjectWithTag("Weapon5").GetComponent <Weapon5Control> ();	
	*/}
	void Update (){ 

	
		var enemies  = GameObject.FindGameObjectsWithTag ("Enemy"); 
		foreach (GameObject enemy in enemies)
		{
			float  distanceToTarget = Vector3.Distance(transform.position,enemy.transform.position);
			if (distanceToTarget < range) {
				Vector3 targetDir = enemy.transform.position - transform.position;
				float angle = Mathf.Atan2(targetDir.y ,targetDir.x) * Mathf.Rad2Deg ;
				Quaternion q = Quaternion.AngleAxis( angle, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards(transform.rotation , q , 180f);
	/*			wapon1.Update(); 
				wapon2.Update(); 
				wapon3.Update();
				wapon4.Update();
				wapon5.Update();
		
				
			*/}
		}
	}

	/*protected string enemyTag = "Enemy";

	// Use this for initialization
/*	void Start () {v 
		//InvokeRepeating ("UpdateTarget",  0f,0.5f);
		UpdateTarget ();	
	}
	void UpdateTarget(){
		GameObject[] enemies  = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies){
			float distanceToEnemy = Vector3.Distance( transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) { 
				
				shortestDistance = distanceToEnemy; 
				nearestEnemy = enemy; 
			} 
				
		}
		if (nearestEnemy != null &&  shortestDistance <= range){ 
			target =  nearestEnemy.transform;
		}else{
			target=null;
		}


	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
		Quaternion lookRotation = Quaternion.LookRotation (dir); 
		Quaternion rot =Quaternion.AngleAxis(angle, Vector3.forward);
		Vector3 rotation = Quaternion.Lerp(rotTower.rotation, lookRotation, speed * Time.deltaTime).eulerAngles;
		rotTower.rotation = Quaternion.Euler (0f,0f,rotation.z  );
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed *Time.deltaTime);
		if ( target == null ){
			return;
		}
		UpdateTarget();
	}
	*/
	void  OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);

	}
}

