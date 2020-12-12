using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Player player;

    private PlayerVariant character;

    private void OnEnable()
    {
        player.CharacterChanged += ChangeCharacter;
    }
    private void OnDisable()
    {

        player.CharacterChanged -= ChangeCharacter;
    }
    private void ChangeCharacter(PlayerVariant character)
    {
        this.character = character;
    }

    void Update()
    {
        transform.position = character.gameObject.transform.position + cameraPosition;
    }
}