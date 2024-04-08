using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    //Zombie Variables
    private int zombieHealth;

    // Start is called before the first frame update
    void Start()
    {
        zombieHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collider){
        if(collider.gameObject.tag == "BasicBullet"){ //If zombie gets hit by bullet, reduce health
            Debug.Log("I am hit");
            zombieHealth -= 4;
        }
        if(zombieHealth <= 0){
                zombieHealth = 10; //Resetting Health
                this.gameObject.SetActive(false); //Deactivating Zombie
        }
    }

    public void hurt(){
        Debug.Log("I am hit");
    }
}
