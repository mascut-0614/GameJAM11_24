using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int player_id;
    private bool jump = false;
    public bool attack = false;
    private Rigidbody rigidbody;
    public GameObject prefab;
    public float scale_rate = 1f;
    private float vib_scale=3f;//def=2f
    public float vib_vel = 5f;//def=4f
    public int HP = 3;

    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Physics.gravity=new Vector3(0, -20f, 0);
        audioSource = GetComponent<AudioSource>();
    }
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jump = true;
            if(attack){
                attack = false;
                GameObject vib = Instantiate(prefab, transform.position-new Vector3(0,0.5f,0), transform.rotation) as GameObject;
                VibrationController temp = vib.GetComponent<VibrationController>();
                temp.Create(vib_scale, vib_vel);
            }
        }
        if(collision.gameObject.CompareTag("Player")){
            if(attack&&collision.gameObject.transform.position.y<transform.position.y){
                attack = false;
                collision.gameObject.GetComponent<PlayerController>().HP -= 1;
                collision.gameObject.GetComponent<hpController>().HPchange();
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }

    void Update () {
        if(OpeningController.gamestart){
            //操作方法
            switch (player_id)
            {
                case 1:
                    if (jump && Input.GetKeyDown(KeyCode.S))
                    {
                        jump = false;
                        rigidbody.velocity = new Vector3(0, 10f, 0);
                    }
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        rigidbody.velocity = new Vector3(0, -30f, 0);
                        attack = true;
                        vib_scale = (2.4f + transform.position.y) * scale_rate;
                    }
                    else if (Input.GetKey(KeyCode.Z))
                    {
                        gameObject.transform.position += new Vector3(-0.1f, 0, 0);
                    }
                    else if (Input.GetKey(KeyCode.C))
                    {
                        gameObject.transform.position += new Vector3(0.1f, 0, 0);
                    }
                    break;
                case 2:
                    if (jump && Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        jump = false;
                        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
                    }
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        rigidbody.velocity = new Vector3(0, -30f, 0);
                        attack = true;
                        vib_scale = (2.4f + transform.position.y) * scale_rate;
                    }
                    else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        gameObject.transform.position += new Vector3(-0.1f, 0, 0);
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        gameObject.transform.position += new Vector3(0.1f, 0, 0);
                    }
                    break;
            }
        }

	}
}
