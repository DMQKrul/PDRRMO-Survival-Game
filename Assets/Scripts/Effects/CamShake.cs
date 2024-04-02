using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator camAnim;

    public void CamShaking()
    {
        camAnim.SetTrigger("shake");
    }

    public void EarthQuakeCamShaking()
    {
        camAnim.SetTrigger("earthQuake");
    }
}
