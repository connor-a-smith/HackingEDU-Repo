using UnityEngine;
using System.Collections;

public class RandomVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {

      int random1 = (Random.Range(-3, 3));
	
	  GetComponent<Rigidbody>().AddForce (new Vector3(getRandom(), getRandom (), getRandom ()),
	                                                  ForceMode.Impulse);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	 
	private float getRandom() {
	
	  float randomNum = Random.Range (-3, 3);
	  if (randomNum == 0) randomNum = 1;
	  
	  return randomNum;
	
	
	}
}
