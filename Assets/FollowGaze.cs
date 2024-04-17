using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class FollowGaze : MonoBehaviour
{
    public Transform headTransform; // Reference to the head transform (XR camera or HMD)
    public Vector3 offset; // Offset from the head position
    private TextMeshPro scoreText; // Reference to the score TextMeshPro object

    void Start()
    {
        // Find the TextMeshPro component with the tag "Score"
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro component with the tag 'Score' not found.");
        }
    }

    void Update()
    {
        if (scoreText != null && headTransform != null)
        {
            // Calculate the desired position for the score text
            Vector3 desiredPosition = headTransform.position + headTransform.rotation * offset;

            // Update the position of the score text
            scoreText.transform.position = desiredPosition;

            // Make the score text face the camera
            scoreText.transform.LookAt(headTransform);
        }
    }
}
