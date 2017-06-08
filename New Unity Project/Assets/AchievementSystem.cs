using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class AchievementSystem : MonoBehaviour {

    public void Unlock(AchievementID achievementID)
    {
        switch (achievementID)
        {
            case AchievementID.ACHIEVEMENT_JUMP:
                Debug.Log("Unlocked Jumpevent");
                break;
            case AchievementID.ACHIEVEMENT_ALL_DEAD:
                Debug.Log("Unlocked AllDead");
                break;
            case AchievementID.ACHIEVEMENT_WIN_CLASSICO:
                Debug.Log("Unlocked Classico");
                break;
            default:
                Debug.LogWarning("No case for Achievement");
                break;
        }
    }
}
