using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
	[SerializeField] private AudioClip attackSoundClip;
	public float volume = 1f;

    public float Damage = 2f;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		SoundFXManager.instance.PlaySoundFXClip(attackSoundClip, transform, volume);
		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Character>().TakeDamage(Damage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
