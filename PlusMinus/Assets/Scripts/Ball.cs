using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private bool isStuck = false;
    private Transform circleParent;

    void Update()
    {
        if (!isStuck)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Circle"))
        {
            StickToCircle(collision.collider.transform);
        }

        else if (collision.collider.CompareTag("Ball"))
        {
            Debug.Log("¡Perdiste!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void StickToCircle(Transform circle)
    {
        isStuck = true;
        circleParent = circle;

        transform.SetParent(circleParent);
        transform.localPosition = transform.localPosition;

        Destroy(GetComponent<Rigidbody2D>());
        gameObject.layer = LayerMask.NameToLayer("StuckBall");

        
        MathCircle mathCircle = circleParent.GetComponent<MathCircle>();
        if (mathCircle != null)
        {
            mathCircle.RegisterHit();
        }
    }

}
