﻿namespace No5.Solution.DocumentPartConverterImplementations
{
    /// <summary>
    /// Convert document part to LaTeX.
    /// </summary>
    public class DocumentPartToLaTeX : DocumentPartConverter
    {
        protected override string Visit(PlainText text) => text.Text;

        protected override string Visit(HyperLink link) => "\\href{" + link.Url + "}{" + link.Text + "}";

        protected override string Visit(BoldText text) => "\\textbf{" + text.Text + "}";
    }
}
