﻿namespace Poc.Contract.Command.StatusCallbackURL.Request.DTO;

public class CreateStatusCallbackURLCancelDTO
{
    public string SmsMessageSid { get; set; } = String.Empty;
    public string NumMedia { get; set; } = String.Empty;
    public string ProfileName { get; set; } = String.Empty;
    public string MessageType { get; set; } = String.Empty;
    public string SmsSid { get; set; } = String.Empty;
    public string WaId { get; set; } = String.Empty;
    public string SmsStatus { get; set; } = String.Empty;
    public string Body { get; set; } = String.Empty;
    public string ButtonText { get; set; } = String.Empty;
    public string To { get; set; } = String.Empty;
    public string ButtonPayload { get; set; } = String.Empty;
    public string NumSegments { get; set; } = String.Empty;
    public string ReferralNumMedia { get; set; } = String.Empty;
    public string MessageSid { get; set; } = String.Empty;
    public string AccountSid { get; set; } = String.Empty;
    public string From { get; set; } = String.Empty;
    public string ApiVersion { get; set; } = String.Empty;
}
