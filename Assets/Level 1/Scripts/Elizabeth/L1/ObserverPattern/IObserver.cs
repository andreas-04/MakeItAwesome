using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    //Observer can have spcific actions that notify
    public void OnNotify(PlayerActions action, float currentHealth);

}