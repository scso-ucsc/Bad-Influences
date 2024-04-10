using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    //Zombie Variables
    [SerializeField] private int zombieHealth;
    [SerializeField] private float zombieSpeed;
    private CharacterController controller;
    private bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        zombieHealth = 10;
        zombieSpeed = 2.0f;
        isHit = false;
        controller = GetComponent<CharacterController>(); //Acquiring character controller aspect
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit == false){
            Vector3 forward = transform.TransformDirection(Vector3.forward); //Calculating variables for forward/back movement
            controller.SimpleMove(forward * zombieSpeed); //SimpleMove locks player to the ground
        }
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.tag == "SafeZone"){ //Adding ammo to player then deactivating
            GameManager.instance.gameOver();
        }
    }

    public void zombieHurt(int damage){
        isHit = true;
        Debug.Log(damage);
        zombieHealth -= damage;
        Debug.Log(zombieHealth);
        isHit = false;
        // if(zombieHealth <= 0){
        //         zombieHealth = 10; //Resetting Health
        //         this.gameObject.SetActive(false); //Deactivating Zombie
        // }
    }
}
