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
        /// Spaces ignored.
        /// </summary>
        Spaces_Ignored,
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
        Regex,
        /// <summary>
        /// Regular Expression (spaces ignored).
        /// </summary>
        Regex_Spaces_Ignored
    }
}
