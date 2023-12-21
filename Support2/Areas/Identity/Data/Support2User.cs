using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Support2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Support2User class
public class Support2User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

