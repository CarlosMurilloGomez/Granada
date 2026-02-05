using UnityEngine;

public class Granada : MonoBehaviour
{
    public GameObject explosion;
    public float expForce, radius;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(_explosion, 3); // lo destruimos a los 3 segundos
        applyExpForce();
        gameObject.SetActive(false);
    }
    private void applyExpForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider near in colliders)
        {
            Rigidbody rigg = near.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}
