using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Snackis6.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Snackis6User class
public class Snackis6User : IdentityUser
{

    [PersonalData]
    public string FirstName { get; set; }
    [PersonalData]
    public string LastName { get; set; }

    public string DisplayName { get; set; }

    public string? ProfileImage { get; set; }
}

