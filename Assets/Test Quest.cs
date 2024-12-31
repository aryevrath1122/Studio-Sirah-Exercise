using UnityEngine;

public class TestQuest : MonoBehaviour
{
    private PlayerData playerData;
    private QuestManager questManager;

    void Start()
    {
        playerData = new PlayerData();
        questManager = FindObjectOfType<QuestManager>(); 

        // Initialize two quests
        questManager.InitialiseQuest("Gather 10 Resources",
            successCondition: (data) => data.resourcesGathered >= 10,
            onSuccess: () => Debug.Log("Quest Success! Gathered 10 Resources"),
            failureCondition: (data) => data.resourcesGathered < 0,  // represents the failure condition
            onFailure: () => Debug.Log("Quest Failed!"));

        questManager.InitialiseQuest("Kill 5 Enemies",
            successCondition: (data) => data.enemiesKilled >= 5,
            onSuccess: () => Debug.Log("Quest Success! Killed 5 Enemies"));
    }

    // Test method to simulate actions
    void Update()
    {
        // method that applies g to gather resources and k to kill enemies
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            playerData.GatherResources(1);
            Debug.Log($"Resources gathered: {playerData.resourcesGathered}");
        }

        if (Input.GetKeyDown(KeyCode.K)) 
        {
            playerData.KillEnemy();
            Debug.Log($"Enemies killed: {playerData.enemiesKilled}");
        }
    }
}
