using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider){
        if(collider.gameObject.tag == "Wall"){ //If bullet collides with a wall, disable the bulett
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resetting velocity to 0 so that if active again, that force no longer applies
            this.gameObject.SetActive(false);
        } 
        // else if(collider.gameObject.tag == "Zombie"){
        //     collider.gameObject.SetActive(false);
        //     this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resetting velocity to 0 so that if active again, that force no longer applies
        //     this.gameObject.SetActive(false);
        // }
    }
}
