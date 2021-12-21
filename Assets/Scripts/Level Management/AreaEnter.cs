using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField]
    private string transitionAreaName;

    private void Start()
    {
        if (transitionAreaName == Player.instance.transitionName)
        {
            Player.instance.transform.position = transform.position;
        }
    }
}
