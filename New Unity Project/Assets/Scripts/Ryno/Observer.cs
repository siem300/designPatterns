using UnityEngine;
using System.Collections;

namespace ObserverPattern
{
    //Wants to know when another object does something interesting 
    public abstract class Observer
    {
        public abstract void OnNotify(AchievementEvent e);
    }

    public class AchievementObserver : Observer
    {
        //The AchievementSystem GO that needs to be notified of the event
        GameObject achievementSystem;

        public AchievementObserver(GameObject achievementSystem)
        {
            this.achievementSystem = GameObject.FindGameObjectWithTag("AchievementSystem");
        }

       // Send an event to the AchievementSystem
        public override void OnNotify(AchievementEvent e)
        {
            achievementSystem.GetComponent<AchievementSystem>().Unlock(e.getUnlockedAchievement());
        }
      
    }
}
