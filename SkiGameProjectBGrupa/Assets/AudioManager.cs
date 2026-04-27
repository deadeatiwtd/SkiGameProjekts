using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip collisionSound;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        Obstacle.OnPlayerHit += PlayCollisionSound;
    }
    private void PlayCollisionSound()
    {
        audioSource.PlayOneShot(collisionSound);
    }
}
