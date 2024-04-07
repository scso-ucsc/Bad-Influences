using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    //AmmoManager Variables
    public static AmmoManager instance;
    private List<GameObject> basicBulletList = new List<GameObject>();
    [SerializeField] private GameObject basicBulletObj; //[SerializeField] lets the variable be accessible to Unity editor, but not public to the rest
    [SerializeField] private Transform basicBulletParent;
    [SerializeField] private float fireSpeed = 1000;
    [SerializeField] private Transform bulletSpawnpoint;
    [SerializeField] private Transform playerPosition;

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
        for(int i = 0; i < 20; i++){ //Instantiating Basic Bullets
            Vector3 spawnPoint = new Vector3(0, 0, 0);
            GameObject basicBullet = Instantiate(basicBulletObj, spawnPoint, Quaternion.Euler(90, 0, 0), basicBulletParent);
            basicBullet.SetActive(false);
            basicBulletList.Add(basicBullet);
        }
    }

    public void Fire(){ //Firing bullet function
        GameObject chosenBullet = getBullet();
        if(chosenBullet != null){ //Based on Introduction To Object Pooling In Unity - https://www.youtube.com/watch?v=YCHJwnmUGDk
            chosenBullet.transform.position = bulletSpawnpoint.position;
            chosenBullet.transform.rotation = playerPosition.transform.rotation; //Rotation needs to be reset too
            chosenBullet.SetActive(true);
        }
        chosenBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fireSpeed);
    }

    private GameObject getBullet(){
        for(int i = 0; i < 20; i++){ //Finding first object in the basicBulletList that isn't active and returning it
            if(!basicBulletList[i].activeInHierarchy){
                return basicBulletList[i];
            }
        }
        return null;
    }
}
