namespace Lyu.Core.Domain.Entities
{
    public interface ISeo
    {
        /// <summary>
        /// meta keywords
        /// </summary>
        string MetaKeywords { get; set; }

        /// <summary>
        /// meta description
        /// </summary>
        string MetaDescription { get; set; }

        /// <summary>
        /// meta title
        /// </summary>
        string MetaTitle { get; set; }
        string SeName { get; set; }
    }
}