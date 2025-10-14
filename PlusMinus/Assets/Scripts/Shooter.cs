using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ballPrefab; // arrastra tu prefab aquí en el inspector
    public Transform shootPoint;  // el punto desde donde disparas

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // clic izquierdo o toque
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(ballPrefab, shootPoint.position, Quaternion.identity);
    }
}
