using UnityEngine;
using UnityEngine.UI;

public class MoveModel : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public Button moveLeftButton;
    public Button moveRightButton;

    void Start()
    {
        // Attach click listeners to the buttons
        moveLeftButton.onClick.AddListener(MoveLeft);
        moveRightButton.onClick.AddListener(MoveRight);
    }

    void MoveLeft()
    {
        // Move the GameObject to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        // Move the GameObject to the right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
