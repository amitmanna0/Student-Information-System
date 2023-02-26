using System.Text.Json.Serialization;
namespace StudentInformation.Infrastructure
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AppRoles
    {
        Teacher = 1,
        Student = 2
    }
}
