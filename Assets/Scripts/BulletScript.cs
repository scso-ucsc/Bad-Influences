using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private string bulletType;
    [SerializeField] private int basicDamage; // Basic damage for body shots
    [SerializeField] private int headshotMultiplier; // Multiplier for headshots

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Wall"){
            DisableBullet();
        } else if(collision.gameObject.tag == "Zombie"){
            ProcessHit(collision.gameObject, basicDamage); // Handle body shot
        } else if(collision.gameObject.tag == "HeadCollider"){
            int headshotDamage = basicDamage * headshotMultiplier;
            GameObject zombieParent = collision.gameObject.transform.parent.gameObject; // Reference to the Zombie GameObject
            Debug.Log("Headshot detected on " + zombieParent.name + " with damage: " + headshotDamage);
            ProcessHit(zombieParent, headshotDamage); // Apply damage to the Zombie GameObject
    }
    }

    private void DisableBullet(){
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.SetActive(false);
    }

    private void ProcessHit(GameObject zombie, int damage){
        Debug.Log("Damage Applied: " + damage); // Debug the damage being applied
        var zombieScript = zombie.GetComponent<ZombieScript>();
        if(zombieScript != null){
            zombieScript.zombieHurt(damage);
        }
        DisableBullet();
    }
}
