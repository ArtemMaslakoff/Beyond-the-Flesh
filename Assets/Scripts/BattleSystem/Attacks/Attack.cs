using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public Bullet bulletPrefab;

    public bool isPlayerAttack = false;
    void Start()
    {
        
    }

    void Update()
    {

    }
    public abstract void DoAttack(Transform creatureTransform, Vector3 mousePosition);
}
