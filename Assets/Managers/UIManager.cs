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
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.text = "Enemies Defeated: " + GameManager.instance.getPlayerScore().ToString(); //Updating score constantly

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
