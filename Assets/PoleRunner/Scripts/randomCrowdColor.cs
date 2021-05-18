using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCrowdColor : MonoBehaviour
{
    public MeshRenderer[] mr;
    private void Awake()
    {
        Color c= Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        for (int i = 0; i < mr.Length; i++)
        {
            mr[i].material.color = c;

        }
    }
}
