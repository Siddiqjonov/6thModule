﻿using CarSystem.Dal.Enums;

namespace CarSystem.Dal.Entities;

public class User
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Salt { get; set; }
    public UserRole Role { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; }

    public ICollection<Car> Cars { get; set; }
}
