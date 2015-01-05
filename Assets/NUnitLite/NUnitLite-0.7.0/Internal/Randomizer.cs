// ***********************************************************************
// Copyright (c) 2009 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Reflection;
#if true
#endif

namespace NUnit.Framework.Internal
{
    /// <summary>
    /// Randomizer returns a set of random values in a repeatable
    /// way, to allow re-running of tests if necessary.
    /// </summary>
    public class Randomizer : Random
    {
        #region Static Members
        private static Random seedGenerator = new Random();

#if true
        private static Dictionary<MemberInfo, Randomizer> randomizers = new Dictionary<MemberInfo, Randomizer>();
#else
        private static System.Collections.Hashtable randomizers = new System.Collections.Hashtable();
#endif

        /// <summary>
        /// Get a random seed for use in creating a randomizer.
        /// </summary>
        public static int RandomSeed
        {
            get { return seedGenerator.Next(); }
        }

        /// <summary>
        /// Get a randomizer for a particular member, returning
        /// one that has already been created if it exists.
        /// This ensures that the same values are generated
        /// each time the tests are reloaded.
        /// </summary>
        public static Randomizer GetRandomizer(MemberInfo member)
        {
            if (randomizers.ContainsKey(member))
                return (Randomizer)randomizers[member];
            else
            {
                Randomizer r = new Randomizer();
                randomizers[member] = r;
                return (Randomizer)r;
            }
        }


        /// <summary>
        /// Get a randomizer for a particular parameter, returning
        /// one that has already been created if it exists.
        /// This ensures that the same values are generated
        /// each time the tests are reloaded.
        /// </summary>
        public static Randomizer GetRandomizer(ParameterInfo parameter)
        {
            return GetRandomizer(parameter.Member);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Construct a randomizer using a random seed
        /// </summary>
        public Randomizer() : base(RandomSeed) { }

        /// <summary>
        /// Construct a randomizer using a specified seed
        /// </summary>
        public Randomizer(int seed) : base(seed) { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return an array of random doubles between 0.0 and 1.0.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public double[] GetDoubles(int count)
        {
            double[] rvals = new double[count];

            for (int index = 0; index < count; index++)
                rvals[index] = NextDouble();

            return rvals;
        }

        /// <summary>
        /// Return an array of random doubles with values in a specified range.
        /// </summary>
        public double[] GetDoubles(double min, double max, int count)
        {
            double range = max - min;
            double[] rvals = new double[count];

            for (int index = 0; index < count; index++)
                rvals[index] = NextDouble() * range + min;

            return rvals;
        }

        /// <summary>
        /// Return an array of random ints with values in a specified range.
        /// </summary>
        public int[] GetInts(int min, int max, int count)
        {
            int[] ivals = new int[count];

            for (int index = 0; index < count; index++)
                ivals[index] = Next(min, max);

            return ivals;
        }
        #endregion
    }
}
