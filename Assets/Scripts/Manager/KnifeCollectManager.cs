using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollectManager : MonoBehaviour
{
	[SerializeField] private float knifeValue;
	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player")
        {
			other.gameObject.GetComponent<CharacterStats>().knifeCounter += 3;
			Destroy(gameObject);
        }
	}
}
