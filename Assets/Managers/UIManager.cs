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
    [SerializeField] private GameObject basicGunParticleEmitter;
    private ParticleSystem basicGunParticles;

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
        sniperGunText.enabled = false;
        laserGunText.enabled = false;

        gameoverUI.SetActive(false);
        basicGunParticles = basicGunParticleEmitter.GetComponent<ParticleSystem>(); //Accessing Particle System of GameObject
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Enemies Defeated: " + GameManager.instance.getPlayerScore().ToString(); //Updating score constantly

        if(Input.GetMouseButtonDown(0)){ //Activate particles if mouse is pressed
            basicGunParticles.Play(); //Playing Particle Burst
        }

        if (GameManager.instance.returnGameOverStatus() == true)
        {
            gameoverUI.SetActive(true);
        }

        if (Input.GetKeyDown("1"))
        {
            pistolGunText.enabled = true;
            sniperGunText.enabled = false;
            laserGunText.enabled  = false;
        }

        if (Input.GetKeyDown("2"))
        {
            sniperGunText.enabled = true;
            pistolGunText.enabled = false;
            laserGunText.enabled = false;
        }

        if(Input.GetKeyDown("3"))
        {
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
