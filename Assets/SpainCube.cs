using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class SpainCube : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Transform cube;
    [SerializeField] private float duration;
    [SerializeField] private float rotationSpeed;
    void Start()
    {
        button.onClick.AddListener(Spin); 
    }

    private async void Spin()
    {
        button.interactable = false;
        float time = 0;
        while (time < duration) 
        {
            cube.Rotate(Vector3.one, rotationSpeed * Time.deltaTime);
            time += Time.deltaTime;
            await Task.Yield();
        }


        button.interactable = true;

    }
    
}
