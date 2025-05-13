using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Doc"))
        {
            Debug.Log("Collision with Player detected");
            // Add your collision handling code here
        }
    }
}
