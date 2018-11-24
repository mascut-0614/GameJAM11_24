using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    public GameObject Right;
    public GameObject Left;

    public bool check=false;
    public int destroy_num = 0;

    public void Create(float scale,float vel){
        Right.gameObject.transform.localScale = new Vector3(0.3f, scale, 1f);
        Left.gameObject.transform.localScale = new Vector3(0.3f, scale, 1f);
        Right.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(vel, 0, 0);
        Left.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-vel, 0, 0);
        check = true;
    }

    void Update () {
        if(destroy_num>=2){
            Destroy(this.gameObject);
        }
	}
}
