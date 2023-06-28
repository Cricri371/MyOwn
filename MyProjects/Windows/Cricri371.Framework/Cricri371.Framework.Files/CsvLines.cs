using System.Collections.Generic;

namespace Cricri371.Framework.Files
{
    /// <summary>
    /// Class CsvLines. 
    /// </summary>
    public class CsvLines
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsvLines" /> class. 
        /// </summary>
        public CsvLines()
        {
            this.PartOfLine = new List<string>();
        }

        /// <summary>
        /// Gets or sets the CPT line. 
        /// </summary>
        /// <value> The CPT line. </value>
        public int CptLine { get; set; }

        /// <summary>
        /// Gets the part of line. 
        /// </summary>
        /// <value> The part of line. </value>
        public IList<string> PartOfLine { get; private set; }

        /// <summary>
        /// Adds the part of line. 
        /// </summary>
        /// <param name="partOfLine"> The part of line. </param>
        public void AddPartOfLine(IList<string> partOfLine)
        {
            this.PartOfLine = partOfLine;
        }
    }
}