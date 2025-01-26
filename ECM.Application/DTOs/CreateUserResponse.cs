using System.Text.Json.Serialization;

namespace ECM.Application.DTOs;

public class CreateUserResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}