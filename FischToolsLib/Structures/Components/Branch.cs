using System;
using System.Collections.Generic;
using System.Text;

namespace FischLib.Structures.Components
{
    public enum Direction
    {
        Both,
        LeftToRight,
        RightToLeft
    }

    public class Branch
    {
        double weight;
        Node LeftNode;
        Node RightNode;

    }
}
