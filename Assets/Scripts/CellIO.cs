﻿using UnityEngine;
using System.Collections;

public class CellIO : MonoBehaviour {

  public AudioSource inputSound;
  public AudioSource outputSound;

  const int numInputs = 6;
  
  //array and indeces for each different input piece
  private bool[] inputs = new bool[numInputs];
  private const int atpIndex = 0;
  private const int mrnaIndex = 1;
  private const int aminoIndex = 2;
  private const int proteinIndex = 3;
  private const int glucoseIndex = 4;
  private const int poisonIndex = 5;
  
  private string type; //string type of the prefab
  
  // Use this for initialization
  void Start () {
  
    type = GetComponent<Info>().getType ();
	for (int i = 0; i < inputs.Length; i++) { inputs[i] = false; }
 	
  }
	
  // Update is called once per frame
  void Update () {
  
    if (type == InfoStrings.mitochondria) {
	  if (inputs[glucoseIndex] == true) {
        Output();
        
      }
    }
    
    else if (type == InfoStrings.nucleus) {
      if (inputs[atpIndex] == true || inputs[proteinIndex] == true) {
      
        Output();
      
      }
    }
    
    else if (type == InfoStrings.ribosome) {
      if (inputs[atpIndex] == true && inputs[mrnaIndex] == true && inputs[aminoIndex] == true) {
        Debug.Log (inputs[mrnaIndex]);
        Output();
      
      }
    }
  }
  
  /* Checks inputs */
  void OnTriggerEnter(Collider other) {
	
    string otherType = other.GetComponent<Info>().getType ();
	
	//will perform input checks
    if (type == InfoStrings.mitochondria) {
	  if (otherType == InfoStrings.glucose) {
	  
	    inputs[glucoseIndex] = true;
	    Destroy (other.gameObject);
		inputSound.Play ();
				
	  }
	}
	
	else if (type == InfoStrings.nucleus) {
	  if (otherType == InfoStrings.atp) {
	  
	    inputs[atpIndex] = true;
	    Destroy (other.gameObject);
		inputSound.Play ();
	  }
	  
	  if (otherType == InfoStrings.protein) {
	  
	    inputs[proteinIndex] = true;
	    Destroy(other.gameObject);
		inputSound.Play ();
	    
	  }
	}
	
	else if (type == InfoStrings.ribosome) {
	  if (otherType == InfoStrings.atp) {
	  
	    inputs[atpIndex] = true;
	    Destroy (other.gameObject);
		inputSound.Play ();
	    
	  }
	  
	  if (otherType == InfoStrings.mrna) {
	  
	    inputs[mrnaIndex] = true;
        Destroy (other.gameObject);
		inputSound.Play ();

	  }
	  
	  if (otherType == InfoStrings.amino) {
	    inputs[aminoIndex] = true;
	    Destroy (other.gameObject);
		inputSound.Play ();
	  
	  }
	}
  }
  
  /* outputs appropriate prefabs and resets inputs */
  private void Output() {
  
    if (type == InfoStrings.mitochondria) {
      GameObject.Instantiate(Prefabs.atp, 
        transform.position, transform.rotation);
      
    }
    
    else if (type == InfoStrings.nucleus) {
      if (inputs[atpIndex]) {
	    GameObject.Instantiate(Prefabs.mrna, 
	      transform.position, transform.rotation);
	  }
	  
	  else if (inputs[proteinIndex]) {
	    GameObject.Instantiate (Prefabs.ribosome,
	      transform.position, transform.rotation);
	    GameObject.Instantiate (Prefabs.mitochondria,
	      transform.position, transform.rotation);
	  }
    }
    
    else if (type == InfoStrings.ribosome) {
	  GameObject.Instantiate(Prefabs.proteins, 
	    transform.position, transform.rotation);
    }
    
    outputSound.Play ();
  
  }
}
