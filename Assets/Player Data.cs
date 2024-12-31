using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int resourcesGathered;
    public int enemiesKilled;

    public PlayerData()
    {
        resourcesGathered = 0;
        enemiesKilled = 0;
    }

    //simulates gathering resources or killing enemies
    public void GatherResources(int amount)
    {
        resourcesGathered += amount;
    }

    public void KillEnemy()
    {
        enemiesKilled++;
    }
}

