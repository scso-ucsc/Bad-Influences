using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Needed for using TextMeshPro
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private GameObject basicGunParticleEmitter, sniperGunParticleEmitter;
    [SerializeField] private GameObject basicGun, sniperGun; //Gun GameObjects
    [SerializeField] private GameObject basicGunScope, sniperScope; //Scopes
    private ParticleSystem basicGunParticles, sniperGunParticles;

    [SerializeField] private TextMeshProUGUI pistolGunText;
    [SerializeField] private TextMeshProUGUI sniperGunText;
    [SerializeField] private TextMeshProUGUI laserGunText;

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

        sniperGunText.enabled = false; //UI Text
        laserGunText.enabled = false;

        basicGunScope.SetActive(true); //Scopes
        sniperScope.SetActive(false);

        gameoverUI.SetActive(false);
        basicGunParticles = basicGunParticleEmitter.GetComponent<ParticleSystem>(); //Accessing Particle System of GameObject
        sniperGunParticles = sniperGunParticleEmitter.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Enemies Defeated: " + GameManager.instance.getPlayerScore().ToString() + "/100"; //Updating score constantly

        if(Input.GetMouseButtonDown(0)){ //Activate particles if mouse is pressed
            if(GameManager.instance.getPlayerWeapon() == "basic"){
                basicGunParticles.Play(); //Playing Particle Burst
                AudioManager.instance.basicGunPlay();
            } else if(GameManager.instance.getPlayerWeapon() == "sniper"){
                sniperGunParticles.Play();
                AudioManager.instance.sniperGunPlay();
            }
        }

        if (GameManager.instance.returnGameOverStatus() == true)
        {
            gameoverUI.SetActive(true);
        }

        if (Input.GetKeyDown("1"))
        {
            GameManager.instance.setPlayerWeapon("basic");
            AudioManager.instance.weaponSwapPlay();
            basicGun.SetActive(true); //Weapon
            sniperGun.SetActive(false);

            basicGunScope.SetActive(true); //Updating Scopes
            sniperScope.SetActive(false);
            
            pistolGunText.enabled = true;
            sniperGunText.enabled = false;
            laserGunText.enabled  = false;
        }

        if (Input.GetKeyDown("2"))
        {
            basicGun.SetActive(false);
            sniperGun.SetActive(true);

            basicGunScope.SetActive(false); //Updating Scopes
            sniperScope.SetActive(true);
            
            GameManager.instance.setPlayerWeapon("sniper");
            AudioManager.instance.weaponSwapPlay();
            sniperGunText.enabled = true;
            pistolGunText.enabled = false;
            laserGunText.enabled = false;
        }

        if(Input.GetKeyDown("3"))
        {
            basicGun.SetActive(false);
            sniperGun.SetActive(false);

            basicGunScope.SetActive(false); //Updating Scopes
            sniperScope.SetActive(false);

            GameManager.instance.setPlayerWeapon("laser");
            AudioManager.instance.weaponSwapPlay();
            sniperGunText.enabled = false;
            pistolGunText.enabled = false;
            laserGunText.enabled = true;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
