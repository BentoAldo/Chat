using Microsoft.Extensions.Options;
using IMapper = AutoMapper.IMapper;
using static Chat.Web.Utils.ValidationUtils;

namespace Chat.Api.Endpoints.Message;

public class GetMessages : EndpointWithoutRequest<IEnumerable<GetMessagesResponse>>
{
    private readonly IMapper _mapper;
    private readonly IOptions<AppDefaults> _settings;
    private readonly IMessageServices _messageServices;

    public GetMessages(IMapper mapper, IOptions<AppDefaults> settings, IMessageServices messageServices)
    {
        _mapper = mapper;
        _settings = settings;
        _messageServices = messageServices;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var maxPageSize = _settings.Value.MaxPageSize;
        Response = _mapper.Map<IEnumerable<GetMessagesResponse>>(await _messageServices.GetMessages(maxPageSize));
        await SendAsync(Response, cancellation: ct);
    }

    public override void OnValidationFailed()
    {
        OnAfterValidation(ValidationFailed, ValidationFailures);
    }

    public override void Configure()
    {
        Get("v1/message");
        // Policies("GameSchedulerPolicy");
        AllowAnonymous();
        DontCatchExceptions();
        Summary(s =>
        {
            s.Summary = "Get all accounts";
            s.Description = "This endpoint is used to get all accounts with pagination";
        });
    }
}