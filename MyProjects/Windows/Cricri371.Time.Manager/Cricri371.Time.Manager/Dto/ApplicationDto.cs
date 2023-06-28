namespace Cricri371.Time.Manager.Dto
{
    /// <summary>
    /// Class ApplicationDto.
    /// </summary>
    public class ApplicationDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value> The identifier. </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value> The company. </value>
        public CompanyDto Company { get; set; }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDto" /> class.
        /// </summary>
        public ApplicationDto()
        {
            this.Company = new CompanyDto();
        }

        #endregion Constructor
    }
}