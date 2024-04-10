using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //PlayerManager Variables
    public static PlayerManager instance; //This allows it to be called by other classes using PlayerManager.instance.function()
    private CharacterController controller; //Component on the player
    [SerializeField] private float speedRotation;

    // Awake is called upon being created
    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speedRotation = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotation, 0); //Enabling left/right rotation when left-right keys are pressed

        if(Input.GetMouseButtonDown(0)){ //Fire if left-mouse clicked
            AmmoManager.instance.Fire();
        }
    }
}
