namespace Quellatalo.Nin.HOCRReader
{
    /// <summary>
    /// Options for HOCR finding text.
    /// </summary>
    public enum SearchOptions
    {
        /// <summary>
        /// Exact text.
        /// </summary>
        Exact,
        /// <summary>
        /// Containing text.
        /// </summary>
        Containing,
        /// <summary>
        /// Containing text (spaces ignored).
        /// </summary>
        Containing_Spaces_Ignored,
        /// <summary>
        /// Regular Expression.
        /// </summary>
        Regex
    }
}
