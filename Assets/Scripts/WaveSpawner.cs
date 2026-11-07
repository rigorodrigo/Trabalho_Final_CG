using UnityEngine;
using System.Collections.Generic;
using System.Collections;
[System.Serializable]
public class EnemyGroup {
    public Enemy prefab;
    public int quantidade;
    public float intervalo;
    public WaypointPath caminho; 
}

[System.Serializable]
public class Wave
{
    public float pausa;
    public List<EnemyGroup> grupos;
}

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private List<Wave> ondas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExecutarFase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnarInimigo (EnemyGroup grupo)
    {
        Vector3 posicao = grupo.caminho.waypoints[0].position;
        Enemy novoInimigo = Instantiate(grupo.prefab,posicao, Quaternion.identity); // instancionado o prefab em rotação neutra e na primeira posição
        novoInimigo.path = grupo.caminho;
    }

    private IEnumerator SpawnarGrupo (EnemyGroup grupo)
    {
        for (int i = 0; i < grupo.quantidade; i ++)
        {
            SpawnarInimigo(grupo);
            yield return new WaitForSeconds(grupo.intervalo);
        }
    }

    private IEnumerator SpawnarOnda (Wave onda)
    {
        yield return new WaitForSeconds(onda.pausa);

        foreach (EnemyGroup grupo in onda.grupos) // para cada grupo na onda...
        {
            yield return StartCoroutine(SpawnarGrupo(grupo)); // spawanndo um grupo por vez
        }
    }

    private IEnumerator ExecutarFase ()
    {
        for (int i = 0; i< ondas.Count; i++)
        {
            yield return StartCoroutine(SpawnarOnda(ondas[i]));
            Debug.Log($"Onda número {i}");
        }

        Debug.Log("Fase Acabou.");
    }
}
