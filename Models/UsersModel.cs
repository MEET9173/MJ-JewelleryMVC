using System.ComponentModel;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace MJ_JewelleryMVC.Models
{
    
    public class UsersModel
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocaldb;Initial Catalog=MJ-JewelleryDB;Integrated Security=True");
        public class Register
        {
            [Key]
            public int userID { get; set; }

            [Required(ErrorMessage = "Please enter your Username")]
            public string userName { get; set; }

            [Required(ErrorMessage = "Please enter your password")]
            [PasswordPropertyText]
            [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "Password length must be contains minimum 8 character")]
            public string password { get; set; }

            [Required(ErrorMessage = "Please enter your email")]
            [EmailAddress(ErrorMessage = "Email address is not valid")]
            public string email { get; set; }

            [ScaffoldColumn(true)]
            public int? isActive { get; set; }
        }
        public class signin
        {
            [Required(ErrorMessage = "Please enter your password")]
            [PasswordPropertyText]
            [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "Password length must be contains minimum 8 character")]
            public string password { get; set; }

            [Required(ErrorMessage = "Please enter your email")]
            [EmailAddress(ErrorMessage = "Email address is not valid")]
            public string email { get; set; }
        }

        public bool login(UsersModel.signin users)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select email,password from Users where email=@email and password=@password", con);
            cmd.Parameters.AddWithValue("@email", users.email);
            cmd.Parameters.AddWithValue("@password", users.password);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            //int i=cmd.ExecuteNonQuery();
            if (dr.HasRows)
            {
                return true;
            }
            return false;

        }

        public bool register(UsersModel.Register users)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Users(userName,password,email) values(@userName,@password,@email)",con);
            cmd.Parameters.AddWithValue("@userName", users.userName);
            cmd.Parameters.AddWithValue("@email", users.email);
            cmd.Parameters.AddWithValue("@password", users.password);
            
           

            int i=cmd.ExecuteNonQuery();
            if (i>=1)
            {
                return true;
            }
            return false;
        }
    }
}
