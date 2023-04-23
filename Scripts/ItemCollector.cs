using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int wisps = 0;

    [SerializeField] private Text wispsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wisp"))
        {
            Destroy(collision.gameObject);
            wisps++;
            wispsText.text = "Wisps: " + wisps;
        }
    }
}
