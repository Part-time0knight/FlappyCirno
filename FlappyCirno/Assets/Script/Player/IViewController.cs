public interface IViewController
{
    public bool freeze { get; set; }
    public void PlayJump();
    public void PlayFall();
    public bool PlayFly { get; set; }
}
