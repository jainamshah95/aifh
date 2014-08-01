﻿using AIFH_Vol2.Core.Randomize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIFH_Vol2.Core.General
{
    /// <summary>
    /// Basic vector algebra operators.
    /// Vectors are represented as arrays of doubles.
    /// <p/>
    /// This class was created to support the calculations
    /// in the PSO algorithm.
    /// <p/>
    /// This class is thread safe.
    /// 
    /// Contributed by:
    /// Geoffroy Noel
    /// https://github.com/goffer-looney
    /// </summary>
    public class VectorAlgebra
    {
        /// <summary>
        /// v1 = v1 + v2
        /// </summary>
        /// <param name="v1">an array of doubles</param>
        /// <param name="v2">an array of doubles</param>
        public static void Add(double[] v1, double[] v2)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                v1[i] += v2[i];
            }
        }

        
        /// <summary>
        /// v1 = v1 - v2 
        /// </summary>
        /// <param name="v1">v1 an array of doubles</param>
        /// <param name="v2">v2 an array of doubles</param>
        public static void Sub(double[] v1, double[] v2)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                v1[i] -= v2[i];
            }
        }

        /// <summary>
        /// v = -v 
        /// </summary>
        /// <param name="v">an array of doubles.</param>
        public static void Neg(double[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = -v[i];
            }
        }

        /// <summary>
        /// v = k * U(0,1) * v
        ///
        /// The components of the vector are multiplied
        /// by k and a random number.
        /// A new random number is generated for each
        /// component. 
        /// </summary>
        /// <param name="rnd">Random number generator.</param>
        /// <param name="v">Array of doubles.</param>
        /// <param name="k">A scaler.</param>
        public static void MulRand(IGenerateRandom rnd, double[] v, double k)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] *= k * rnd.NextDouble();
            }
        }

        /// <summary>
        /// v = k * v
        /// <p/>
        /// The components of the vector are multiplied
        /// by k. 
        /// </summary>
        /// <param name="v">an array of doubles.</param>
        /// <param name="k">k a scalar.</param>
        public static void Mul(double[] v, double k)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] *= k;
            }
        }

        /// <summary>
        /// dst = src
        /// Copy a vector. 
        /// </summary>
        /// <param name="dst">an array of doubles</param>
        /// <param name="src">an array of doubles</param>
        public static void Copy(double[] dst, double[] src)
        {
            Array.Copy(src, dst, src.Length);
        }

        /// <summary>
        /// v = U(0, 0.1) 
        /// </summary>
        /// <param name="rnd">A random number generator.</param>
        /// <param name="v">an array of doubles</param>
        public static void Randomise(IGenerateRandom rnd, double[] v)
        {
            Randomise(rnd, v, 0.1);
        }

        /// <summary>
        /// v = U(-1, 1) * maxValue
        /// <p/>
        /// Randomise each component of a vector to
        /// [-maxValue, maxValue]. 
        /// </summary>
        /// <param name="rnd">Random number generator.</param>
        /// <param name="v">An array of doubles.</param>
        /// <param name="maxValue">Maximum value +/-.</param>
        public static void Randomise(IGenerateRandom rnd, double[] v, double maxValue)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = (2 * rnd.NextDouble() - 1) * maxValue;
            }
        }

        
        /// <summary>
        /// For each components, reset their value to maxValue if
        /// their absolute value exceeds it. 
        /// </summary>
        /// <param name="v">An array of doubles.</param>
        /// <param name="maxValue">If -1 this function does nothing.</param>
        public static void ClampComponents(double[] v, double maxValue)
        {
            if (maxValue != -1)
            {
                for (int i = 0; i < v.Length; i++)
                {
                    if (v[i] > maxValue) v[i] = maxValue;
                    if (v[i] < -maxValue) v[i] = -maxValue;
                }
            }
        }

        /// <summary>
        /// Take the dot product of two vectors. 
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The dot product.</returns>
        public static double DotProduct(double[] v1, double[] v2)
        {
            double d = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                d += v1[i] * v2[i];
            }
            return Math.Sqrt(d);
        }
    }
}