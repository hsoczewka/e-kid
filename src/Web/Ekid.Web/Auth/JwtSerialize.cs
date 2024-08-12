using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Ekid.Web.Auth;

public class JwtSerialize
{
    public static ClaimsPrincipal Deserialize(string jwtToken)
    {
        var segments = jwtToken.Split('.');

        if (segments.Length != 3)
        {
            throw new Exception("Invalid JWT");
        }

        Console.WriteLine(segments[1]);
        var dataSegment = Encoding.UTF8.GetString(FromUrlBase64(segments[1]));
        var data = JsonSerializer.Deserialize<JsonObject>(dataSegment);

        var claims = new Claim[data.Count];
        int index = 0;
        foreach (var entry in data)
        {
            claims[index] = JwtNodeToClaim(entry.Key, entry.Value);
            index++;
        }

        var claimIdentity = new ClaimsIdentity(claims, "jwt");
        var principal = new ClaimsPrincipal(new[] { claimIdentity });

        return principal;
    }

    private static Claim JwtNodeToClaim(string key, JsonNode node)
    {
        var jsonValue = node.AsValue();

        if (jsonValue.TryGetValue<string>(out var str))
        {
            return new Claim(key, str, ClaimValueTypes.String);
        }
        else if (jsonValue.TryGetValue<double>(out var num))
        {
            return new Claim(key, num.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Double);
        }
        else
        {
            throw new Exception("Unsupported JWT claim type");
        }
    }

    private static byte[] FromUrlBase64(string jwtSegment)
    {
        string fixedBase64 = jwtSegment
            .Replace('-', '+')
            .Replace('_', '/');

        switch (jwtSegment.Length % 4)
        {
            case 2: fixedBase64 += "=="; break;
            case 3: fixedBase64 += "="; break;
            default: throw new Exception("Illegal base64url string!");
        }

        return Convert.FromBase64String(fixedBase64);
    }
}