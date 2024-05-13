namespace SocialConnect.Core.Entities;

public class UserDetail
{
    public int Id { get; set; }

    public User User { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

}