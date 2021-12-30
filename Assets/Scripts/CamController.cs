using Cinemachine;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Player playerTarget;
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private int musicToPlay;

    private bool musicAlreadyPlaying;

    void Start()
    {
        playerTarget = FindObjectOfType<Player>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        virtualCamera.Follow = playerTarget.transform;
    }

    private void Update()
    {
        if (!musicAlreadyPlaying)
        {
            musicAlreadyPlaying = true;
            AudioManager.instance.PlayBackgroundMusic(musicToPlay);
        }
    }
}
