﻿using System;
using System.Diagnostics.Contracts;
using Modele.Generic.Exceptions;

namespace Modele.Generic
{
    public class PlainText
    {
        private string _text;
        public string Text { get { return _text; } }

        public PlainText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentCannotBeEmptyStringException>(!string.IsNullOrEmpty(text), "text");
        }

        #region override object
        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            var nume = (PlainText)obj;
            return Text.Equals(nume.Text);
        }
        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }
        #endregion
    }
}
