using UnityEngine;

public class CannonBall : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name == "Grass")
        {
            GetComponent<Rigidbody2D> ().isKinematic = true;
            GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
        }
    }
}
