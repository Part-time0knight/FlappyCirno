public interface IPlayerController
{
    public bool pause { get; set; }
    public void Hit();
    public void FlyMode();
    public void JumpMode();
    public void MakeJump();
    public void GetPoint();
}
