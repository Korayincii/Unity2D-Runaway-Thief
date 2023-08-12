using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    private CharacterController player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.speed = 10;
            StartCoroutine(speedDecrease());
        }
        
    }


    private IEnumerator speedDecrease()
    {
        yield return new WaitForSeconds(3);
        player.speed = 5;
    }
}
