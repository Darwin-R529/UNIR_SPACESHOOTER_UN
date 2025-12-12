using UnityEngine;

public class ClearExplotionAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float lifetime = 0.1f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
