using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicArea : MonoBehaviour
{
    public float damagePerSecond = 1f;
    private bool inToxicArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inToxicArea = true;//player in toxic area
            StartCoroutine(ApplyToxicDamage(other.gameObject.GetComponent<HealthController>()));//starting the coroutine 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inToxicArea = false;//player out of the toxic area
        }
    }

    private IEnumerator ApplyToxicDamage(HealthController healthController)
    {
        while (inToxicArea)
        {
            healthController.TakeDamage(damagePerSecond * Time.deltaTime);//player is taking damage while staying in toxic area
            yield return null;
        }
    }
}
