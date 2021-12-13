using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoostAbility : MonoBehaviour,IAbility
{
    public float boostingTime = 3;
    public float boostingSpeed = 10;

    public float boostTimer = 0;

    public bool isBoosting = false;
    private float intialSpeed;
    private Thrust player;
    public GameObject text;

    Rigidbody rb;

    void Start()
    {
        text.SetActive(false);
        rb = GetComponentInParent<Rigidbody>();
        player = GetComponentInParent<Thrust>();
    }
    private void FixedUpdate()
    {
        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostingTime)
            {
                player.dash = intialSpeed;
                boostTimer = 0;
                isBoosting = false;
                text.SetActive(false);

            }
        }
    }
    public void Activate()
    {
        text.SetActive(true);
        intialSpeed = player.dash;
        player.dash = boostingSpeed;
        isBoosting = true;
    }



    public void Deactivate()

    {

        throw new System.NotImplementedException();

    }

}
