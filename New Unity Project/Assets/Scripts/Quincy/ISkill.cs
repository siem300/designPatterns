using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill{
    void executeSkill();
    void UpdateCoolDown();
    float CoolDown { get; }
    string Tag { get; }
    bool usingSkill { get; set; }
}
