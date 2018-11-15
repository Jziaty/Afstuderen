using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionTrigger : MonoBehaviour {

    public ParticleSystem rainDrops;
    public ParticleSystem splatterParticles;

    List<ParticleCollisionEvent> collisionEvents;
    private static readonly Color32 color = new Color32(255, 255, 255, 255);

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject obj)
    {
        if (splatterParticles != null && rainDrops != null)
        {
            int count = rainDrops.GetCollisionEvents(obj, collisionEvents);
            for (int i = 0; i < count; i++)
            {
                ParticleCollisionEvent evt = collisionEvents[i];
                Vector3 pos = evt.intersection;
                EmitAtLocation(evt/*, ref pos*/);
            }
        }
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    ParticlePhysicsExtensions.GetCollisionEvents(rainDrops, other, collisionEvents);

    //    for (int i = 0; i < collisionEvents.Count; i++)
    //    {
    //        //splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
    //        EmitAtLocation(collisionEvents[i]);
    //    }
    //}

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        splatterParticles.transform.position = particleCollisionEvent.intersection;
        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        ParticleSystem.MainModule psMain = splatterParticles.main;
        //psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        splatterParticles.Emit(1);
    }

    private void Emit(ParticleSystem p, ref Vector3 pos)
    {
        int count = UnityEngine.Random.Range(2, 5);
        while (count != 0)
        {
            float yVelocity = UnityEngine.Random.Range(1.0f, 3.0f);
            float zVelocity = UnityEngine.Random.Range(-2.0f, 2.0f);
            float xVelocity = UnityEngine.Random.Range(-2.0f, 2.0f);
            const float lifetime = 0.75f;// UnityEngine.Random.Range(0.25f, 0.75f);
            float size = UnityEngine.Random.Range(0.05f, 0.1f);
            ParticleSystem.EmitParams param = new ParticleSystem.EmitParams();
            param.position = pos;
            param.velocity = new Vector3(xVelocity, yVelocity, zVelocity);
            param.startLifetime = lifetime;
            param.startSize = size;
            param.startColor = color;
            p.Emit(param, 1);
            count--;
        }
    }
}
