using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FubukuScript : MonoBehaviour
{
    [SerializeField] private AudioClip atkSoundClip;
    public float atkVolume = 1f;

    [SerializeField] private AudioClip atk2SoundClip;
    public float atk2Volume = 1f;

    private Animator anim;
    public Transform kazePos;
    public Transform thunderboltPos;
    public GameObject kaze;
    public GameObject kaminari;
    private GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Exhausted()
    {
        anim.SetTrigger("Exhausted");
    }

    public void kaminariNoKokyu()
    {
        SoundFXManager.instance.PlaySoundFXClip(atkSoundClip, transform, atkVolume);
        Instantiate(kaminari, thunderboltPos.position, Quaternion.identity);
    }

    public void kazeNoKokyu()
    {
        SoundFXManager.instance.PlaySoundFXClip(atk2SoundClip, transform, atk2Volume);
        Instantiate(kaze, kazePos.position, Quaternion.identity);
    }
}
