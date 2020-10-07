using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using PRSLibrary.Models;

namespace PRSLibrary.Controllers {

    public class UsersController {

        public PrsConnection PrsConnection { get; set; } = null;       // public type,variable {} // an instance of our connection class

        public UsersController(PrsConnection prsconnection) {           //prsconnection is a property we're passing data into
            this.PrsConnection = prsconnection;                         // this. = only if the names are the same
        }



        private void ParameterToUserInstance(User user, SqlCommand cmd) {            //Method used for duplicate code
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
        }


        public int Update(User user) {
            var sql = "Update Users SET " +
                " Username = @Username," +
                " Password = @Password," +
                " FirstName = @FirstName," +
                " LastName = @LastName," +
                " PhoneNumber = @Phone," +
                " Email = @Email," +
                " IsReviewer = @IsReviewer," +
                " IsAdmin = @IsAdmin" +
                " Where Id = @Id;";

            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);

            ParameterToUserInstance(user, cmd);                             //method replaces commented out code

                    //cmd.Parameters.AddWithValue("@Username", user.Username);
                    //cmd.Parameters.AddWithValue("@Password", user.Password);
                    //cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    //cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    //cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    //cmd.Parameters.AddWithValue("@Email", user.Email);
                    //cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
                    //cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

            cmd.Parameters.AddWithValue("@Id", user.Id);        //line added with the update

            return cmd.ExecuteNonQuery();   //should be =1 row if data inserted
        }



        public int Insert(User user) {
            var sql = "Insert Users (Username, Password, FirstName, LastName, PhoneNumber, Email, IsReviewer, IsAdmin)" +
                    " Values (@Username, @Password, @FirstName, @LastName, @Phone, @Email, @IsReviewer, @IsAdmin);";
            
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);

            ParameterToUserInstance(user, cmd);                             //method replaces commented out code

                    //cmd.Parameters.AddWithValue("@Username", user.Username);
                    //cmd.Parameters.AddWithValue("@Password", user.Password);
                    //cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    //cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    //cmd.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                    //cmd.Parameters.AddWithValue("@Email", user.Email);
                    //cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
                    //cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

            return cmd.ExecuteNonQuery();   //should be =1 row if data inserted
        }


        private void DataReaderToUserInstance(User user, SqlDataReader reader) {            //Method used for duplicate code

            user.Id = Convert.ToInt32(reader["Id"]);
            user.Username = Convert.ToString(reader["Username"]);
            user.Password = Convert.ToString(reader["Password"]);
            user.FirstName = Convert.ToString(reader["FirstName"]);
            user.LastName = Convert.ToString(reader["LastName"]);
            user.Phone = Convert.ToString(reader["PhoneNumber"]);
            user.Email = Convert.ToString(reader["Email"]);
            user.IsReviewer = Convert.ToBoolean(reader["IsReviewer"]);
            user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
        }


        public User GetUser(int Id) {
            var sql = "Select * from Users where Id = @Id;";
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", Id);                     //Giving a parameter a value

            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)         // !=Not true
                return null;
            reader.Read();
            var user = new User();

            DataReaderToUserInstance(user, reader);             //method replaces commented out code
                    //user.Id = Convert.ToInt32(reader["Id"]);
                    //user.Username = Convert.ToString(reader["Username"]);
                    //user.Password = Convert.ToString(reader["Password"]);
                    //user.FirstName = Convert.ToString(reader["FirstName"]);
                    //user.LastName = Convert.ToString(reader["LastName"]);
                    //user.Phone = Convert.ToString(reader["PhoneNumber"]);
                    //user.Email = Convert.ToString(reader["Email"]);
                    //user.IsReviewer = Convert.ToBoolean(reader["IsReviewer"]);
                    //user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);

            reader.Close();
            return user; 

        }



        public List<User> GetUsers() {
            var sql = "Select * From Users;";
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);     //parameters = (string cmdtext, sqlconnection connection) 
                                                                            //using sqlConnection property from PrsConnection class
            var users = new List<User>();

            var reader = cmd.ExecuteReader();       //storing the sql data read as a variable

            while (reader.Read()) {
                var user = new User();

                DataReaderToUserInstance(user, reader);     //Method replaced commented out code
                        //user.Id = Convert.ToInt32(reader["Id"]);
                        //user.Username = Convert.ToString(reader["Username"]);
                        //user.Password = Convert.ToString(reader["Password"]);
                        //user.FirstName = Convert.ToString(reader["FirstName"]);
                        //user.LastName = Convert.ToString(reader["LastName"]);
                        //user.Phone = Convert.ToString(reader["PhoneNumber"]);
                        //user.Email = Convert.ToString(reader["Email"]);
                        //user.IsReviewer = Convert.ToBoolean(reader["IsReviewer"]);
                        //user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                users.Add(user);

            }
            
            reader.Close();
            return users;

        }





    }

}