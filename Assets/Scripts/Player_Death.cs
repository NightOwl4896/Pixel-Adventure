using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Death : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource DeathSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update(){
        if( rb.velocity.y <= -50f){
            DeathSoundEffect.Play();
            anim.SetTrigger("death");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Trap")){
            DeathSoundEffect.Play();
            anim.SetTrigger("death");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
