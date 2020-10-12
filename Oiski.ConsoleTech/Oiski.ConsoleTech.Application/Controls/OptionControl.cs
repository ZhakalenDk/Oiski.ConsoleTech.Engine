﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine.Controls
{
    /// <summary>
    /// Defines a <see cref="Control"/> that can be selected during runtime
    /// </summary>
    public class OptionControl : SelectableControl
    {

        /// <summary>
        /// Initializes a new instance of type <see cref="OptionControl"/> where the text of the <see cref="Control"/> is set to <paramref name="_text"/>
        /// </summary>
        /// <param name="_text"></param>
        public OptionControl(string _text) : base(_text)
        {

        }

        /// <summary>
        /// INitializes a new instance of type <see cref="OptionControl"/> where the text and position is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_positon"></param>
        public OptionControl(string _text, Vector2 _positon) : this(_text)
        {
            Position = _positon;
        }
    }
}
