using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    //Zombie Variables
    [SerializeField] private int zombieHealth;
    [SerializeField] private float zombieSpeed;
    private CharacterController controller;

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
        if(zombieHealth <= 0){
                zombieHealth = 10; //Resetting Health
                this.gameObject.SetActive(false); //Deactivating Zombie
        }
    }
}
