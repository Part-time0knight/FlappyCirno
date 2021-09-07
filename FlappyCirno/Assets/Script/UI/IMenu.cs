using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenu
{
    public bool music { get; set; }
    public bool sfx { get; set; }
    public void GoMineMenu();
    public void GoScore();
    public void GoSetting();
    public void Exit();
}
