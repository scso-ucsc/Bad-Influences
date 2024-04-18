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
}
