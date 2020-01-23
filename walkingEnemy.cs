using UnityEngine;
using System.Collections;

public class walkingEnemy : enemy   //inheritance from enemy class
{
    protected override void Start()
    {   //using enemy Start method and initializing some unique variables
        base.Start();   
        health = 10;
        scorePoints = 10;
    }
}
