﻿namespace No5.Solution.DocumentPartConverterImplementations
{
    /// <summary>
    /// Convert document part to plain text.
    /// </summary>
    public class DocumentPartToPlainText : DocumentPartConverter
    {
        protected override string Visit(PlainText text) => text.Text;

        protected override string Visit(HyperLink link) => link.Text + " [" + link.Url + "]";

        protected override string Visit(BoldText text) => "**" + text.Text + "**";
    }
}