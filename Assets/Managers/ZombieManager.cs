using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    //ZombieManager Variables
    public static ZombieManager instance;
    private List<GameObject> zombiesList = new List<GameObject>();
    [SerializeField] private GameObject zombieObj;
    [SerializeField] private Transform zombieParent;

    void Awake()
    {
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++){ //Instantiating 10 Zombies
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            GameObject zombie = Instantiate(zombieObj, spawnPoint, Quaternion.Euler(0, 90, 0), zombieParent);
            zombie.SetActive(false);
            zombiesList.Add(zombie);
        }

        StartCoroutine(spawnZombies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnZombies(){ // called via StartCoroutine(spawnZombies());
        while(GameManager.instance.returnGameOverStatus() == false){ //While not game over
            yield return new WaitForSeconds(1.5f); //Spawn every 1.5 seconds
            Vector3 randomSpawnPoint = new Vector3(-82.0f, 1.7f, Random.Range(-28, 28)); //Generating random spawn point at back of map

            GameObject chosenZombie = getZombie();
            if(chosenZombie != null){ //Acquires inactive coin from pull, changes position on map, and sets to active
                chosenZombie.transform.position = randomSpawnPoint;
                chosenZombie.SetActive(true);
            }
        }
    }

    private GameObject getZombie(){ //Based on Introduction To Object Pooling In Unity - https://www.youtube.com/watch?v=YCHJwnmUGDk
        for(int i = 0; i < zombiesList.Count; i++){
            if(!zombiesList[i].activeInHierarchy){
                return zombiesList[i];
            }
        }
        return null;
    }
}
