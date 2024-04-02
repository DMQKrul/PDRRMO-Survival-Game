using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlockScript : MonoBehaviour
{
    [SerializeField] private AudioClip atkSoundClip;
    public float atkVolume = 1f;

    [SerializeField] private AudioClip atkSoundClip2;
    public float atkVolume2 = 1f;

    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject earthQuake;
    public Transform earthQuakePos;
    public Transform earthQuakePos2;
    public Transform spike1Pos;
    public Transform spike2Pos;
    public Transform spike3Pos;
    private Animator anim;
    private GameObject player;
    private CamShake shake;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
    }

    public void Exhausted()
    {
        anim.SetTrigger("Exhausted");
    }

    public void quakeE()
    {
        shake.EarthQuakeCamShaking();
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip, transform, atkVolume);
        Instantiate(earthQuake, earthQuakePos.position, Quaternion.identity);
    }

    public void quake2()
    {
        shake.EarthQuakeCamShaking();
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip, transform, atkVolume);
        Instantiate(earthQuake, earthQuakePos2.position, Quaternion.identity);
    }

    public void spikeSpawn1()
    {
        shake.CamShaking();
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip2, transform, atkVolume2);
        Instantiate(spike1, spike1Pos.position, Quaternion.identity);
    }

    public void spikeSpawn2()
    {
        shake.CamShaking();
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip2, transform, atkVolume2);
        Instantiate(spike2, spike2Pos.position, Quaternion.identity);
    }
    
    public void spikeSpawn3()
    {
        shake.CamShaking();
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip2, transform, atkVolume2);
        Instantiate(spike3, spike3Pos.position, Quaternion.identity);
    }
}
