using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    public int pila;
    [SerializeField] private int pilaInicial = 50;  // o player iniciará com um valor X de pila, a definir 

    // quando o evento Enemy.Died é ouvido, o método EnemyDied é avisado
    private void OnEnable() {Enemy.Died += EnemyDied; }
    private void OnDisable() {Enemy.Died -= EnemyDied; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pila = pilaInicial;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GanharPila()
    {
        pila += 10;
        Debug.Log(pila);
    }

    public bool GastarPila (int valor)
    {
        if (pila < valor) return false;  // afirma que não havia fundos para a compra

        pila -= valor;
        
        Debug.Log($"Compra realizada com sucesso! Compra de {valor} pila, total restante: {pila} pila");

        return true;  // confirmando que a compra foi realizada sem problemas
    }

    // método que é chamado quando um inimigo é morto

    void EnemyDied(Enemy enemy)
    {
        GanharPila();
    }
}
