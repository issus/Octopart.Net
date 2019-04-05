namespace Octopart.Net.Schemas.Objects
{
    public class ReferenceDesign : Asset
    {
        /// <summary>
        /// Title of design document
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of design document contents
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Information about the data source
        /// </summary>
        public Attribution Attribution { get; set; }
    }
}