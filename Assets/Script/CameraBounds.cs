using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Vector2 screenBounds;

    private void Awake()
    {
        // Calculate the screen bounds based on the camera's viewport
        CalculateScreenBounds();
    }

    private void CalculateScreenBounds()
    {
        // Calculate the screen bounds based on the camera's viewport
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        screenBounds = new Vector2(cameraWidth, cameraHeight);
    }

    public Vector2 GetScreenBounds()
    {
        return screenBounds;
    }
}
