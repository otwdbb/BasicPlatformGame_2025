using UnityEditor.TerrainTools;
using UnityEngine;

public class pinkTriangleCollector : MonoBehaviour
{
    string test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        
    }

  

}
