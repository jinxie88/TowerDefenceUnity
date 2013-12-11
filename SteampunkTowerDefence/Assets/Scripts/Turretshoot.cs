﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Turretshoot : MonoBehaviour {
	private bool looking;
	private GameObject target;
	public List<GameObject> enemiesInRange = new List<GameObject>(); 
	public float timer;
	void Start () {
	//	enemies = GameObject.Find("EnemyLeft");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += 1 * Time.deltaTime ;
		//Debug.Log(timer);
		if (target) {
			transform.LookAt(target.transform.position);
		}
		//		vector3 targetdir = new vector3(target.position.x - transform.position.x, 0f,
		//		                                target.position.z - transform.position.z);
		//		vector3 desiredRotation = Vector3.RotateTowards(transform.forward, targetdir,
		//		                                                time.deltatime*turnspeed, 0f
		//		 transform.Rotation(desiredRotation)
	}

	void OnTriggerEnter (Collider col) {
	


		if(col.gameObject.name == "EnemyLeft")
		{
			enemiesInRange.Add(col.gameObject);

			}
		}

	void OnTriggerStay (Collider col) {
		if(col.gameObject.name == "EnemyLeft")
		{
			target = enemiesInRange[0];
			looking = true;
			if (timer > 5 && looking == true){
				shooting();
				target = enemiesInRange[0];
			}
		}


	}
	void OnTriggerExit (Collider col){
		if(enemiesInRange.Contains(col.gameObject)) 
		{
			enemiesInRange.Remove(col.gameObject);
		}
	}

	void shooting(){
		Debug.log("Bullet");
		timer = 0;
		Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
	}
}

