using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material skyboxMaterial;

    private void Start()
    {
        RenderSettings.skybox = skyboxMaterial;
    }
}
