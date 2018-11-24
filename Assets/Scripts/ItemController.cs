using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public GameObject[] items = new GameObject[3];
    public bool check = true;
	
	// Update is called once per frame
	void Update () {
        if(TimeController.time<=10f&&check){
            check = false;
            items[Random.Range(0, 3)].SetActive(true);
        }
	}
}
