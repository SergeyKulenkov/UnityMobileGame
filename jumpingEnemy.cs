using UnityEngine;
using System.Collections;

public class jumpingEnemy : enemy //inheritance from enemy class
{

    protected override void Start()
    {   //using enemy Start method and initializing some unique variables
        base.Start();
        health = 20;
        scorePoints = 15;  
    }
}
