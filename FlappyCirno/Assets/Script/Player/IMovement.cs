public interface IMovement
{
    public bool fly { get; set; }
    public bool freeze { get; set; }
    public void Jump();
    public void Fall();
}
