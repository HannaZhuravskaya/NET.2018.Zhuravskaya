using System;
using System.Collections.Generic;

namespace No5.Solution
{
    /// <summary>
    /// Document class/
    /// </summary>
    public class Document
    {
        private readonly List<DocumentPart> _parts;

        /// <summary>
        /// Initializes a new instance of Document.
        /// </summary>
        /// <param name="parts">
        /// parts of document.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// parts must not be null.
        /// </exception>
        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }

            this._parts = new List<DocumentPart>(parts);
        }

        /// <summary>
        /// Convert document to string format.
        /// </summary>
        /// <param name="converter">
        /// string format
        /// </param>
        /// <returns>
        /// converted document
        /// </returns>
        public string ConvertTo(DocumentPartConverter converter)
        {
            string output = string.Empty;

            foreach (DocumentPart part in this._parts)
            {
                output += $"{converter.DynamicVisit(part)}\n";
            }

            return output;
        }
    }
}