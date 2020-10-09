using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using PRSLibrary.Models;

namespace PRSLibrary.Controllers {
    
    public class VendorsController {

        public PrsConnection PrsConnection { get; set; } = null;

        public VendorsController(PrsConnection prsconnection) {
            this.PrsConnection = prsconnection;
        }


        private void ParameterToVendorInstance(Vendor vendor, SqlCommand cmd) {            //Method used for duplicate code

            cmd.Parameters.AddWithValue("@Code", vendor.Code);
            cmd.Parameters.AddWithValue("@Name", vendor.Name);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            cmd.Parameters.AddWithValue("@City", vendor.City);
            cmd.Parameters.AddWithValue("@State", vendor.State);
            cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            cmd.Parameters.AddWithValue("@Phone", vendor.Email);
        }

        public int Insert(Vendor vendor) {
            var sql = "Insert Vendor (Code, Name, Address, City, State, Zip, Phone, Email)" +
                " Values (@Code, @Name, @Address, @City, @State, @Zip, @Phone, @Email);";

            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);

            ParameterToVendorInstance(vendor, cmd);

                            //cmd.Parameters.AddWithValue("@Code", vendor.Code);
                            //cmd.Parameters.AddWithValue("@Name", vendor.Name);
                            //cmd.Parameters.AddWithValue("@Address", vendor.Address);
                            //cmd.Parameters.AddWithValue("@City", vendor.City);
                            //cmd.Parameters.AddWithValue("@State", vendor.State);
                            //cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
                            //cmd.Parameters.AddWithValue("@Phone", vendor.Email);

            return cmd.ExecuteNonQuery();       //Should be =1 if data successfully inserted

        }



        public int Update(Vendor vendor) {
            var sql = "Update Vendors SET " +
                " Code = @Code," +
                " Name = @Name," +
                " Address = @Address," +
                " City = @City," +
                " State = @State," +
                " Zip = @Zip," +
                " Email = @Email," +
                " Where Id = @Id;";

            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);

            ParameterToVendorInstance(vendor, cmd);

                                //cmd.Parameters.AddWithValue("@Code", vendor.Code);
                                //cmd.Parameters.AddWithValue("@Name", vendor.Name);
                                //cmd.Parameters.AddWithValue("@Address", vendor.Address);
                                //cmd.Parameters.AddWithValue("@City", vendor.City);
                                //cmd.Parameters.AddWithValue("@State", vendor.Address);
                                //cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
                                //cmd.Parameters.AddWithValue("@Email", vendor.Email);

            cmd.Parameters.AddWithValue("@Id", vendor.Id);      //new line added with update




            return cmd.ExecuteNonQuery();
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






        private void DataReaderToVendorInstance(Vendor vendor, SqlDataReader reader) {            //Method used for duplicate code

            vendor.Id = Convert.ToInt32(reader["Id"]);
            vendor.Code = Convert.ToString(reader["Code"]);
            vendor.Name = Convert.ToString(reader["Name"]);
            vendor.Address = Convert.ToString(reader["Address"]);
            vendor.City = Convert.ToString(reader["City"]);
            vendor.State = Convert.ToString(reader["State"]);
            vendor.Zip = Convert.ToString(reader["Zip"]);
            vendor.Phone = Convert.ToString(reader["Phone"]);
            vendor.Email = Convert.ToString(reader["Email"]);
        }



        public List<Vendor> GetVendors() {
            var sql = "Select * from Vendors;";
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);

            var vendors = new List<Vendor>();

            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                var vendor = new Vendor();

                DataReaderToVendorInstance(vendor, reader);
                            //vendor.Id = Convert.ToInt32(reader["Id"]);
                            //vendor.Code = Convert.ToString(reader["Code"]);
                            //vendor.Name = Convert.ToString(reader["Name"]);
                            //vendor.Address = Convert.ToString(reader["Address"]);
                            //vendor.City = Convert.ToString(reader["City"]);
                            //vendor.State = Convert.ToString(reader["State"]);
                            //vendor.Zip = Convert.ToString(reader["Zip"]);
                            //vendor.Phone = Convert.ToString(reader["Phone"]);
                            //vendor.Email = Convert.ToString(reader["Email"]);

                vendors.Add(vendor);

            }

            reader.Close();
            return vendors;

        }

        public Vendor GetVendor(int Id) {
            var sql = "Select * from Vendors where Id = @Id;";
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", Id);

            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                return null;
            reader.Read();
            var vendor = new Vendor();

            DataReaderToVendorInstance(vendor, reader);
                            //vendor.Id = Convert.ToInt32(reader["Id"]);
                            //vendor.Code = Convert.ToString(reader["Code"]);
                            //vendor.Name = Convert.ToString(reader["Name"]);
                            //vendor.Address = Convert.ToString(reader["Address"]);
                            //vendor.City = Convert.ToString(reader["City"]);
                            //vendor.State = Convert.ToString(reader["State"]);
                            //vendor.Zip = Convert.ToString(reader["Zip"]);
                            //vendor.Phone = Convert.ToString(reader["Phone"]);
                            //vendor.Email = Convert.ToString(reader["Email"]);

            reader.Close();
            return vendor;
        }

        

    }
}