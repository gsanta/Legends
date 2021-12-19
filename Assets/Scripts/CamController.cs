using Cinemachine;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Player playerTarget;
    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        playerTarget = FindObjectOfType<Player>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        virtualCamera.Follow = playerTarget.transform;
    }
}
