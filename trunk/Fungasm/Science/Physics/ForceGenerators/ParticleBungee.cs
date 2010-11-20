using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleBungee : IParticleForceGenerator
    {
        Particle _otherEnd;
        double _springConstant;
        double _restLength;

        public ParticleBungee(Particle other, double springCoeff, double restLength)
        {
            _otherEnd = other;
            _springConstant = springCoeff;
            _restLength = restLength;
        }

        #region IParticleForceGenerator Members

        public void UpdateForce(Particle particle, double deltaTime)
        {
            // Calculate the vector of the spring
            Vector force;
            force = particle.Position;
            force -= _otherEnd.Position;

            // Check if the bungee is compressed
            double magnitude = force.Length();
            if (magnitude <= _restLength)
                return;

            // Calculate the magnitude of the force
            magnitude = _springConstant * (_restLength - magnitude);

            // Calculate the final force and apply it
            force.Normalize();
            force *= magnitude;
            particle.AddForce(force);
        }

        #endregion
    }
}
