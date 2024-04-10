using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private string bulletType;
    private void OnCollisionEnter(Collision collider){
        if(collider.gameObject.tag == "Wall"){ //If bullet collides with a wall, disable the bulett
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resetting velocity to 0 so that if active again, that force no longer applies
            this.gameObject.SetActive(false);
        } else if(collider.gameObject.tag == "Zombie"){
            var colliderScript = collider.gameObject.GetComponent<ZombieScript>(); //Accessing Zombie Script of Zombie Object
            if(bulletType == "basic"){
                colliderScript.zombieHurt(4);
            }
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Resetting velocity to 0 so that if active again, that force no longer applies
            this.gameObject.SetActive(false);
        }
    }
}
