using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<Quest> activeQuests = new List<Quest>();

    public void InitialiseQuest(string description, Func<PlayerData, bool> successCondition,
                                Action onSuccess, Func<PlayerData, bool> failureCondition = null,
                                Action onFailure = null)
    {
        Quest newQuest = new Quest(description, successCondition, onSuccess, failureCondition, onFailure);
        activeQuests.Add(newQuest);

        // displays the start of the quest in the connsole log
        Debug.Log($"Quest started: {description}");

        // starts to check for the status of the quest 
        StartCoroutine(CheckQuestStatus(newQuest));
    }

    private IEnumerator CheckQuestStatus(Quest quest)
    {
        while (true)
        {
            yield return null;

            if (quest.successCondition(PlayerDataInstance()))
            {
                Debug.Log($"Quest succeeded: {quest.description}");
                quest.onSuccess?.Invoke();
                yield break;
            }

            if (quest.failureCondition != null && quest.failureCondition(PlayerDataInstance()))
            {
                Debug.Log($"Quest failed: {quest.description}");
                quest.onFailure?.Invoke();
                yield break;
            }
        }
    }

    private PlayerData PlayerDataInstance()
    {
        return new PlayerData(); // references the players instance
    }
}
