using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    private LojaDeTorres loja;
    private  Tower torreAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loja = FindFirstObjectByType<LojaDeTorres>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (torreAtual != null) return;

        torreAtual = loja.Comprar(transform.position);
    }
}
