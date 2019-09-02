using EPiServer.Core;

namespace NewEpiserver.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
