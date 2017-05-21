using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill{
    void executeSkill();
    void UpdateCoolDown();
    float CoolDown { get; }
    bool usingSkill { get; set; }
}
