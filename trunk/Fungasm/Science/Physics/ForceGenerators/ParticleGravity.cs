using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleGravity : IParticleForceGenerator
    {
        Vector _gravity;

        public ParticleGravity(Vector gravity) { _gravity = gravity; }

        #region IParticleForceGenerator Members

        public void UpdateForce(Particle particle, double deltaTime)
        {
            if (!particle.HasFiniteMass)
                return;

            particle.AddForce(_gravity);
        }

        #endregion
    }
}
