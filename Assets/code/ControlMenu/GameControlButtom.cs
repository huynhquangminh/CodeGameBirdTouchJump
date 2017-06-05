using UnityEngine;
using System.Collections;

public class GameControlButtom : MonoBehaviour {

    [SerializeField]
    private AudioClip soundclick;
    [SerializeField]
    private AudioSource click;
    public void LoadScenePlay()
    {
        click.PlayOneShot(soundclick);
        Application.LoadLevel("GamePlay3");
    }
}
