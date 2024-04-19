using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //PlayerManager Variables
    public static PlayerManager instance; //This allows it to be called by other classes using PlayerManager.instance.function()
    private CharacterController controller; //Component on the player
    private bool isFiring = false;
    private float mouseRotationX = 0f;
    private float mouseRotationY = 0f;
    [SerializeField] private float mouseSensitivity = 30f;

    // Awake is called upon being created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mouseRotationX = 0f;
        mouseRotationY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotationY += Input.GetAxis("Mouse X") * mouseSensitivity; //Rotation based on Mouse; Based on This Tutorial: https://www.youtube.com/watch?v=W70n_bXp7Dc
        mouseRotationX += Input.GetAxis("Mouse Y") * (-mouseSensitivity);
        transform.localEulerAngles = new Vector3(mouseRotationX, mouseRotationY, 0);

        if (GameManager.instance.getPlayerWeapon() == "basic")
        {
            if (Input.GetMouseButtonDown(0))
            { //Fire if left-mouse clicked
                AmmoManager.instance.Fire();
            }
        }
        if (GameManager.instance.getPlayerWeapon() == "sniper")
        {
            if (Input.GetMouseButtonDown(0))
            { //Fire if left-mouse clicked
                AmmoManager.instance.Fire();
            }
        }
        else if (GameManager.instance.getPlayerWeapon() == "auto")
        {
            if (Input.GetMouseButtonDown(0))
            { //Fire if left-mouse clicked
                isFiring = true;
                StartCoroutine(FireLoop()); // Start firing loop
            }
            if (Input.GetMouseButtonUp(0)) // Stop firing when left mouse button is released
            {
                isFiring = false;
            }
        }
    }

    IEnumerator FireLoop()
    {
        while (isFiring)
        {
            AmmoManager.instance.Fire(); // Call the Fire method from AmmoManager
            yield return new WaitForSeconds(0.1f); // Adjust the delay between each shot as needed
        }
    }
}
