using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Needed for using TextMeshPro
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI playerScoreText, totalScoreText, winText, loseText;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private GameObject basicGunParticleEmitter, sniperGunParticleEmitter, autoGunParticleEmitter;
    [SerializeField] private GameObject basicGun, sniperGun, autoGun; //Gun GameObjects
    [SerializeField] private GameObject basicGunScope, sniperScope, autoScope; //Scopes
    private ParticleSystem basicGunParticles, sniperGunParticles, autoGunParticles;

    [SerializeField] private TextMeshProUGUI instructionsText;
    [SerializeField] private TextMeshProUGUI pistolGunText;
    [SerializeField] private TextMeshProUGUI sniperGunText;
    [SerializeField] private TextMeshProUGUI autoGunText;

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
        basicGun.SetActive(true); //Active Weapon
        sniperGun.SetActive(false);
        autoGun.SetActive(false);

        sniperGunText.enabled = false; //UI Text
        autoGunText.enabled = false;

        basicGunScope.SetActive(true); //Scopes
        sniperScope.SetActive(false);
        autoScope.SetActive(false);

        winText.enabled = false; //GameOver UI
        loseText.enabled = true;
        gameoverUI.SetActive(false);

        basicGunParticles = basicGunParticleEmitter.GetComponent<ParticleSystem>(); //Accessing Particle System of GameObject
        sniperGunParticles = sniperGunParticleEmitter.GetComponent<ParticleSystem>();
        autoGunParticles = autoGunParticleEmitter.GetComponent<ParticleSystem>();

        instructionsText.text = "Defeat enemies before they reach the blue zone!";
        StartCoroutine(switchOffInstructions());
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Enemies Defeated: " + GameManager.instance.getPlayerScore().ToString() + "/100"; //Updating score constantly

        if(Input.GetMouseButtonDown(0) && GameManager.instance.returnGameOverStatus() == false){ //Activate particles if mouse is pressed
            if(GameManager.instance.getPlayerWeapon() == "basic"){
                basicGunParticles.Play(); //Playing Particle Burst
                AudioManager.instance.basicGunPlay();
            } else if(GameManager.instance.getPlayerWeapon() == "sniper"){
                sniperGunParticles.Play();
                AudioManager.instance.sniperGunPlay();
            } //Auto Gun variables called in PlayerManager
            // else{ //GameManager.instance.getPlayerWeapon() == "auto"
            //     autoGunParticles.Play();
            //     AudioManager.instance.autoGunPlay();
            // }
        }

        if (GameManager.instance.returnGameOverStatus() == true)
        {
            totalScoreText.text = "Score: " + GameManager.instance.getPlayerScore() + "/100";
            if(GameManager.instance.getPlayerWin() == true){
                winText.enabled = true;
                loseText.enabled = false;
            } else{ //GameManager.instance.getPlayerWin() == false
                winText.enabled = false;
                loseText.enabled = true;
            }
            gameoverUI.SetActive(true);
        }

        if (Input.GetKeyDown("1"))
        {
            GameManager.instance.setPlayerWeapon("basic");
            AudioManager.instance.weaponSwapPlay();
            basicGun.SetActive(true); //Weapon
            sniperGun.SetActive(false);
            autoGun.SetActive(false);

            basicGunScope.SetActive(true); //Updating Scopes
            sniperScope.SetActive(false);
            autoScope.SetActive(false);
            
            pistolGunText.enabled = true;
            sniperGunText.enabled = false;
            autoGunText.enabled  = false;
        }

        if (Input.GetKeyDown("2"))
        {
            basicGun.SetActive(false);
            sniperGun.SetActive(true);
            autoGun.SetActive(false);

            basicGunScope.SetActive(false); //Updating Scopes
            sniperScope.SetActive(true);
            autoScope.SetActive(false);
            
            GameManager.instance.setPlayerWeapon("sniper");
            AudioManager.instance.weaponSwapPlay();
            sniperGunText.enabled = true;
            pistolGunText.enabled = false;
            autoGunText.enabled = false;
        }

        if(Input.GetKeyDown("3"))
        {
            basicGun.SetActive(false);
            sniperGun.SetActive(false);
            autoGun.SetActive(true);

            basicGunScope.SetActive(false); //Updating Scopes
            sniperScope.SetActive(false);
            autoScope.SetActive(true);

            GameManager.instance.setPlayerWeapon("auto");
            AudioManager.instance.weaponSwapPlay();
            sniperGunText.enabled = false;
            pistolGunText.enabled = false;
            autoGunText.enabled = true;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator switchOffInstructions(){
        yield return new WaitForSeconds(5.0f);
        instructionsText.enabled = false;
    }

    public void warnPlayerIncrease(){
        instructionsText.text = "The zombies are getting stronger!";
        instructionsText.enabled = true;
        StartCoroutine(switchOffInstructions());
    }

    public void autoGunParticlesPlay(){
        autoGunParticles.Play();
    }
}
