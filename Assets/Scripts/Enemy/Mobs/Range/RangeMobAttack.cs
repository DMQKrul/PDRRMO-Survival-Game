using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMobAttack : MonoBehaviour
{
    [SerializeField] private AudioClip attackSoundClip;
    public float attackVolume = 1f;

    public Transform bulletPos;
    public GameObject bullet;
    private GameObject player;

    public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void shoot()
    {        
        SoundFXManager.instance.PlaySoundFXClip(attackSoundClip, transform, attackVolume);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected() 
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}

    

}
