using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
            Score.Instance.Add(1);
    }
}
