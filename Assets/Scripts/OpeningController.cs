using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningController : MonoBehaviour {
    //Start
    public GameObject Title;
    public GameObject Play;
    public GameObject Exit;
    public GameObject Up;
    public GameObject Down;
    public GameObject Hp1;
    public GameObject Hp2;
    //Restart
    public GameObject result1;
    public GameObject result2;
    public GameObject draw;

    public bool isplay = true;
    public static bool gamestart = false;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Item1;
    public GameObject Item2;

    public int state = 0;

	// Use this for initialization
	void Start () {
        Player1.GetComponent<PlayerController>().attack = true;
        Player2.GetComponent<PlayerController>().attack = true;
        Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, -10f, 0);
        Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, -10f, 0);
        Invoke("NextCome",2f);
	}
    void NextCome(){
        Debug.Log("in");
        Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
        Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 10f, 0);
        state=1;
    }
	// Update is called once per frame
	void Update () {
        switch(state){
            case 1:
                if (Title.transform.position.y >= 2.0f)
                {
                    Title.transform.position = Title.transform.position - new Vector3(0, 0.1f, 0);
                }else{
                    Play.SetActive(true);
                    Exit.SetActive(true);
                    Up.SetActive(true);
                    state = 2;
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    isplay = false;
                    Up.SetActive(false);
                    Down.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    isplay = true;
                    Up.SetActive(true);
                    Down.SetActive(false);
                }
                else if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (isplay)
                    {
                        Title.SetActive(false);
                        result1.SetActive(false);
                        result2.SetActive(false);
                        draw.SetActive(false);
                        Play.SetActive(false);
                        Exit.SetActive(false);
                        Up.SetActive(false);
                        Hp1.SetActive(true);
                        Hp2.SetActive(true);
                        Item1.GetComponent<ItemController>().check = true;
                        Item2.GetComponent<ItemController>().check = true;
                        Player1.transform.position = new Vector3(-5f, -2f, 0f);
                        Player2.transform.position = new Vector3(5f, -2f, 0f);
                        Player1.GetComponent<PlayerController>().HP = 3;
                        Player2.GetComponent<PlayerController>().HP = 3;
                        Player1.GetComponent<hpController>().HPchange();
                        Player2.GetComponent<hpController>().HPchange();
                        Player1.GetComponent<PlayerController>().vib_vel = 4f;
                        Player2.GetComponent<PlayerController>().vib_vel = 4f;
                        Player1.GetComponent<PlayerController>().scale_rate = 1f;
                        Player2.GetComponent<PlayerController>().scale_rate = 1f;
                        gamestart = true;
                        state = 3;
                    }
                    else
                    {
                        Application.Quit();
                    }
                }
                break;
            case 3:
                if(Player1.GetComponent<PlayerController>().HP==0){
                    gamestart = false;
                    result2.SetActive(true);
                    Play.SetActive(true);
                    Exit.SetActive(true);
                    Up.SetActive(true);
                    isplay = true;
                    state = 2;
                }
                else if(Player2.GetComponent<PlayerController>().HP==0){
                    gamestart = false;
                    result1.SetActive(true);
                    Play.SetActive(true);
                    Exit.SetActive(true);
                    Up.SetActive(true);
                    isplay = true;
                    state = 2;
                }else if(TimeController.time<=0){
                    gamestart = false;
                    int temp1 = Player1.GetComponent<PlayerController>().HP;
                    int temp2 = Player2.GetComponent<PlayerController>().HP;
                    if(temp1==temp2){
                        //引き分け
                        draw.SetActive(true);
                    }else if(temp1>temp2){
                        result1.SetActive(true);
                    }else{
                        result2.SetActive(true);
                    }
                    Play.SetActive(true);
                    Exit.SetActive(true);
                    Up.SetActive(true);
                    isplay = true;
                    state = 2;
                }
                break;
            default:
                break;
        }
	}
}
