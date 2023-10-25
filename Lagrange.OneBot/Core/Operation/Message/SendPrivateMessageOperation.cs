using System.Text.Json;
using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.OneBot.Core.Entity.Action;
using Lagrange.OneBot.Core.Entity.Action.Response;

namespace Lagrange.OneBot.Core.Operation.Message;

[Operation("send_private_msg")]
public sealed class SendPrivateMessageOperation : IOperation
{
    public async Task<OneBotResult> HandleOperation(string echo, BotContext context, JsonObject? payload)
    {
        if (payload.Deserialize<OneBotPrivateMessage>() is { } message)
        {
            await context.SendMessage(MessageCommon.ParseChain(message).Build());
            return new OneBotResult(new OneBotMessageResponse(0), 0, "ok", echo);
        }

        throw new Exception();
    }
}