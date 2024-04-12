using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    //Zombie Variables
    [SerializeField] private int zombieHealth;
    [SerializeField] private float zombieSpeed;
    private CharacterController controller;
    private int newZombieHealth; //Health to be assigned to zombieHealth

    // Start is called before the first frame update
    void Start()
    {
        zombieHealth = 10;
        zombieSpeed = 2.0f;
        controller = GetComponent<CharacterController>(); //Acquiring character controller aspect
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.getPlayerScore() < 20){
            newZombieHealth = 15;
            zombieSpeed = 3.0f;
        } else if(GameManager.instance.getPlayerScore() < 30){
            newZombieHealth = 20;
            zombieSpeed = 3.5f;
        } else if(GameManager.instance.getPlayerScore() < 50){
            newZombieHealth = 30;
            zombieSpeed = 4.0f;
        } else{ //GameManager.instance.getPlayerScore() <= 100
            newZombieHealth = 50;
            zombieSpeed = 5.0f;
        }

        if(GameManager.instance.returnGameOverStatus() == false){
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
        zombieHealth -= damage;
        if(zombieHealth <= 0){ //Zombie Death
            GameManager.instance.increaseScore(); //Increasing Player Score
            zombieHealth = newZombieHealth; //Resetting Health
            this.gameObject.SetActive(false); //Deactivating Zombie
        }
    }
}
