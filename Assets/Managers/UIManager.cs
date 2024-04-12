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
        gameoverUI.SetActive(false);
        basicGunParticles = basicGunParticleEmitter.GetComponent<ParticleSystem>(); //Accessing Particle System of GameObject
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Enemies Defeated: " + GameManager.instance.getPlayerScore().ToString() + "/100"; //Updating score constantly

        if(Input.GetMouseButtonDown(0)){ //Activate particles if mouse is pressed
            basicGunParticles.Play(); //Playing Particle Burst
        }

        if (GameManager.instance.returnGameOverStatus() == true)
        {
            gameoverUI.SetActive(true);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
