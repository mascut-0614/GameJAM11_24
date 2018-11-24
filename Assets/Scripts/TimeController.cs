using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {
    public static float time = 30;
    public Text timertext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(OpeningController.gamestart){
            if(time>0){
                timertext.gameObject.SetActive(true);
                time -= Time.deltaTime;
                timertext.text = time.ToString();
            }
        }
        else{
            timertext.gameObject.SetActive(false);
            time = 30;
        }
	}
}
