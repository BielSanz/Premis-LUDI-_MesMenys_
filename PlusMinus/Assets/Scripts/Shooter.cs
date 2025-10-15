using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform shootPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(ballPrefab, shootPoint.position, Quaternion.identity);
    }
}
