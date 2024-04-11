using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Manager Variables
    public static GameManager instance; //Static enables it to be called anywhere
    private bool isGameOver;
    private int playerScore;

    // Awake is called upon creation, before everything else 
    void Awake(){
        if(instance == null){
            instance = this; //If this is the first instance of the game manager, create it
        } else{
            Destroy(this); //Else, destroy it and keep original instance
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool returnGameOverStatus(){
        return isGameOver;
    }

    public void gameOver(){
        isGameOver = true;
    }
}
