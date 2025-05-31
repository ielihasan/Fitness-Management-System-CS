using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


public class User
{
    public int UserId { get; set; } // Primary Key
    public string Username { get; set; }
    public string Password { get; set; }
    public int CompletedDays { get; set; } = 0; // Default value 0
    public string MembershipType { get; set; }
    public string FeePaid { get; set; } // Changed from FitnessLevel to FeePaid
    public string Email { get; set; }
    public string Phone { get; set; }
}


public class Admin
{
    public string AdminId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

// Instructor Class
public class Instructor
{
    public string InstructorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
}

// Instrument Class
public class Instruments
{
    public int InstrumentsID { get; set; }
    public string InstrumentsName { get; set; }
    public string InstrumentsPrice { get; set; } // e.g., Running, Weightlifting
    public string InstrumentsBarcode { get; set; }
    public int InstrumentsType { get; set; } // in minutes
}

