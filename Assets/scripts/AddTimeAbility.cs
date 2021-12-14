using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeAbility : MonoBehaviour, IAbility
{
    public Countdowntimer countdowntimer;
    public void Activate()
    {

        countdowntimer.AddTime();
              


    }

    public void Deactivate()
    {
        throw new System.NotImplementedException();

    }



}
