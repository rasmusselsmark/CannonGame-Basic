using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    public GameObject CannonBarrel;
    public GameObject CannonBallPrefab;
    public GameObject ExplosionPrefab;

    public KeyCode KeyUp;
    public KeyCode KeyDown;
    public KeyCode KeyFire;

    public UnityEngine.UI.Text ScoreUIText;

    private float _firePower = 10f;
    private int _score;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            if (ScoreUIText)
                ScoreUIText.text = _score.ToString();
        }
    }

    // Use this for initialization
    void Start ()
    {
        Reset ();
    }

    public void Reset()
    {
        gameObject.SetActive (true);
        CannonBarrel.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey (KeyUp))
        {
            RotateBarrel (1);
        }
        else if (Input.GetKey (KeyDown))
        {
            RotateBarrel (-1);
        }
        else if (Input.GetKeyUp (KeyFire))
        {
            FireCannon (_firePower);
        }
    }

    void RotateBarrel (int degrees)
    {
        CannonBarrel.transform.Rotate (new Vector3 (0, 0, degrees));
    }

    private void FireCannon (float power)
    {
        Vector2 position =
            CannonBarrel.transform.position + CannonBarrel.transform.right * 0.8f;

        GameObject cannonBall = Instantiate (
                              CannonBallPrefab,
                              position,
                              CannonBarrel.transform.rotation) as GameObject;

        cannonBall.GetComponent<CannonBall> ().FiringPlayer = this;
        cannonBall.GetComponent<Rigidbody2D> ().AddForce (
            CannonBarrel.transform.right * power,
            ForceMode2D.Impulse);
        Destroy (cannonBall.gameObject, 30);
    }

    public void GotHit ()
    {
        if (ExplosionPrefab)
        {
            GameObject explosion = Instantiate (
                ExplosionPrefab,
                this.transform.position,
                Quaternion.identity) as GameObject;
            Destroy (explosion, 1f);
        }

        this.gameObject.SetActive (false);
        Invoke ("Start", 2);
    }
}
