using UnityEngine;
using Zenject;

public class LoadController : ILoadController
{
    private IScoreController scoreController;
    private Settings settings;
    [Inject] 
    private void Construct(IScoreController scoreController, Settings settings)
    {
        this.scoreController = scoreController;
        this.settings = settings;
    }
    public void LoadGame()
    {
        scoreController.bestScore = PlayerPrefs.GetInt("bestResult");
    }

    public void SafeGame()
    {
        PlayerPrefs.SetInt("score", scoreController.score);
        PlayerPrefs.SetInt("bestResult", scoreController.bestScore);
        PlayerPrefs.Save();
    }

    public void SafeSetting()
    {
        int music;
        int sfx;
        if (settings._music)
            music = 1;
        else
            music = 0;
        if (settings._sfx)
            sfx = 1;
        else
            sfx = 0;
        PlayerPrefs.SetInt("music", music);
        PlayerPrefs.SetInt("sfx", sfx);
    }

    public void LoadSetting()
    {
        int music = PlayerPrefs.GetInt("music"); 
        int sfx = PlayerPrefs.GetInt("sfx");
        settings._music = music > 0;
        settings._sfx = sfx > 0;
    }
}
