using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MoveSpeed = 5f;
    private IMovement MovementInput;
    private Flashlight PlayerFlash;
    private SpriteRenderer PlayerSprite;
    public IInventory PlayerInventory;
    void Awake()
    {
        MovementInput = GetComponent<IMovement>();
        PlayerFlash = GetComponentInChildren<Flashlight>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerInventory = new PlayerInventory();
        CollectionController Collector = GetComponentInChildren<CollectionController>();
        Collector.Init(PlayerInventory);
    }

    void Update()
    {
        Vector3 MovementDirection = MovementInput.GetMovementDirection();

        transform.Translate(MovementDirection * MoveSpeed * Time.deltaTime, Space.World);
   
        PlayerFlash.UpdateFlashlight(transform.position, Time.deltaTime);


        if (MovementDirection.x < 0) { PlayerSprite.flipX = true; }
        else if (MovementDirection.x > 0) { PlayerSprite.flipX = false;}

    }

}
