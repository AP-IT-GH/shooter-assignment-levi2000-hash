using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{

    public Text text;
    private int score;

    private void Update()
    {
        score = Convert.ToInt16(text.text);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "projectile")
        {
            score++;
            text.text = Convert.ToString(score);
            Destroy(this.gameObject);
        }
    }
}