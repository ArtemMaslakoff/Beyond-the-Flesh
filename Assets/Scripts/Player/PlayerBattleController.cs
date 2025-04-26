using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    public Attack attack;
    public float attackCooldown;
    private float lastAttackTime; // Время последней атаки

    public new Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack.isPlayerAttack = true;
        lastAttackTime = -attackCooldown; // Инициализируем время последней атаки
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown) // 0 - левая кнопка мыши
        {
            Attack();
        }
    }
    private void Attack()
    {
        // Вызываем атаку
        attack.DoAttack(GetComponent<Player>().creature.transform, camera.ScreenToWorldPoint(Input.mousePosition));

        // Обновляем время последней атаки
        lastAttackTime = Time.time;
    }
}
