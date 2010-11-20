using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science.Physics
{
    public class ParticleContactResolver
    {
        /// <summary>
        /// This is a performance tracking value - keep a record of the actual number of iterations used.
        /// </summary>
        private int _iterationsUsed { get; set; }

        public int Iterations { get; set; }
        public ParticleContactResolver(int iterations)
        { Iterations = iterations; }

        public void ResolveContacts(List<ParticleContact> contactList, double deltaTime)
        {
            _iterationsUsed = 0;

            while (_iterationsUsed < Iterations)
            {
                // Find the contact with the largest closing velocity;
                // Velocities less than zero are closing
                // Velocities greater than zero are seperating and are ignored
                double maxSepVelocity = 0;
                int maxIndex = 0;

                for (int i = 0; i < contactList.Count; i++)
                {
                    double seperationVelocity = contactList[i].CalculateSeparatingVelocity();

                    if (seperationVelocity < maxSepVelocity)
                    {
                        maxSepVelocity = seperationVelocity;
                        maxIndex = i;
                    }
                }

                //resolve the contact
                contactList[maxIndex].Resolve(deltaTime);
                _iterationsUsed++;
            }
        }
    }
}
