using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int pila;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pila = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void addPila()
    {
        pila += 10;
        Debug.Log(pila);
    }
}
