using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
private WaveSpawner waveSpawner;

public void Start()
{
waveSpawner = GetComponentInParent<WaveSpawner>();
}

}
