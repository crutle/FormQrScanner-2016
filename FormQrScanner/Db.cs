using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormQrScanner
{
    class Db
    {
        private static string dbString = "Data Source=DIT-NB1431533\\SQLEXPRESS; database=FYP_MarkIn_Db; integrated security=true";

        public static bool attendance(int inEventId, int inUserId)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    int numOfRecordsAffected = 0;

                    try
                    {
                        cn.ConnectionString = dbString;
                        cmd.Connection = cn;
                        cmd.CommandText = "UPDATE ParticipantAttendance SET Present=1 WHERE EventId = @inEventId AND ParticipantId = @inUserId";

                        cmd.Parameters.Add("@inEventId", System.Data.SqlDbType.Int).Value = inEventId;
                        cmd.Parameters.Add("@inUserId", System.Data.SqlDbType.Int).Value = inUserId;

                        cn.Open();
                        
                        numOfRecordsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new System.ArgumentException(sqlEx.Message);
                    }

                    cn.Close();

                    if (numOfRecordsAffected == 0)
                    {
                        return false;

                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }


    }
}
