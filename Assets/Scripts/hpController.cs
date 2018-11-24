using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpController : MonoBehaviour {

    public GameObject[] heart = new GameObject[6];

    public void HPchange(){
        int temp = this.gameObject.GetComponent<PlayerController>().HP;
        for (int i = 1; i <= temp;i++){
            heart[i].gameObject.SetActive(true);
        }
        if(temp<5){
            for (int j = temp+1; j <= 5;j++){
                heart[j].SetActive(false);
            }
        }
    }
}
