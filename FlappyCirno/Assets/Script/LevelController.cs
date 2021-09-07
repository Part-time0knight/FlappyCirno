using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour, ILevelController
{
    private IItemSpawner tubeSpawner;
    private Settings settings;
    private GameObject floor;
    private GameObject tube;
    
    private float speed;
    private bool _pause = false;
    Animator floorAnimator;

    public bool pause
    { 
        get
        {
            return _pause;
        }
        set
        { 
            _pause = value;
            tubeSpawner.pause = value;
            if (value)
                StopFloor();
            else
                RunFloor();
        }
    }
    [Inject]
    private void Construct(IItemSpawner tubeSpawner, Settings settings)
    {
        this.tubeSpawner = tubeSpawner;
        this.settings = settings;
        floor = settings.floor;
        tube = settings.tube;
        floor = Instantiate(floor, gameObject.transform);
    }
    public void InitLevel(float speed)
    {
        floorAnimator = floor.GetComponent<Animator>();
        this.speed = speed;
        RunFloor();
    }
    private void RunFloor()
    {
        floorAnimator.speed = speed;
    }
    private void StopFloor()
    {
        floorAnimator.speed = 0f;
    }
    public void StartLevel()
    {
        RunFloor();
        tubeSpawner.StartSpawn(tube, speed);
        pause = false;
    }

    public void StopLevel()
    {
        pause = true;
    }
}
