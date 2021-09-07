public interface ILevelController
{
    public bool pause { get; set; } 
    public void InitLevel(float speed);
    public void StartLevel();
    public void StopLevel();
}
