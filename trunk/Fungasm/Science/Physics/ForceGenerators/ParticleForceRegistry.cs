using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    /// <summary>
    /// Holds all the force generators and the particles they apply to 
    /// </summary>
    public class ParticleForceRegistry
    {
        protected List<ParticleForceRegistration> Registry { get; set; }
        protected struct ParticleForceRegistration
        {
            public Particle particle;
            public IParticleForceGenerator fg;
        }

        public ParticleForceRegistry() { Registry = new List<ParticleForceRegistration>(); }

        public void Add(Particle particle, IParticleForceGenerator forceGen)
        {
            ParticleForceRegistration reg = new ParticleForceRegistration() { particle = particle, fg = forceGen };
            Registry.Add(reg);
        }
        public void Remove(Particle particle, IParticleForceGenerator forceGen)
        {
            ParticleForceRegistration reg = Registry.Find((p) => { return p.particle == particle && p.fg == forceGen; });
            Registry.Remove(reg);
        }
        public void Clear()
        {
            Registry.Clear();
        }
        public void UpdateForces(double deltaTime)
        {
            foreach (ParticleForceRegistration item in Registry)
            {
                item.fg.UpdateForce(item.particle, deltaTime);
            }
        }
    }
}
