using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutteeFrame.Model;

namespace Student_Unit_Test

{
    [TestClass]
    public class AddTeacherUnitTest
    {


        public bool AddTeacher(Teacher _teacher)
        {
            string a = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(a);
            try
            {
                int is_admin = 0;
                int is_ministry = 0;

                switch (_teacher.Type)
                {
                    case Teacher.TeacherType.Teacher:
                        {
                            break;
                        }
                    case Teacher.TeacherType.Adminstrator:
                        {
                            is_admin = 1;
                            break;
                        }
                    case Teacher.TeacherType.Ministry:
                        {
                            is_ministry = 1;
                            break;
                        }
                }
                string query = "INSERT INTO TEACHER(TeacherID,Surname,FirstName,TeacherImage,DateBorn,Sex,Address,Phone,Maill,SubjectID,IsMinistry,IsAdmin,Posittion) " +
                    "VALUES(@teacherid,@surname,@firstname,'',@date,@sex,@address,@phone,@mail,@subjectid,@is_ministry,@is_admin,@position)";

                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@teacherid", _teacher.ID);
                    sqlCommand.Parameters.AddWithValue("@surname", _teacher.SurName);
                    sqlCommand.Parameters.AddWithValue("@date", _teacher.DateBorn);
                    sqlCommand.Parameters.AddWithValue("@sex", _teacher.Sex);
                    sqlCommand.Parameters.AddWithValue("@firstname", _teacher.FirstName);
                    sqlCommand.Parameters.AddWithValue("@phone", _teacher.Phone);

                    sqlCommand.Parameters.AddWithValue("@address", _teacher.Address);
                    sqlCommand.Parameters.AddWithValue("@mail", _teacher.Mail);
                    sqlCommand.Parameters.AddWithValue("@subjectid", _teacher.Subject.ID);
                    sqlCommand.Parameters.AddWithValue("@is_ministry", is_ministry);
                    sqlCommand.Parameters.AddWithValue("@is_admin", is_admin);
                    sqlCommand.Parameters.AddWithValue("@position", _teacher.Position);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    

        [TestMethod]
        public void UTCID02()
        {
            TutteeFrame.Model.Subject subject = new TutteeFrame.Model.Subject();
            subject.ID = "01";
            subject.Name = "Toán";
            TutteeFrame.Model.Teacher teacher = new TutteeFrame.Model.Teacher();

            teacher.DateBorn = new DateTime(2008, 3, 1, 0, 0, 0);
            teacher.FirstName = "Tran";
            teacher.SurName = "Thuccc";
            teacher.Address = "Soc Trang";
            teacher.Type = Teacher.TeacherType.Teacher;
            teacher.Phone = "0123456789";
            teacher.Sex = true;
            teacher.Subject = subject;
            teacher.ID = "TC111543";
            teacher.Position = "Không";
            teacher.Mail = "19522321@gm.uit.edu.vn";
            teacher.FormClassID = "10A1";
            var result = AddTeacher(teacher);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void UTCID01()
        {
            TutteeFrame.Model.Subject subject = new TutteeFrame.Model.Subject();
            subject.ID = "01";
            subject.Name = "Toán";
            TutteeFrame.Model.Teacher teacher = new TutteeFrame.Model.Teacher();

            teacher.DateBorn = new DateTime(2008, 3, 1, 0, 0, 0);
            //teacher.FirstName = "Tran";
            //teacher.SurName = "Thucc";
            teacher.Address = "Soc Trang";
            teacher.Type = Teacher.TeacherType.Teacher;
            teacher.Phone = "0123456789";
            teacher.Sex = true;
            teacher.Subject = subject;
            teacher.ID = "TC114253";
            teacher.Position = "Không";
            teacher.Mail = "19522321@gm.uit.edu.vn";
            teacher.FormClassID = "10A1";
            var result = AddTeacher(teacher);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UTCID03()
        {
            TutteeFrame.Model.Subject subject = new TutteeFrame.Model.Subject();
            subject.ID = "01";
            subject.Name = "Toán";
            TutteeFrame.Model.Teacher teacher = new TutteeFrame.Model.Teacher();

            teacher.DateBorn = new DateTime(2008, 3, 1, 0, 0, 0);
            teacher.FirstName = "Tran";
            teacher.SurName = "Thucc";
            teacher.Address = "Soc Trang";
            teacher.Type = Teacher.TeacherType.Teacher;
            teacher.Phone = "01";
            teacher.Sex = true;
            teacher.Subject = subject;
            teacher.ID = "TC114267";
            teacher.Position = "Không";
            teacher.Mail = "19522321@gm.uit.edu.vn";
            teacher.FormClassID = "10A1";
            var result = AddTeacher(teacher);
            Assert.AreEqual(false, result);
        }
    }
    [TestClass]
    public class UpdateTeacherUnitTest
    {
        public bool UpdateTeacher(string _teacherID, string _columnName, object _value)
        {
            string a = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(a);
            connection.Open();
            try
            {
                string query = "UPDATE TEACHER SET " + _columnName + " = @value WHERE TeacherID = @teacherid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value", _value);
                    command.Parameters.AddWithValue("@teacherid", _teacherID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {

            }
            return true;
        }
        [TestMethod]
        public void UTCID01()
        {
            int count = 0;
            var result = UpdateTeacher("TC658245", "Surname", "");
            if (result == true) count++;
            result = UpdateTeacher("TC658245", "Firstname", "");
            if (result == true) count++;
            result = UpdateTeacher("TC658245", "Sex", "True");
            if (result == true) count++;
            Assert.AreEqual(3, count);
        }
        [TestMethod]
        public void UTCID02()
        {
            int count = 0;
            var result = UpdateTeacher("TC735555", "Surname", "Hoàng");
            if (result == true) count++;
            result = UpdateTeacher("TC735555", "FirstName", "Anh");
            if (result == true) count++;
            result = UpdateTeacher("TC735555", "Address", "12 đường số 1");
            if (result == true) count++;
            result = UpdateTeacher("TC735555", "Phone", "092818234");
            if (result == true) count++;
            result = UpdateTeacher("TC735555", "Maill", "vietthanhemail@gmail.com");
            if (result == true) count++;
            result = UpdateTeacher("TC735555", "SubjectID", "02");
            if (result == true) count++;
            Assert.AreEqual(6, count);
        }
    }

    [TestClass]
    public class DeleteTeacherUnitTest
    {
        public bool DeleteTeacher(string _teacherID)
        {
            string a = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(a);
            connection.Open();
            string strQuery;
            try
            {
                strQuery = $"UPDATE TEACHING SET TEACHING.TeacherID = NULL WHERE TEACHING.TeacherID = '{_teacherID}'";
                using (SqlCommand command = new SqlCommand(strQuery, connection))
                    command.ExecuteNonQuery();
                strQuery = $"UPDATE CLASS SET CLASS.TeacherID = NULL WHERE CLASS.TeacherID = '{_teacherID}'";
                using (SqlCommand command = new SqlCommand(strQuery, connection))
                    command.ExecuteNonQuery();
                strQuery = $"DELETE TEACHER WHERE TeacherID = '{_teacherID}'";
                using (SqlCommand command = new SqlCommand(strQuery, connection))
                    command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        [TestMethod]
        public void UTCID01()
        {
            var result = DeleteTeacher("TC111543");
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class AddClassUnitTest
    {
        public bool AddClass(Class _class)
        {
            string a = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(a);
            connection.Open();
            try
            {
                string query = "INSERT INTO CLASS(ClassID,RoomNum,StudentNum,TeacherID) VALUES (@classid,@classroom,@studentnum,@teacherid)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@classid", _class.ID);
                command.Parameters.AddWithValue("@classroom", _class.Room);
                command.Parameters.AddWithValue("@studentnum", _class.StudentNum);
                command.Parameters.AddWithValue("@teacherid", DBNull.Value);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        [TestMethod]
        public void UTCID01()
        {
            TutteeFrame.Model.Class classs = new TutteeFrame.Model.Class();
            classs.ID = "12A6";
            classs.Room = "A01";
            classs.StudentNum = 30;
            classs.FormerTeacherID = "TC720830";
            var result = AddClass(classs);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void UTCID02()
        {
            TutteeFrame.Model.Class classs = new TutteeFrame.Model.Class();
            classs.ID = "12A10";
            classs.Room = "A03";
            classs.StudentNum = 30;
            classs.FormerTeacherID = "TC973134";
            var result = AddClass(classs);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void UTCID03()
        {
            TutteeFrame.Model.Class classs = new TutteeFrame.Model.Class();

            classs.Room = "A03";
            classs.StudentNum = 30;
            classs.FormerTeacherID = "TC720830";
            var result = AddClass(classs);
            Assert.AreEqual(false, result);
        }
    }
    [TestClass]
    public class DeleteClassUnitTest
    {
        public bool DeletedClass(string classId)
        {
            string a = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(a);
            connection.Open();
            string strQuery;
            try
            {
                strQuery = "DELETE  FROM CLASS WHERE ClassID = @classId";
                SqlCommand cmd = new SqlCommand(strQuery, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Parameters.Add("@classId", System.Data.SqlDbType.VarChar).Value = classId;
                cmd.ExecuteNonQuery();
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        [TestMethod]
        public void UTCID01()
        {
            var result = DeletedClass("12A6");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void UTCID02()
        {
            var result = DeletedClass("10A1");
            Assert.AreEqual(false, result);
        }
    }
    [TestClass]
    public class UpdateClassUnitTest
    {
        public bool UpdateClassInfor(string classID, string romNum)
        {
            string a = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(a);
            connection.Open();
            string strQuery;
            try
            {
                strQuery = "UPDATE CLASS SET RoomNum = @romNum WHERE ClassID = @classID";
                using (SqlCommand cmd = new SqlCommand(strQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@romNum", romNum);
                    cmd.Parameters.AddWithValue("@classID", classID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        [TestMethod]
        public void UTCID01()
        {
            var result = UpdateClassInfor("10A1", "C2.19");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void UTCID02()
        {
            var result = UpdateClassInfor("10A1", "");
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class STudentTest
    {
        public static string GenerateID()
        {
            int result = (new Random()).Next(100000, 999999);
            return result.ToString();
        }
        public bool AddStudent(TutteeFrame.Model.Student student)
        {
            string connectionString = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
           

            //byte[] photo = ImageHelper.ImageToBytes(student.Avatar);

            try
            {
                string strQuery = "INSERT INTO STUDENT(StudentID,Surname,FirstName,DateBorn,Sex,Address,Phonne,ClassID,Status,StudentImage) " +
                "VALUES(@studentid,@surname,@firstname,@dateborn,@sex,@address,@phone,@classid,@status,'')";
                using (SqlCommand sqlCommand = new SqlCommand(strQuery, con))
                {
                    sqlCommand.Parameters.AddWithValue("@studentid", student.ID);
                    sqlCommand.Parameters.AddWithValue("@surname", student.SurName);
                    sqlCommand.Parameters.AddWithValue("@firstname", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@dateborn", student.DateBorn);
                    sqlCommand.Parameters.AddWithValue("@sex", student.Sex);
                    sqlCommand.Parameters.AddWithValue("@phone", student.Phone);
                    sqlCommand.Parameters.AddWithValue("@classid", student.ClassID);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@status", student.Status);
                    //sqlCommand.Parameters.AddWithValue("@punishmentlistid", string.IsNullOrEmpty(student.PunishmentList) ? (object)DBNull.Value : student.PunishmentList);
                    // sqlCommand.Parameters.Add("@studentimage", SqlDbType.Image, photo.Length).Value = photo;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        //UTCID01
        [TestMethod]
        public void AddStudent_1()
        {
            Student test1 = new Student();
            test1.ID = GenerateID();
            test1.FirstName = "";
            test1.SurName = "Trần";
            test1.Address = "Sóc Trăng";
            test1.Sex = true;
            test1.DateBorn = new DateTime(2001, 02, 23);
            test1.Phone = "01287561234";
            test1.Status = false;
            test1.ClassID = "10A2";

            var result = AddStudent(test1);

            Assert.AreEqual("Ten khong duoc bo trong", result);
        }

         //UTCID02
        [TestMethod]
        public void AddStudent_2()
        {
            Student test1 = new Student();
            test1.ID = GenerateID();
            test1.FirstName = "Thức";
            test1.SurName = "Thức";
            test1.Address = "Sóc Trăng";
            test1.Sex = true;
            test1.DateBorn = new DateTime(2001, 02, 23);
            test1.Phone = "012";
            test1.Status = true;
            test1.ClassID = "10A2";

            var result = AddStudent(test1);

            Assert.AreEqual("So dien thoai khong hop le", result);
        }
        //UTCID03
        [TestMethod]
        public void AddStudent_3()
        {
            Student test1 = new Student();
            test1.ID = GenerateID();
            test1.FirstName = "Thức";
            test1.SurName = "Thức";
            test1.Address = "Sóc Trăng";
            test1.Sex = false;
            test1.DateBorn = new DateTime(2001, 02, 23,0 , 0, 0);
            test1.Phone = "01287561234";
            test1.Status = true;
            test1.ClassID = "10A2";

            var result = AddStudent(test1);

            Assert.AreEqual(true, result);
        }
    }
    [TestClass]
    public class UpdateSTudentTest
    {
        public bool UpdateStudent(string _studentID, Student student)
        {
            string connectionString = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            try
            {
                string query = $"UPDATE  STUDENT SET " +
                    "Surname = @surname," +
                    "Firstname = @firstname," +
                    "StudentImage =@studentimage," +
                    "DateBorn =@dateborn, " +
                    "Sex =@sex, " +
                    "Address= @address," +
                    "Phonne = @phone," +
                    "ClassID =@classid, " +
                    "Status = @status" +
                    $" WHERE StudentID = @studentid";
                using (SqlCommand sqlCommand = new SqlCommand(query, con))
                {
                    sqlCommand.Parameters.AddWithValue("@studentid", _studentID);
                    sqlCommand.Parameters.AddWithValue("@surname", student.SurName);
                    sqlCommand.Parameters.AddWithValue("@firstname", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@dateborn", student.DateBorn);
                    sqlCommand.Parameters.AddWithValue("@sex", student.Sex);
                    sqlCommand.Parameters.AddWithValue("@phone", student.Phone);
                    sqlCommand.Parameters.AddWithValue("@classid", student.ClassID);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@status", student.Status);
                    //sqlCommand.Parameters.AddWithValue("@punishmentlistid", string.IsNullOrEmpty(student.PunishmentList) ? (object)DBNull.Value : student.PunishmentList);
                   // sqlCommand.Parameters.Add("@studentimage", SqlDbType.Image, photo.Length).Value = photo;
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        //UTCID01
        [TestMethod]
        public void UpdateStudent_1()
        {
            Student test1 = new Student();
            test1.ID = "20200025";
            test1.FirstName = "Lý";
            test1.SurName = "";
            test1.Address = "53 đường Võ Văn Kiệt";
            test1.Sex = true;
            test1.DateBorn = new DateTime(2003, 12, 02, 0, 0, 0);
            test1.Phone = "092828517";
            test1.Status = true;
            test1.ClassID = "11A3";
            var result = UpdateStudent("20200025", test1);

            Assert.AreEqual(false, result);
        }
        //UTCID02
        [TestMethod]
        public void UpdateStudent_2()
        {
            Student test1 = new Student();
            test1.ID = "20200025";
            test1.FirstName = "Lý";
            test1.SurName = "";
            test1.Address = "30 Hai Bà Trưng";
            test1.Sex = true;
            test1.DateBorn = new DateTime(2003, 12, 02, 0, 0, 0);
            test1.Phone = "092828517";
            test1.Status = false;
            test1.ClassID = "11A3";
            var result = UpdateStudent("20200025", test1);

            Assert.AreEqual(true, result);
        }

        //UTCID03 -> Press Hủy
    }
    [TestClass]
    public class DeleteStudentTest
    {
        public bool DeleteStudent(string _studentID)
        {
            string connectionString = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {
                //Xóa học sinh
                string strQuery = $"SELECT ClassID FROM STUDENT WHERE STUDENT.StudentID = @studentid";
                SqlCommand sqlCommand = new SqlCommand(strQuery, con);
                sqlCommand = new SqlCommand(strQuery, con);
                sqlCommand.Parameters.AddWithValue("@studentid", _studentID);
                string classID = (string)sqlCommand.ExecuteScalar();
                strQuery = $"DELETE FROM STUDENT WHERE STUDENT.StudentID = @studentid";
                sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.Parameters.AddWithValue("@studentid", _studentID);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
        //UTCID01
        //Khi demo lại Unit tetsing cần phải thay đôi các đối số được thêm vào hàm ví dụ AD180 và chọn 1 ID từ bảng trog database
        [TestMethod]
        public void DeleteStu_1()
        {
            var result = DeleteStudent("AD180");
            Assert.AreEqual(true, result);
        }
        //UTCID02
        [TestMethod]
        public void DeleteStu_2()
        {
            var result = DeleteStudent("MH12");
            Assert.AreEqual(true, result);
        }
        //UTCID03
        [TestMethod]
        public void DeleteStu_3()
        {
            var result = DeleteStudent("HUYNH001");
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class UpdateStuConductandChangPass
    {
        public bool UpdatePass(string _teacherID, string _newPass)
        {
            string connectionString = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"UPDATE ACCOUNT SET Password = @newpass WHERE TeacherID = @teacherid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newpass", _newPass);
                    command.Parameters.AddWithValue("@teacherid", _teacherID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
      
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool UpdateStudentConduct(string _studentID, int _grade, StudentConduct _studentConduct)
        {
            string connectionString = @"Server=LAPTOP-DKIC94F6\SQLEXPRESS;Database=TutteeFrame;User ID=sa;Password=123456";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "UPDATE LEARNRESULT SET ConductSE01 = @conductsem1, ConductSE02 = @conductsem2, YearConduct = @yearconduct " +
                        "WHERE StudentID = @studentid AND Grade = @grade";
                    sqlCommand.Parameters.AddWithValue("@studentid", _studentID);
                    sqlCommand.Parameters.AddWithValue("@grade", _grade);
                    if (_studentConduct.Conducts[0].ToString() == string.Empty)
                        sqlCommand.Parameters.AddWithValue("@conductsem1", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@conductsem1", _studentConduct.Conducts[0].ToString());
                    if (_studentConduct.Conducts[1].ToString() == string.Empty)
                        sqlCommand.Parameters.AddWithValue("@conductsem2", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@conductsem2", _studentConduct.Conducts[1].ToString());
                    if (_studentConduct.Conducts[2].ToString() == string.Empty)
                        sqlCommand.Parameters.AddWithValue("@yearconduct", DBNull.Value);
                    else
                        sqlCommand.Parameters.AddWithValue("@yearconduct", _studentConduct.Conducts[2].ToString());
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
          
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        [TestMethod]
        public void UpdateConduct_1()
        {
            StudentConduct s = new StudentConduct();
            Conduct c1 = new Conduct();
            c1.conductType = (Conduct.ConductType)2;
            Conduct c2 = new Conduct();
            c2.conductType = (Conduct.ConductType)1;
            Conduct c3 = new Conduct();
            c3.conductType = (Conduct.ConductType)3;
            s.StudentID = "2020000210";
            s.Conducts.Add(c1);
            s.Conducts.Add(c2);
            s.Conducts.Add(c3);

            var result = UpdateStudentConduct("2020000210", 10, s);

            Assert.AreEqual(true, result);
        }

        //UNIT TEST CHANGE PASS FOR TEACHER ACCOUNT

        //UTCID01
        [TestMethod]
        public void ChangePass_1()
        {
            var result = UpdatePass("TC611564", "test");
            Assert.AreEqual(true, result);
        }

        //UTCID02
        [TestMethod]
        public void ChangePass_2()
        {
            var result = UpdatePass("TC973134", "test");
            Assert.AreEqual(true, result);
        }
        //UTCID03
        [TestMethod]
        public void ChangePass_3()
        {
            var result = UpdatePass("TC748704", "123456");
            Assert.AreEqual(true, result);
        }
        //UTCID04
        [TestMethod]
        public void ChangePass_4()
        {
            var result = UpdatePass("TC677677", "123456");
            Assert.AreEqual(true, result);
        }
    }
}
