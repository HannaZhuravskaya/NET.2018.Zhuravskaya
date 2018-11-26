namespace No5.Solution
{
    /// <summary>
    /// Converter of document parts.
    /// </summary>
    public abstract class DocumentPartConverter
    {
        /// <summary>
        /// Document parts dynamic visit.
        /// </summary>
        /// <param name="documentPart">
        /// document part
        /// </param>
        /// <returns>
        /// converted string of document part.
        /// </returns>
        public string DynamicVisit(DocumentPart documentPart)
            => Visit((dynamic)documentPart);
        
        protected abstract string Visit(PlainText text);

        protected abstract string Visit(HyperLink link);

        protected abstract string Visit(BoldText text);
    }
}
