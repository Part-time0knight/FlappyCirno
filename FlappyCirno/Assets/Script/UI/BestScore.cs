using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BestScore : MonoBehaviour, ISubscriber
{
    private IScoreController scoreController;
    private Text scoreText;
    [Inject]
    private void Construct(IScoreController scoreController)
    {
        this.scoreController = scoreController;
    }
    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }
    private void Start()
    {
        scoreController.AddSubscriber(this);
    }
    public void UpdateSubscriber()
    {
        scoreText.text = "" + scoreController.bestScore;
    }
}
