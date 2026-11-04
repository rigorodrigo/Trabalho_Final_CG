using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    public int pila;

    // quando o evento Enemy.Died é ouvido, o método EnemyDied é avisado
    private void OnEnable() {Enemy.Died += EnemyDied; }
    private void OnDisable() {Enemy.Died -= EnemyDied; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pila = 0;
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

    // método que é chamado quando um inimigo é morto

    void EnemyDied(Enemy enemy)
    {
        GanharPila();
    }
}
