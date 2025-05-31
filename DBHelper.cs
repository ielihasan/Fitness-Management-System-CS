using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
public class DBHelper
{
    private string connString = "Data Source=ELITEBOOK\\SQLEXPRESS;Initial Catalog=fitnessData;Integrated Security=True";

    // Add a new user to a specified table
    public int AddUser(User user, string tableName)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlInsert = $"INSERT INTO {tableName} (userID, userName, password, completedDays, membershipType, feePaid, email, phone) " +
                               "OUTPUT INSERTED.userID VALUES (@userID, @userName, @password, @completedDays, @membershipType, @feePaid, @Email, @Phone)";
            using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
            {
                // Add parameters for all fields, including the User ID
                cmd.Parameters.AddWithValue("@userID", user.UserId); // Assuming UserId is passed from the form
                cmd.Parameters.AddWithValue("@userName", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@completedDays", user.CompletedDays);
                cmd.Parameters.AddWithValue("@membershipType", user.MembershipType);
                cmd.Parameters.AddWithValue("@feePaid", user.FeePaid);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);

                conn.Open();
                // Execute the insert command and retrieve the inserted UserID
                int insertedUserId = (int)cmd.ExecuteScalar();  // Executes the query and returns the inserted UserId
                Console.WriteLine("User added successfully. UserID: " + insertedUserId);
                conn.Close();
                return insertedUserId; // Return the newly inserted UserId
            }
        }
    }


    // Remove a user by ID from a specified table
    public bool RemoveUser(int userId, string tableName)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlDelete = $"DELETE FROM {tableName} WHERE userID = @userID";
            using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
            {
                cmd.Parameters.AddWithValue("@userID", userId);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Update user information in a specified table
    public void UpdateUserInfo(User user, string tableName)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlUpdate = $"UPDATE {tableName} SET userName = @userName, password = @password, completedDays = @completedDays, " +
                               "membershipType = @membershipType, feePaid = @feePaid, email = @Email, phone = @Phone WHERE userID = @userID";
            using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            {
                cmd.Parameters.AddWithValue("@userName", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@completedDays", user.CompletedDays);
                cmd.Parameters.AddWithValue("@membershipType", user.MembershipType);
                cmd.Parameters.AddWithValue("@feePaid", user.FeePaid); // Updated column reference
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@userID", user.UserId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "User updated successfully." : "User not found.");
            }
        }
    }

    // Search for a user by ID in a specified table
    public User SearchUserById(int userId, string tableName)
    {
        User user = null;

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = $"SELECT * FROM {tableName} WHERE userID = @userID";
            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                cmd.Parameters.AddWithValue("@userID", userId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserId = (int)reader["userID"],
                            Username = (string)reader["userName"],
                            Password = (string)reader["password"],
                            CompletedDays = (int)reader["completedDays"],
                            MembershipType = (string)reader["membershipType"],
                            FeePaid = (string)reader["feePaid"], // Updated column reference
                            Email = reader["email"] as string,
                            Phone = reader["phone"] as string
                        };
                    }
                }
            }
        }

        return user;
    }

    // Get all users from a specified table
    public List<User> GetAllUsers(string tableName)
    {
        List<User> users = new List<User>();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = $"SELECT * FROM {tableName}";
            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = (int)reader["userID"],
                            Username = (string)reader["userName"],
                            Password = (string)reader["password"],
                            CompletedDays = (int)reader["completedDays"],
                            MembershipType = (string)reader["membershipType"],
                            FeePaid = (string)reader["feePaid"], // Updated column reference
                            Email = reader["email"] as string,
                            Phone = reader["phone"] as string
                        });
                    }
                }
            }
        }

        return users;
    }
}


public class DBHelperInstructor
{
    private string connString = "Data Source=ELITEBOOK\\SQLEXPRESS;Initial Catalog=fitnessData;Integrated Security=True";
    // Add a new instructor to the database
    public int AddInstructor(Instructor instructor, string tableName)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlInsert = $"INSERT INTO {tableName} (InstructorId, Name, Specialization) " +
                               "OUTPUT INSERTED.InstructorId VALUES (@InstructorId, @Name, @Specialization)";
            using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
            {
                cmd.Parameters.AddWithValue("@InstructorId", instructor.InstructorId);
                cmd.Parameters.AddWithValue("@Name", instructor.Name);
                cmd.Parameters.AddWithValue("@Specialization", instructor.Specialization);

                conn.Open();
                string insertedId = (string)cmd.ExecuteScalar();
                Console.WriteLine("Instructor added successfully. Instructor ID: " + insertedId);
                conn.Close();
                return int.Parse(insertedId);
            }
        }
    }

    // Remove an instructor by ID from the database
    public bool RemoveInstructor(string instructorId, string tableName)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlDelete = $"DELETE FROM {tableName} WHERE InstructorId = @InstructorId";
            using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
            {
                cmd.Parameters.AddWithValue("@InstructorId", instructorId);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected > 0;
            }
        }
    }

    // Update instructor information in the database
    public void UpdateInstructorInfo(Instructor instructor, string tableName)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlUpdate = $"UPDATE {tableName} SET Name = @Name, Specialization = @Specialization WHERE InstructorId = @InstructorId";
            using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            {
                cmd.Parameters.AddWithValue("@Name", instructor.Name);
                cmd.Parameters.AddWithValue("@Specialization", instructor.Specialization);
                cmd.Parameters.AddWithValue("@InstructorId", instructor.InstructorId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "Instructor updated successfully." : "Instructor not found.");
                conn.Close();
            }
        }
    }

    // Search for an instructor by ID
    public Instructor SearchInstructorById(string instructorId, string tableName)
    {
        Instructor instructor = null;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = $"SELECT * FROM {tableName} WHERE InstructorId = @InstructorId";
            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                cmd.Parameters.AddWithValue("@InstructorId", instructorId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        instructor = new Instructor
                        {
                            InstructorId = (string)reader["InstructorId"],
                            Name = (string)reader["Name"],
                            Specialization = (string)reader["Specialization"]
                        };
                    }
                }
                conn.Close();
            }
        }
        return instructor;
    }

    // Get all instructors from the database
    public List<Instructor> GetAllInstructors(string tableName)
    {
        List<Instructor> instructors = new List<Instructor>();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = $"SELECT * FROM {tableName}";
            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        instructors.Add(new Instructor
                        {
                            InstructorId = (string)reader["InstructorId"],
                            Name = (string)reader["Name"],
                            Specialization = (string)reader["Specialization"]
                        });
                    }
                }
                conn.Close();
            }
        }
        return instructors;
    }
}

public class DBHelperInstruments
{
    private string connString = "Data Source=ELITEBOOK\\SQLEXPRESS;Initial Catalog=fitnessData;Integrated Security=True";

    // Add a new instrument to the database
    public int AddInstrument(Instruments instrument)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlInsert = "INSERT INTO Instruments (InstrumentsName, InstrumentsPrice, InstrumentsBarcode, InstrumentsType) " +
                               "OUTPUT INSERTED.InstrumentsID VALUES (@InstrumentsName, @InstrumentsPrice, @InstrumentsBarcode, @InstrumentsType)";

            using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
            {
                cmd.Parameters.AddWithValue("@InstrumentsName", instrument.InstrumentsName);
                cmd.Parameters.AddWithValue("@InstrumentsPrice", instrument.InstrumentsPrice);
                cmd.Parameters.AddWithValue("@InstrumentsBarcode", instrument.InstrumentsBarcode);
                cmd.Parameters.AddWithValue("@InstrumentsType", instrument.InstrumentsType);

                conn.Open();
                int instrumentId = (int)cmd.ExecuteScalar();
                Console.WriteLine("Instrument added successfully. InstrumentID: " + instrumentId);
                conn.Close();
                return instrumentId; // Return the newly created InstrumentsID
            }
        }
    }

    // Update instrument information in the database
    public void UpdateInstrumentInfo(Instruments instrument)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlUpdate = "UPDATE Instruments SET InstrumentsName = @InstrumentsName, InstrumentsPrice = @InstrumentsPrice, " +
                               "InstrumentsBarcode = @InstrumentsBarcode, InstrumentsType = @InstrumentsType WHERE InstrumentsID = @InstrumentsID";

            using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            {
                cmd.Parameters.AddWithValue("@InstrumentsName", instrument.InstrumentsName);
                cmd.Parameters.AddWithValue("@InstrumentsPrice", instrument.InstrumentsPrice);
                cmd.Parameters.AddWithValue("@InstrumentsBarcode", instrument.InstrumentsBarcode);
                cmd.Parameters.AddWithValue("@InstrumentsType", instrument.InstrumentsType);
                cmd.Parameters.AddWithValue("@InstrumentsID", instrument.InstrumentsID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "Instrument updated successfully." : "Instrument not found.");
            }
        }
    }

    // Remove an instrument by ID from the database
    public bool RemoveInstrument(int instrumentsID)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlDelete = "DELETE FROM Instruments WHERE InstrumentsID = @InstrumentsID";

            using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
            {
                cmd.Parameters.AddWithValue("@InstrumentsID", instrumentsID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Search for an instrument by ID
    public Instruments SearchInstrumentById(int instrumentsID)
    {
        Instruments instrument = null;

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = "SELECT * FROM Instruments WHERE InstrumentsID = @InstrumentsID";

            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                cmd.Parameters.AddWithValue("@InstrumentsID", instrumentsID);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        instrument = new Instruments
                        {
                            InstrumentsID = (int)reader["InstrumentsID"],
                            InstrumentsName = (string)reader["InstrumentsName"],
                            InstrumentsPrice = (string)reader["InstrumentsPrice"],
                            InstrumentsBarcode = (string)reader["InstrumentsBarcode"],
                            InstrumentsType = (int)reader["InstrumentsType"]
                        };
                    }
                }
            }
        }

        return instrument;
    }

    // Get all instruments from the database
    public List<Instruments> GetAllInstruments()
    {
        List<Instruments> instruments = new List<Instruments>();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = "SELECT * FROM Instruments";

            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        instruments.Add(new Instruments
                        {
                            InstrumentsID = (int)reader["InstrumentsID"],
                            InstrumentsName = (string)reader["InstrumentsName"],
                            InstrumentsPrice = (string)reader["InstrumentsPrice"],
                            InstrumentsBarcode = (string)reader["InstrumentsBarcode"],
                            InstrumentsType = (int)reader["InstrumentsType"]
                        });
                    }
                }
            }
        }

        return instruments;
    }
}

public class DBHelperAdmin
{
    private string connString = "Data Source=ELITEBOOK\\SQLEXPRESS;Initial Catalog=fitnessData;Integrated Security=True";

    // Add a new admin to the Admins table
    public string AddAdmin(Admin admin)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlInsert = "INSERT INTO Admins (AdminId, Username, Password) " +
                               "OUTPUT INSERTED.AdminId VALUES (@AdminId, @Username, @Password)";
            using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
            {
                cmd.Parameters.AddWithValue("@AdminId", admin.AdminId);
                cmd.Parameters.AddWithValue("@Username", admin.Username);
                cmd.Parameters.AddWithValue("@Password", admin.Password);

                conn.Open();
                string insertedId = (string)cmd.ExecuteScalar();
                Console.WriteLine("Admin added successfully. AdminID: " + insertedId);
                conn.Close();
                return insertedId;
            }
        }
    }

    // Remove an admin by ID from the Admins table
    public bool RemoveAdmin(string adminId)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlDelete = "DELETE FROM Admins WHERE AdminId = @AdminId";
            using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
            {
                cmd.Parameters.AddWithValue("@AdminId", adminId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Update admin information in the Admins table
    public void UpdateAdminInfo(Admin admin)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlUpdate = "UPDATE Admins SET Username = @Username, Password = @Password WHERE AdminId = @AdminId";
            using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            {
                cmd.Parameters.AddWithValue("@Username", admin.Username);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@AdminId", admin.AdminId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "Admin updated successfully." : "Admin not found.");
            }
        }
    }

    // Search for an admin by ID in the Admins table
    public Admin SearchAdminById(string adminId)
    {
        Admin admin = null;

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = "SELECT * FROM Admins WHERE AdminId = @AdminId";
            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                cmd.Parameters.AddWithValue("@AdminId", adminId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        admin = new Admin
                        {
                            AdminId = (string)reader["AdminId"],
                            Username = (string)reader["Username"],
                            Password = (string)reader["Password"]
                        };
                    }
                }
            }
        }

        return admin;
    }

    // Get all admins from the Admins table
    public List<Admin> GetAllAdmins()
    {
        List<Admin> admins = new List<Admin>();

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sqlSelect = "SELECT * FROM Admins";
            using (SqlCommand cmd = new SqlCommand(sqlSelect, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admins.Add(new Admin
                        {
                            AdminId = (string)reader["AdminId"],
                            Username = (string)reader["Username"],
                            Password = (string)reader["Password"]
                        });
                    }
                }
            }
        }

        return admins;
    }
}
