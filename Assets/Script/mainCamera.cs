using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private static MainCamera instance;
    public static MainCamera Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
