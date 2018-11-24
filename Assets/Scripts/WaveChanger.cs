using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveChanger : MonoBehaviour {

    private GameObject parent;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
        parent = gameObject.transform.parent.gameObject;
        audioSource = GetComponent<AudioSource>();
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&&OpeningController.gamestart){
            other.GetComponent<PlayerController>().HP -= 1;
            other.GetComponent<hpController>().HPchange();
            audioSource.PlayOneShot(audioSource.clip);
            parent.GetComponent<VibrationController>().destroy_num += 1;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        if(parent.GetComponent<VibrationController>().check){
            gameObject.transform.localScale =gameObject.transform.localScale + new Vector3(0, -0.01f, 0);
        }
        if(gameObject.transform.localScale.y <= 0.2f)
        {
            parent.GetComponent<VibrationController>().destroy_num += 1;
            Destroy(this.gameObject);
        }
	}
}
