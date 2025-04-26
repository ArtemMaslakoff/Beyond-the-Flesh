using UnityEngine;

[RequireComponent(typeof(PlayerCameraController))]
[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerBattleController))]
public class Player : MonoBehaviour
{
    public PlayerCameraController playerCameraController;
    public PlayerMovementController playerMovementController;
    public PlayerBattleController playerBattleController;
    public Inventory inventory;
    public Creature creature;
    void Start()
    {
        this.creature.tag = "PlayerCreature";

        playerCameraController = GetComponent<PlayerCameraController>();
        playerCameraController.creature = creature.transform;

        playerMovementController = GetComponent<PlayerMovementController>();
        playerMovementController.Set(creature.movementSpeed, creature.GetComponent<Rigidbody2D>(), playerCameraController.camera);

        playerBattleController = GetComponent<PlayerBattleController>();
        playerBattleController.attack = creature.attack;
        playerBattleController.attackCooldown = creature.attackCooldown;
        playerBattleController.camera = playerCameraController.camera;
    }

    void Update()
    {
        
    }
    public void SetCreature(Creature creature)
    {
        this.creature.tag = "Creature";
        this.creature = creature;
        this.creature.tag = "PlayerCreature";

        playerCameraController.creature = creature.transform;
        playerMovementController.Set(creature.movementSpeed, creature.GetComponent<Rigidbody2D>(), playerCameraController.camera);
    }
}
