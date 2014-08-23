//----------------------------------------------------------------------------
// AGG-Sharp - Version 1
// Copyright (C) 2007 Lars Brubaker http://agg-sharp.sourceforge.net/
//
// Permission to copy, use, modify, sell and distribute this software 
// is granted provided this copyright notice appears in all copies. 
// This software is provided "as is" without express or implied
// warranty, and with no claim as to its suitability for any purpose.
//
//----------------------------------------------------------------------------
// Contact: larsbrubaker@gmail.com
//          http://agg-sharp.sourceforge.net/
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace MatterHackers.Agg
{   

    public interface IColor
    {
        ColorRGBAf GetAsRGBA_Floats();
        ColorRGBA GetAsRGBA_Bytes();

        ColorRGBA gradient(ColorRGBA c, double k);

        int Red0To255 { get; }
        int Green0To255 { get; }
        int Blue0To255 { get; }
        int Alpha0To255 { get; }

        float Red0To1 { get; }
        float Green0To1 { get; }
        float Blue0To1 { get; }
        float Alpha0To1 { get; }
    } 
}