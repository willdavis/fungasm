using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleSpring : IParticleForceGenerator
    {
        Particle _otherEnd;
        double _springConstant;
        double _restLength;

        public ParticleSpring(Particle other, double springConst, double restLength)
        {
            _otherEnd = other;
            _springConstant = springConst;
            _restLength = restLength;
        }

        #region IParticleForceGenerator Members

        public void UpdateForce(Particle particle, double deltaTime)
        {
            // Calculate the vector of the spring
            Vector force;
            force = particle.Position;
            force -= _otherEnd.Position;

            // Calculate the magnitude of the force
            double magnitude = force.Length();
            magnitude = Math.Abs(magnitude - _restLength);
            magnitude *= _springConstant;

            // Calculate the final force and apply it
            if (force != Vector.Zero)
            {
                force.Normalize();
            }
            force *= -magnitude;
            particle.AddForce(force);
        }

        #endregion
    }
}
