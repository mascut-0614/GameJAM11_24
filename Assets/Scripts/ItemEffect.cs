using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour {
    public int item_num;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            switch (item_num)
            {
                case 0:
                    other.GetComponent<PlayerController>().HP += 1;
                    other.GetComponent<hpController>().HPchange();
                    this.gameObject.SetActive(false);
                    break;
                case 1:
                    other.GetComponent<PlayerController>().scale_rate = 1.25f;
                    this.gameObject.SetActive(false);
                    break;
                case 2:
                    other.GetComponent<PlayerController>().vib_vel = 6f;
                    this.gameObject.SetActive(false);
                    break;
            }
        }

    }
}
