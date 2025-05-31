using System;
using System.Collections.Generic;

public class UserCollection
{
    private DBHelper dbHelper = new DBHelper();
    private string tableName;

    public UserCollection(string tableName)
    {
        this.tableName = tableName;
    }

    public void AddUser(User user)
    {
        user.UserId = dbHelper.AddUser(user, tableName);
    }

    public void RemoveUser(int userId)
    {
        if (dbHelper.RemoveUser(userId, tableName))
        {
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public void UpdateUserInfo(User user)
    {
        dbHelper.UpdateUserInfo(user, tableName);
    }

    public User SearchUserById(int userId)
    {
        return dbHelper.SearchUserById(userId, tableName);
    }

    public List<User> GetAllUsers()
    {
        return dbHelper.GetAllUsers(tableName);
    }
}

public class InstructorCollection
{
    private DBHelperInstructor dbHelperInstructor = new DBHelperInstructor();
    private string tableName;

    public InstructorCollection(string tableName)
    {
        this.tableName = tableName;
    }

    // Add a new instructor
    public void AddInstructor(Instructor instructor)
    {
        instructor.InstructorId = dbHelperInstructor.AddInstructor(instructor, tableName).ToString();
    }

    // Remove an instructor by ID
    public void RemoveInstructor(string instructorId)
    {
        if (dbHelperInstructor.RemoveInstructor(instructorId, tableName))
        {
            Console.WriteLine("Instructor deleted successfully.");
        }
        else
        {
            Console.WriteLine("Instructor not found.");
        }
    }

    // Update an instructor's information
    public void UpdateInstructorInfo(Instructor instructor)
    {
        dbHelperInstructor.UpdateInstructorInfo(instructor, tableName);
    }

    // Search for an instructor by ID
    public Instructor SearchInstructorById(string instructorId)
    {
        return dbHelperInstructor.SearchInstructorById(instructorId, tableName);
    }

    // Get all instructors from the table
    public List<Instructor> GetAllInstructors()
    {
        return dbHelperInstructor.GetAllInstructors(tableName);
    }
}
public class InstrumentsCollection
{
    private DBHelperInstruments dbHelper = new DBHelperInstruments();

    // Add a new instrument to the collection
    public void AddInstrument(Instruments instrument)
    {
        instrument.InstrumentsID = dbHelper.AddInstrument(instrument);
    }

    // Remove an instrument by ID from the collection
    public bool RemoveInstrument(int instrumentsID)
    {
        // Call the DBHelper method to remove the instrument
        bool result = dbHelper.RemoveInstrument(instrumentsID);

        // Output a message based on the result
        if (result)
        {
            Console.WriteLine("Instrument deleted successfully.");
        }
        else
        {
            Console.WriteLine("Instrument not found.");
        }

        // Return the result to indicate success or failure
        return result;
    }


    // Update instrument information in the collection
    public void UpdateInstrumentInfo(Instruments instrument)
    {
        dbHelper.UpdateInstrumentInfo(instrument);
    }

    // Search for an instrument by ID in the collection
    public Instruments SearchInstrumentById(int instrumentsID)
    {
        return dbHelper.SearchInstrumentById(instrumentsID);
    }

    // Get all instruments in the collection
    public List<Instruments> GetAllInstruments()
    {
        return dbHelper.GetAllInstruments();
    }
}

public class AdminCollection
{
    private DBHelperAdmin dbHelper = new DBHelperAdmin();

    public void AddAdmin(Admin admin)
    {
        admin.AdminId = dbHelper.AddAdmin(admin);
    }

    public void RemoveAdmin(string adminId)
    {
        if (dbHelper.RemoveAdmin(adminId))
        {
            Console.WriteLine("Admin deleted successfully.");
        }
        else
        {
            Console.WriteLine("Admin not found.");
        }
    }

    public void UpdateAdminInfo(Admin admin)
    {
        dbHelper.UpdateAdminInfo(admin);
    }

    public Admin SearchAdminById(string adminId)
    {
        return dbHelper.SearchAdminById(adminId);
    }

    public List<Admin> GetAllAdmins()
    {
        return dbHelper.GetAllAdmins();
    }
}