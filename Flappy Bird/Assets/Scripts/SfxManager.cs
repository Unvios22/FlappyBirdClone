using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxManager : MonoBehaviour {
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip triggerSound;

    private AudioSource _audioSource;

    private void Start() {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayJumpSound() {
        _audioSource.PlayOneShot(jumpSound);
    }

    public void PlayTriggerSound() {
        _audioSource.PlayOneShot(triggerSound);
    }
}
