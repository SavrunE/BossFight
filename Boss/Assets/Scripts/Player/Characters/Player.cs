using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public PlayerVariant[] Characters;
    private List<PlayerVariant> characters;
    private int i = 0;
    private bool selector;

    public event UnityAction<PlayerVariant> CharacterChanged;
    private void Awake()
    {
        characters = new List<PlayerVariant>();
        selector = true;
        for (i = 0; i < Characters.Length; i++)
        {
            PlayerVariant character = Instantiate(Characters[i], transform.position, Quaternion.identity, gameObject.transform);
            character.gameObject.SetActive(false);
            characters.Add(character);
        }
        Enabler(selector);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            selector = !selector;
            Enabler(selector);
        }
    }
    private void Enabler(bool selector)
    {
        if (selector)
        {
            characters[0].transform.position = characters[1].transform.position;
            ChangerEneble();
            CharacterChanged?.Invoke(characters[0]);
        }
        else
        {
            characters[1].transform.position = characters[0].transform.position;
            ChangerEneble();
            CharacterChanged?.Invoke(characters[1]);
        }
    }
    private void ChangerEneble()
    {
        characters[0].gameObject.SetActive(selector);
        characters[1].gameObject.SetActive(!selector);
    }
}
