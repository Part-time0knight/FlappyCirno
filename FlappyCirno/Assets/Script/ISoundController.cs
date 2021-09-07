using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundController
{
    public bool sfx { get; set; }
    public bool music { get; set; }
    public void PlayJump();
    public void PlayDie();
    public void PlayPoint();
}
