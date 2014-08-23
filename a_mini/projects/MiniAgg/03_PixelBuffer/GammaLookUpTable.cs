//----------------------------------------------------------------------------
// Anti-Grain Geometry - Version 2.4
// Copyright (C) 2002-2005 Maxim Shemanarev (http://www.antigrain.com)
//
// C# Port port by: Lars Brubaker
//                  larsbrubaker@gmail.com
// Copyright (C) 2007
//
// Permission to copy, use, modify, sell and distribute this software 
// is granted provided this copyright notice appears in all copies. 
// This software is provided "as is" without express or implied
// warranty, and with no claim as to its suitability for any purpose.
//
//----------------------------------------------------------------------------
// Contact: mcseem@antigrain.com
//          mcseemagg@yahoo.com
//          http://www.antigrain.com
//----------------------------------------------------------------------------
 
using System;

namespace MatterHackers.Agg
{
    public class GammaLookUpTable
    {

        const int GAMMA_SHIFT = 8;
        const int GAMMA_SIZE = 1 << GAMMA_SHIFT;
        const int GAMMA_MASK = GAMMA_SIZE - 1;

        double m_gamma;
        byte[] m_dir_gamma;
        byte[] m_inv_gamma; 

        public GammaLookUpTable(double gamma = 1)
        {
            m_gamma = gamma;
            m_dir_gamma = new byte[GAMMA_SIZE];
            m_inv_gamma = new byte[GAMMA_SIZE];
            SetGamma(m_gamma);
        }

        void SetGamma(double g)
        {
            m_gamma = g;
            double inv_g = 1.0 / g;
            for (int i = GAMMA_SIZE - 1; i >= 0; --i)
            {
                m_dir_gamma[i] = (byte)AggBasics.uround(Math.Pow(i / (double)GAMMA_MASK, m_gamma) * (double)GAMMA_MASK);
                m_inv_gamma[i] = (byte)AggBasics.uround(Math.Pow(i / (double)GAMMA_MASK, inv_g) * (double)GAMMA_MASK);
            }
        }

        public double Gamma
        {

            get { return m_gamma; }
        }

        public byte dir(int v)
        {
            return m_dir_gamma[v];
        }

        public byte inv(int v)
        {
            return m_inv_gamma[v];
        }
    }
}
