using UnityEngine;
using System.Collections;


namespace ObserverPattern
{
    public enum AchievementID
    {
        ACHIEVEMENT_JUMP=0,
        ACHIEVEMENT_ALL_DEAD,
        ACHIEVEMENT_WIN_CLASSICO
    }

    //Events
    public abstract class AchievementEvent
    {
        public abstract AchievementID getUnlockedAchievement();
    }

    // a player jumps.
    public class JumpEvent: AchievementEvent
    {
        public override AchievementID getUnlockedAchievement()
        {
            return AchievementID.ACHIEVEMENT_JUMP;
        }
    }

    //Both players Die
    public class AllDeadEvent : AchievementEvent
    {
        public override AchievementID getUnlockedAchievement()
        {
            return AchievementID.ACHIEVEMENT_ALL_DEAD;
        }
    }

    // Win as Classico
    public class WinClassicoEvent : AchievementEvent
    {
        public override AchievementID getUnlockedAchievement()
        {
            return AchievementID.ACHIEVEMENT_WIN_CLASSICO;
        }
    }
}