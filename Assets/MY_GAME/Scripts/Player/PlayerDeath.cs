using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public bool isDead = false;
    private Animator animator;
    private SoundManager soundManager;
    private CubeJump cubeJump;
    private SaveManager saveManager;

    private void Start()
    {
        cubeJump = GetComponent<CubeJump>();
        animator = GetComponent<Animator>();
        soundManager = GetComponent<SoundManager>();

        saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();
    }

    public void Die()
    {
        if (!isDead)
        {
            cubeJump.canMove = false;
            soundManager.PlayDeathSound();
            isDead = true;
            animator.SetBool("Explode", true);
            explosionParticle.Play();
        }
    }
}
