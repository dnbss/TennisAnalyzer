using AngleSharp.Html.Dom;

namespace Parser
{
    public interface IParser
    {
        interface IParser<T> where T : class
        {
            T Parse(IHtmlDocument document);
        }
    }
}
