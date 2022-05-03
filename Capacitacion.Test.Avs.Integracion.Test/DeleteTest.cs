using Capacitacion.Test.Avs.Business.Entities;
using Capacitacion.Test.Avs.Business.Services;
using Capacitacion.Test.Avs.Infraesctuture.Data;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Capacitacion.Test.Avs.Integracion.Test
{

    /// <summary>
    /// Yo como usuario quiero eliminar un usuario porque ya no va a ser parte de mi lista de usuarios actual
    /// </summary>
    public class DeleteTests
    {
        /// <summary>
        /// Si hay usuarios en el sistema, eliminar el usuario indicado por su Id
        /// </summary>
        [Test]
        public void Delete_UserId()
        {
            User UsersResult = new User
            {
                TypeDocument = 11,
                DocumentNumber = 12345,
                Name = "Maha",
                LastName = "Amariles"
            };

            string connectionString = "Data Source=DESKTOP-19TGFI2;Database=homework;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            string commandText1 = $"INSERT INTO USUARIOS VALUES({UsersResult.TypeDocument}, {UsersResult.DocumentNumber}, '{UsersResult.Name}','{UsersResult.LastName}')";
            using (SqlCommand cmd = new SqlCommand(commandText1, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            string getId = "SELECT TOP(1) id FROM USUARIOS ORDER BY id DESC";
            int id = 0;
            using (SqlCommand cmd = new SqlCommand(getId, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    id = reader.GetInt32(0);
                conn.Close();
            }

            IServicesUser servicesUser = new ServiceUser(new UserData());
            servicesUser.Delete(id);

            User Verification = servicesUser.GetUserById(id);
            Assert.IsNull(Verification);
        }

    }
}