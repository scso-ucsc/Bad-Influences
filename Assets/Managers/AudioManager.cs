using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //AudioManager Variables
    public static AudioManager instance;
    [SerializeField] private AudioSource backgroundMusicSource, weaponSwapSource;
    [SerializeField] private AudioSource basicGunSource;
    [SerializeField] private AudioSource sniperGunSource;
    [SerializeField] private GameObject zombieAudioObject;
    [SerializeField] private AudioSource zombieAudioSource;
    [SerializeField] private AudioClip zombieBodyHitSound, zombieHeadshotSound;

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
        backgroundMusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void basicGunPlay(){
        basicGunSource.Play();
    }

    public void sniperGunPlay(){
        sniperGunSource.Play();
    }

    public void weaponSwapPlay(){
        weaponSwapSource.Play();
    }

    public void zombieHitPlay(Vector3 loadPosition, string soundType){
        zombieAudioObject.transform.position = loadPosition;
        if(soundType == "body"){
            zombieAudioSource.clip = zombieBodyHitSound;
        } else{ //soundType == "head"
            zombieAudioSource.clip = zombieHeadshotSound;
        }
        zombieAudioSource.Play();
    }
}
