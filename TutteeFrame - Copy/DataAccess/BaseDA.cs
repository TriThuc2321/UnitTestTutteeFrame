using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TutteeFrame.DataAccess
{
    public class BaseDA
    {

        #region Variables
        protected static string connectionString = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";

        protected SqlConnection connection;
        protected string strQuery;
        #endregion

        public enum ConnectionType { Server, Local };
        #region Server Function
        /// <summary>
        /// Hàm thực hiện kết nối ban đầu, nếu thành công sẽ lưu lại chuỗi kết nối.
        /// </summary>
        /// <param name="_server"></param>
        /// <param name="_port"></param>
        /// <param name="_userid"></param>
        /// <param name="_pass"></param>
        /// <returns> Việc kết nối đến server lúc đầu có thành công hay không. </returns>
        public bool CreateConnect(string _server, string _port, string _userid, string _pass)
        {
            bool success = true;
            string strConnect = string.Format(Properties.Settings.Default.ServerConnectionString,
                   _server, _port, _userid, _pass);
            try
            {
                connection = new SqlConnection(strConnect);
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
            connectionString = strConnect;
            return success;
        }

        public bool CreateLocalConnect()
        {
            bool success = true;

            string strConnect = Properties.Settings.Default.LocalConnectionString;
            try
            {
                connection = new SqlConnection(strConnect);
                connection.Open();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
            connectionString = strConnect;
            return success;
        }
        /// <summary>
        /// Hàm mở kết nối đến server.
        /// </summary>
        /// <returns> Thực hiện kết nối thành công hay không. </returns>
        protected bool Connect()
        {
            bool success = true;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                success = false;
            }

            return success;
        }
        /// <summary>
        /// Ngắt kết nối server.
        /// </summary>
        protected void Disconnect()
        {
            if (connection != null)
                connection.Close();
        }
        #endregion
        #region For ID Creation
        /// <summary>
        /// Lấy ID của học sinh cuối cùng, nếu không có học sinh trả về [năm hiện tại] * 10000 + 2000
        /// </summary>
        /// <param name="_lastStudentID"> ID được lấy ra</param>
        /// <returns></returns>
        public bool GetLastStudentID(ref int _lastStudentID)
        {
            bool success = Connect();

            if (!success)
                return false;
            try
            {
                strQuery = "SELECT COUNT(*) FROM STUDENT";
                SqlCommand sqlCommand = new SqlCommand(strQuery, connection);
                if ((int)sqlCommand.ExecuteScalar() <= 0)
                {
                    _lastStudentID = Int32.Parse(DateTime.Now.Year.ToString() + "0000");
                    return true;
                }
                strQuery = "SELECT TOP 1 StudentID FROM STUDENT ORDER BY StudentID DESC";
                sqlCommand = new SqlCommand(strQuery, connection);
                _lastStudentID = Int32.Parse((string)sqlCommand.ExecuteScalar());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
            return true;
        }
        /// <summary>
        /// Trả về năm hiện tại của server.
        /// </summary>
        /// <param name="_serverYear"> Giá trị trả về.</param>
        /// <returns></returns>
        public bool GetServerYear(ref int _serverYear)
        {
            bool success = Connect();

            if (!success)
                return false;
            try
            {
                //code go heree
                //..

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                Disconnect();
            }
            return true;
        }
        #endregion



    }
}
