using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject projectile;
   
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;
    private float shootForce = 1000f;
    void Update () {
        float shoot = Input.GetAxis("Fire1");
        print(shoot);

        if (shoot == 1 && timer >= shootRate)//shoot{
        {
          
            GameObject newProjectile = Instantiate(projectile, transform.position+transform.forward,transform.rotation) ;
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward*shootForce,ForceMode.VelocityChange);
            start = true;
            timer = 0f;
        }

        if (start)
        {
            if (timer< shootRate)
                timer += Time.deltaTime;
            else
            {
                timer = shootRate;
                start = false;
            }
           
        }
    }
}