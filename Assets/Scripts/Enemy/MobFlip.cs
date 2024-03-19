using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFlip : MonoBehaviour
{
    private Transform player;

	public bool isFlipped = false;

    void Start()
    {
        // Find the player GameObject using tag at the start
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

	public void Update()
	{
		LookAtPlayer();
	}

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}
