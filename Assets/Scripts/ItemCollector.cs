using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text cherriesText;
    [SerializeField] private AudioSource CollectSoundEffect;
    int cherries = 0;
    void start(){
        cherriesText = GetComponent<TextMeshProUGUI>();
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Cherry")){
            CollectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries : "+ cherries;
        }
    }
    
}
