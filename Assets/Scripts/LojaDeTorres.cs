using UnityEngine;
using System.Collections.Generic;
[System.Serializable]

public class OpcaoTorre
{
    public string nome;
    public Tower prefab;
    public int custo;
}

public class LojaDeTorres : MonoBehaviour
{

    [SerializeField] private PlayerStats jogador;
    [SerializeField] private List<OpcaoTorre> opcoes;
    private int selecionada = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tower Comprar(Vector3 posicao)
    {
        OpcaoTorre opcao = opcoes[selecionada];

        if (!jogador.GastarPila(opcao.custo))
        {
            Debug.Log($"Você não tem pila para compra a Torre {opcao.nome}! Ela custa {opcao.custo}");
            return null;
        }

        return Instantiate(opcao.prefab, posicao, Quaternion.identity);
    }


}
