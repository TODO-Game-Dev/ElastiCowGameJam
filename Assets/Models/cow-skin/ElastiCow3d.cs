using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElastiCow3d : MonoBehaviour
{
    [SerializeField] private Material elastivacaEyeMaterial;
    [SerializeField] private ParticleSystem fogParticle;
    [SerializeField] private bool redEye = false;
    [SerializeField] private bool fogActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        SetNormalEyes();
    }

    void OnValidate()
    {
        if (redEye)
        {
            SetRedEyes();
        }
        else
        {
            SetNormalEyes();
        }
        
        
        if (fogActive)
        {
            fogParticle.enableEmission = true;
        }
        else
        {
            fogParticle.enableEmission = false;
        }
    }

    // Update is called once per frame
    public void SetRedEyes()
    {
        elastivacaEyeMaterial.SetColor("_EmissionColor", new Color(138F/255f, 0F, 0F,1F));
        elastivacaEyeMaterial.EnableKeyword("_Emission");
    }
    public void SetNormalEyes()
    {
        elastivacaEyeMaterial.SetColor("_EmissionColor", new Color(0f, 0F, 0F,1F));
        elastivacaEyeMaterial.DisableKeyword("_Emission");
        fogParticle.enableEmission = false;
    }
}
