using MediatR;

namespace UrlShortener.Commands.AddNewShortLinkOrGetExisting
{
    public class Command : IRequest<Response>
    {
        private string _sourceUrl;

        public string SourceUrl
        {
            get => _sourceUrl;
            set
            {
                if (value != null && !value.StartsWith("http"))
                {
                    value = "http://" + value;
                }

                _sourceUrl = value;
            }
        }
    }
}