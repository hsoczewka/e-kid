namespace Ekid.Infrastructure.Primitives;

public record Address(string CountryCode, string StateCode, string City, string PostalCode, string AddressLine1, string AddressLine2);