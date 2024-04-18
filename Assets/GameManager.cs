using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Game Manager Variables
    public static GameManager instance; //Static enables it to be called anywhere
    private bool isGameOver, playerWin;
    private int playerScore;
    private string playerWeapon;

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
        playerWin = false;
        playerWeapon = "basic";
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore == 100){
            playerWin = true;
            gameOver();
        }
    }

    public bool returnGameOverStatus(){
        return isGameOver;
    }

    public void gameOver(){
        isGameOver = true;
    }

    public void increaseScore(){ //Increasing score
        playerScore += 1;
        if(playerScore == 10 || playerScore == 20 || playerScore == 30 || playerScore == 50){
            UIManager.instance.warnPlayerIncrease();
            AudioManager.instance.enemyGrowthPlay();
        }
    }

    public int getPlayerScore(){
        return playerScore;
    }

    public string getPlayerWeapon(){ //Returning playerWeapon
        return playerWeapon;
    }

    public void setPlayerWeapon(string weapon){ //Assigning weapon variable
        playerWeapon = weapon;
    }

    public bool getPlayerWin(){
        return playerWin;
    }
}