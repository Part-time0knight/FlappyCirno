using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreController : MonoBehaviour, IScoreController
{
    public int score
    {
        get { return _score; }
        set
        { 
            _score = value;
            if (_score > _bestScore)
                _bestScore = _score;
            UpdateSubscribers();
            load.SafeGame();
        }
    }
    public int bestScore
    {
        get { return _bestScore; }
        set { _bestScore = value; UpdateSubscribers(); }
    }

    private int _score = 0;
    private int _bestScore = 0;
    private ILoadController load;
    private readonly List<ISubscriber> subscribers = new List<ISubscriber>();
    [Inject]
    private void Construct(ILoadController load)
    {
        this.load = load;
    }
    private void Start()
    {
        load.LoadGame();
    }
    private void UpdateSubscribers()
    {
        for (int i = 0; i < subscribers.Count; i++)
        {
            subscribers[i].UpdateSubscriber();
        }
    }
    public void AddSubscriber(ISubscriber item)
    {
        subscribers.Add(item);
        item.UpdateSubscriber();
    }

    public void RemoveSubscriber(ISubscriber item)
    {
        subscribers.Remove(item);
    }

}
