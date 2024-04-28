using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AttachGameObjectsToParticles : MonoBehaviour
{
    public GameObject m_Prefab;

    private ParticleSystem m_ParticleSystem;
    private List<GameObject> m_Instances = new List<GameObject>();
    private ParticleSystem.Particle[] m_Particles;
    private List<Vector3> prevPos = new List<Vector3>();

    int count;

    // Start is called before the first frame update
    void Start() {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_ParticleSystem.main.maxParticles];
    }

    // Update is called once per frame
    void Update() {
        count = m_ParticleSystem.GetParticles(m_Particles);

        while (m_Instances.Count < count) {
            m_Instances.Add(Instantiate(m_Prefab, m_ParticleSystem.transform));
            prevPos.Add(new Vector3(0,0,0));
        }

        bool worldSpace = (m_ParticleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
        for (int i = 0; i < m_Instances.Count; i++) {
            if (i < count) {
                if (worldSpace) {    
                    m_Instances[i].transform.position = m_Particles[i].position;
                } else {

                    if (Vector3.Distance(prevPos[i],  m_Particles[i].position) > 0.5f) {
                        m_Instances[i].transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0;
                        m_Instances[i].transform.GetComponent<FireflyLightControl>().timer = 0;
                    }

                    m_Instances[i].transform.localPosition = m_Particles[i].position;

                }
                m_Instances[i].SetActive(true);
            } else {
                m_Instances[i].SetActive(false);
            }

            prevPos[i] =  m_Particles[i].position;

        }
    }
}
