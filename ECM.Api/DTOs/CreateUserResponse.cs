using System.Text.Json.Serialization;

namespace ECM.Api.DTOs;

public class CreateUserResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}