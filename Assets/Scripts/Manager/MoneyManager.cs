using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    public float value;
    private AudioSource moneySource;
    public AudioClip moneyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        moneySource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterStats>().money += value;
            moneySource.PlayOneShot(moneyPrefab);
            Destroy(gameObject,0.5f);
        }
    }
}
