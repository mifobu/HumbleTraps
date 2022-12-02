using UnityEngine;

public class CharacterMover : MonoBehaviour, ICharacterMover
{
    [SerializeField] 
    public int Health {get; set;}
    [SerializeField] 
    private bool isPlayer;
    public bool IsPlayer => isPlayer;
    private CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(new Vector3(horizontal, 0, vertical));
    }
}
