using UnityEngine;

public class SteakEater : MonoBehaviour
{
    public GameObject[] animals;
    public float eatDistance = 0.05f;
    public AudioClip eatingClip;
    public ParticleSystem eatingParticlesPrefab;

    private bool isEaten = false;

    void OnDisable()
    {
        isEaten = false;
    }

    void Update()
    {
        if (isEaten) return;

        foreach (GameObject animal in animals)
        {
            if (animal == null || !animal.activeInHierarchy) continue;

            float dist = Vector3.Distance(transform.position, animal.transform.position);
            if (dist < eatDistance)
            {
                Eat();
                break;
            }
        }
    }

    void Eat()
    {
        isEaten = true;

        if (eatingParticlesPrefab != null)
        {
            ParticleSystem instance = Instantiate(eatingParticlesPrefab, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }

        if (eatingClip != null)
        {
            AudioSource.PlayClipAtPoint(eatingClip, transform.position);
        }

        SetVisible(false);
    }

    void SetVisible(bool visible)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = visible;
        }
        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = visible;
        }
    }
}