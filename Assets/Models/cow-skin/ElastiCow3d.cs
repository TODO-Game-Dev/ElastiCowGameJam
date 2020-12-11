using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElastiCow3d : MonoBehaviour
{
    [SerializeField] private Material elastivacaEyeMaterial;
    [SerializeField] private ParticleSystem fogParticle;
    [SerializeField] private float height = 0;
    
    

    [SerializeField] private bool redEye = false;
    [SerializeField] private bool fogActive = false;
    
    [SerializeField]
    private List<GameObject> legs;

    private List<Vector3> _legsScaleCache = new List<Vector3>();
    private float _lastHeight = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject leg in legs)
        {
            _legsScaleCache.Add(leg.transform.localScale);
        }

        
        SetNormalEyes();
    }

    void Update()
    {
        if (height != _lastHeight)
        {
            var heightDiff = height- _lastHeight;
            int count = 0;
            foreach (GameObject leg in legs)
            {
                Vector3 newScale = new Vector3(_legsScaleCache[count].x, _legsScaleCache[count].y + height,
                    _legsScaleCache[count].z);
                leg.transform.localScale = newScale;
                count++;
            }
            if (this.transform.position.y+heightDiff > 0){
                this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+heightDiff,this.transform.position.z);
            }
            _lastHeight = height;
        }

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
