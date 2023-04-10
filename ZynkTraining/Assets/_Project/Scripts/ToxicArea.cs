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
            inToxicArea = true;
            StartCoroutine(ApplyToxicDamage(other.gameObject.GetComponent<HealthController>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inToxicArea = false;
        }
    }

    private IEnumerator ApplyToxicDamage(HealthController healthController)
    {
        while (inToxicArea)
        {
            healthController.TakeDamage(damagePerSecond * Time.deltaTime);
            yield return null;
        }
    }
}
