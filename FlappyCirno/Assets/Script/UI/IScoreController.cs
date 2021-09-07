public interface IScoreController
{
    public int score { get; set; }
    public int bestScore { get; set; }
    public void AddSubscriber(ISubscriber item);
    public void RemoveSubscriber(ISubscriber item);
}
