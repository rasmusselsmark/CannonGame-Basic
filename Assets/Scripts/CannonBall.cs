using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public Cannon FiringPlayer;

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name == "Grass")
        {
            GetComponent<Rigidbody2D> ().isKinematic = true;
            GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "Cannon")
        {
            Cannon cannon = collision.gameObject.GetComponent<Cannon> ();
            cannon.GotHit ();

            if (collision.gameObject.name != FiringPlayer.name)
            {
                FiringPlayer.Score += 1;
                FiringPlayer.Reset ();
            }

            Destroy (this.gameObject);
        }
    }
}
