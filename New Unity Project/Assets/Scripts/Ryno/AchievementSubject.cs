using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class AchievementSubject : MonoBehaviour {

    public GameObject achievementSystem;
    private Subject subject;

    public void Start()
    {
        if (!achievementSystem.GetComponent<AchievementSystem>())
        {
            Debug.LogError("Gameobject does not contain an AchievementSystem");
        }
    }
	

	void Awake () {
        this.subject = new Subject();
        subject.AddObserver(new AchievementObserver(achievementSystem));
	}
	
	public Subject GetSubject()
    {
        return subject;
    }

    public void NotifyObservers(AchievementEvent aEvent)
    {
        subject.Notify(aEvent);
    }

   
}
