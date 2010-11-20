using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleContact
    {
        public Particle[] Particles { get; set; }
        public double Restitution { get; set; }
        public double Penetration { get; set; }
        public Vector ContactNormal { get; set; }

        public ParticleContact()
        { Particles = new Particle[2]; }

        public void Resolve(double deltaTime)
        {
            ResolveVelocity(deltaTime);
            ResolveInterPenetration(deltaTime);
        }
        public double CalculateSeparatingVelocity()
        {
            Vector relativeVelocity = Particles[0].Velocity;
            if (Particles[1] != null)
                relativeVelocity -= Particles[1].Velocity;

            return relativeVelocity * ContactNormal;
        }

        private void ResolveVelocity(double deltaTime)
        {
            // Find the velocity in the direction of the contact.
            double seperatingVelocity = CalculateSeparatingVelocity();

            if (seperatingVelocity > 0)
            {
                // The contact is either separating or stationary - there’s
                // no impulse required.
                return;
            }

            // Calculate the new separating velocity.
            double newSepVelocity = -seperatingVelocity * Restitution;

            #region Special Case: objects in resting contact

            // Check the velocity build-up due to acceleration only.
            Vector velocityFromAcceleration = Particles[0].Acceleration;

            if (Particles[1] != null)
                velocityFromAcceleration -= Particles[1].Acceleration;

            double separationVelocityFromAccel = velocityFromAcceleration * ContactNormal * deltaTime;

            // If we’ve got a closing velocity due to acceleration build-up,
            // remove it from the new separating velocity.
            if (separationVelocityFromAccel < 0)
            {
                newSepVelocity += Restitution * separationVelocityFromAccel;

                // Make sure we haven’t removed more than was
                // there to remove.
                if (newSepVelocity < 0) newSepVelocity = 0;
            }

            #endregion

            double deltaVelocity = newSepVelocity - seperatingVelocity;

            // We apply the change in velocity to each object in proportion to
            // its inverse mass (i.e., those with lower inverse mass [higher
            // actual mass] get less change in velocity).
            double totalInverseMass = Particles[0].InverseMass;

            if (Particles[1] != null)
                totalInverseMass += Particles[1].InverseMass;

            // If all particles have infinite mass, then impulses have no effect.
            if (totalInverseMass <= 0)
                return;

            // Calculate the impulse to apply.
            double impulse = deltaVelocity / totalInverseMass;

            // Find the amount of impulse per unit of inverse mass.
            Vector impulsePerUnitMass = ContactNormal * impulse;

            // Apply impulses: they are applied in the direction of the contact,
            // and are proportional to the inverse mass.
            Particles[0].Velocity = Particles[0].Velocity + impulsePerUnitMass * Particles[0].InverseMass;

            if (Particles[1] != null)
            {
                // Particle 1 goes in the opposite direction.
                Particles[1].Velocity = Particles[1].Velocity + impulsePerUnitMass * -Particles[1].InverseMass;
            }
        }
        private void ResolveInterPenetration(double deltaTime)
        {
            //If there are no penetrations, skip this step
            if (Penetration <= 0) return;

            // The movement of each object is based on its inverse mass,
            // Total inverse mass
            double totalInverseMass = Particles[0].InverseMass;

            if (Particles[1] != null)
                totalInverseMass += Particles[1].InverseMass;

            // If all particles have infinite mass, then do nothing.
            if (totalInverseMass <= 0) return;

            // Find the amount of penetration resolution per unit of inverse mass.
            Vector movePerUnitMass = ContactNormal * (-Penetration / totalInverseMass);

            // Apply the penetration resolution.
            Particles[0].Position = Particles[0].Position + movePerUnitMass * Particles[0].InverseMass;

            if (Particles[1] != null)
                Particles[1].Position = Particles[1].Position + movePerUnitMass * Particles[1].InverseMass;
        }
    }
}
