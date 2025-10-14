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
        // Si colisiona con el c�rculo
        if (collision.collider.CompareTag("Circle"))
        {
            StickToCircle(collision.collider.transform);
        }

        // Si colisiona con una c�psula (ya clavada o en movimiento)
        else if (collision.collider.CompareTag("Ball"))
        {
            Debug.Log("�Perdiste!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void StickToCircle(Transform circle)
    {
        isStuck = true;
        circleParent = circle;

        // Fijar posici�n al c�rculo
        transform.SetParent(circleParent);
        transform.localPosition = transform.localPosition;

        // Eliminar Rigidbody (ya no se mover�)
        Destroy(GetComponent<Rigidbody2D>());

        // Cambiar de capa a "StuckBall"
        gameObject.layer = LayerMask.NameToLayer("StuckBall");
    }
}
