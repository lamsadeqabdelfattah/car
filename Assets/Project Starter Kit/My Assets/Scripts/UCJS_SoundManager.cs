using UnityEngine;
using System.Collections;

public class UCJS_SoundManager : MonoBehaviour {
	public AudioClip button;
	public AudioClip MainMenu;
	public AudioClip GamePlayJeep1;
	public AudioClip GamePlayJeep2;
	public AudioClip PanelsClip;
	public AudioClip LevelComplete;
	public AudioClip LevelFail;
	public AudioClip JeepSelection;
    public AudioClip CoinCollect;

	public AudioSource soundSource;
	public AudioSource musicSource;

	public  enum NameOfSounds {
		Button,
		MainMenu,
		GamePlayJeep1,
		GamePlayJeep2,
		PanelsClip,
		LevelComplete,
		LevelFail,
		JeepSelection,
        CoinCollect
	}

	public static UCJS_SoundManager Instance;
	public static UCJS_SoundManager soundInstance;

	// Use this for initialization
	void Awake () {
		Instance = this;
		if (soundInstance == null) {
			soundInstance = this;
		}

	}


	public static void PlaySound( NameOfSounds  id){
		switch (id) {
		case (NameOfSounds.Button):
			{
				Instance.playSound (Instance.button, 1f, false);	
			  break;
			}

		case (NameOfSounds.MainMenu):
			{
				Instance.playMusic (Instance.MainMenu, 1f, true);	
				break;
			}
		case (NameOfSounds.GamePlayJeep1):
			{
				Instance.playMusic (Instance.GamePlayJeep1, 1f, true);	
				break;
			}
		case (NameOfSounds.GamePlayJeep2):
			{
				Instance.playMusic (Instance.GamePlayJeep2, 1f, true);	
				break;
			}
		case (NameOfSounds.PanelsClip):
			{
				Instance.playMusic (Instance.PanelsClip, 1f, true);	
				break;
			}
		case (NameOfSounds.LevelComplete):
			{
				Instance.playMusic (Instance.LevelComplete, 1f, false);	
				break;
			}
		case (NameOfSounds.LevelFail):
			{
				Instance.playMusic (Instance.LevelFail, 1f, false);	
				break;
			}
		case (NameOfSounds.JeepSelection):
			{
				Instance.playMusic (Instance.JeepSelection, 1f, false);	
				break;
			}
            case (NameOfSounds.CoinCollect):
                {
                    Instance.playMusic(Instance.CoinCollect, 1f, false);
                    break;
                }
		}
	}


	void playSound(AudioClip sound, float volume, bool isLoop){
		soundSource.clip = sound;
		soundSource.volume = volume;
		soundSource.loop = isLoop;
		soundSource.Play ();
	}
	void playMusic(AudioClip sound, float volume, bool isLoop){
		musicSource.clip = sound;
		musicSource.volume = volume;
		musicSource.loop = isLoop;
		musicSource.Play ();
	}
}
