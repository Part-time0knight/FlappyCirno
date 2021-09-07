using UnityEngine;
using Zenject;
[CreateAssetMenu(fileName = "Setting", menuName = "GameParameters/Setting")]
public class Settings : ScriptableObject
{
    [Header("параметры игры:")]
    public GameObject tube;
    public GameObject floor;
    public float gameSpeed = 3f;
    [Header("------------------------------")]
    [Header("параметры звука:")]
    [SerializeField] private bool sfx = true;
    [SerializeField] private bool music = true;
    [SerializeField] private float volume = 0.3f;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip dieClip;
    [Header("------------------------------")]
    [Header("параметры игрока:")]
    public float jumpForce = 27;
    public int scoreForTube = 1;
    [Header("------------------------------")]
    [Header("параметры труб:")]
    public float tubeJumpRange = 1.5f;
    public float tubeSpawnDelay = 1.7f;
    public float tubeLifeTime = 4;
    public Vector2 tubeSpawnPosition = new Vector2(5f, 0.5f);
    public int tubePoolSize = 6;
    public float _volume { get { return volume; } }
    public bool _music
    {
        get { return music; }
        set
        {
            music = value;
        }
    }
    public bool _sfx
    {
        get { return sfx; }
        set
        {
            sfx = value;
        }
    }
    public AudioClip _musicClip { get { return musicClip; } }
    public AudioClip _jumpClip { get { return jumpClip; } }
    public AudioClip _pointClip { get { return pointClip; } }
    public AudioClip _dieClip { get { return dieClip; } }

}
