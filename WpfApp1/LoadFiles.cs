using System;
using System.Data.SQLite;
using System.Data;
using System.IO;
using Spire.Xls;
using System.Text.RegularExpressions;
using System.Windows;
using System.Collections.Generic;

namespace Schedule
{
    public class LoadFiles
    {
        protected SQLiteConnection DB { get; set; }
        public static DataTable loadTable(string nameOfTable)
        {

            
            SQLiteConnection DB;
            DB = new SQLiteConnection("Data Source = TestDB.db");

            try
            {
                DB.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                // MessageBox.Show(ex.Message); ///TO DO MessageBox
            }

            DataSet dataSet = new System.Data.DataSet();
            System.Data.SQLite.SQLiteDataAdapter sqliteAdapter = new SQLiteDataAdapter($"SELECT * FROM {nameOfTable}", DB);
            try
            {
                sqliteAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // MessageBox.Show(ex.Message);
            }
            DataTable dataTable = dataSet.Tables[0];
            dataTable.Columns.RemoveAt(0);

            return dataTable;

        }
        protected static void inputCheckForColumnsNames(ref DataTable dataTable)
        {

            Regex capacity = new Regex(@"(^кіль)([^кість]?)+(\s?)+(міс)([місць]?)+", RegexOptions.IgnoreCase);
            Regex num = new Regex(@"(^ном)|(^номер)", RegexOptions.IgnoreCase);
            Regex letter_of_aud = new Regex(@"^літ", RegexOptions.IgnoreCase);
            Regex type_of_aud = new Regex(@"(^тип)+(\s?)(ауд)([иторії]?)+", RegexOptions.IgnoreCase);
            Regex department = new Regex(@"(підроз\w*)|(каф)", RegexOptions.IgnoreCase);
            Regex rank = new Regex(@"(посада)", RegexOptions.IgnoreCase);
            Regex subject = new Regex(@"(д[и|е]сц[и|е]пл\w*)", RegexOptions.IgnoreCase);
            Regex numOfHoursForLectionsPerWeek = new Regex(@"ле", RegexOptions.IgnoreCase);
            Regex numOfHoursForPracticePerWeek = new Regex(@"практ", RegexOptions.IgnoreCase);
            Regex fio = new Regex(@"(ПІБ)|(ФИО)|(прізв)", RegexOptions.IgnoreCase);
            Regex numOfHoursPerProfessor = new Regex(@"год", RegexOptions.IgnoreCase);
            Regex course = new Regex(@"курс", RegexOptions.IgnoreCase);
            Regex speciality = new Regex(@"спец", RegexOptions.IgnoreCase);
            Regex population = new Regex(@"(^кіль)([кість]?)+(\s?)+(сту)([дентів]?)+", RegexOptions.IgnoreCase);
  

            string test;

            for (int i = 0; i< dataTable.Columns.Count; ++i)
            {
                test = dataTable.Columns[i].ColumnName.TrimStart();
                
                if (capacity.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Capacity";
                }
                else if (num.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Num of Auditorium";
                }
                else if (letter_of_aud.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Letter of Auditorium";
                }
                else if (type_of_aud.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Type of Auditorium";
                }
                else if (department.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Department";
                }
                else if (rank.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Rank";
                }
                else if (subject.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Subject";
                }
                else if (numOfHoursForLectionsPerWeek.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Num of Hours for lections per week";
                }
                else if (numOfHoursForPracticePerWeek.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Num of hours for practice per week";
                }
                else if (fio.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "FIO";
                }
                else if (numOfHoursPerProfessor.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "NumOfMaxHours";
                }
                else if (course.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Course";
                }
                else if (speciality.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Speciality";
                }
                else if (population.IsMatch(test))
                {
                    dataTable.Columns[i].ColumnName = "Population";
                }
                else
                {
                    throw new Exception($"Знайдено непідтримуву назву у стовпчику {i} ");
                }


            }

        }
        protected static int inputCheckForAuditoriumField(string input_data)
        {
                string test = input_data;
                input_data = test.TrimStart(); //очистка пробельных символов в начале строки
                Regex reg_lection = new Regex(@"^ле", RegexOptions.IgnoreCase);
                Regex reg_comp = new Regex(@"^комп", RegexOptions.IgnoreCase);
                Regex reg_lab = new Regex(@"^лаб", RegexOptions.IgnoreCase);
                Regex reg_room = new Regex(@"^каб", RegexOptions.IgnoreCase);
                Regex reg_gym = new Regex(@"^спор", RegexOptions.IgnoreCase);

                //проверки конфертируют строковое значение типа аудитории в ID, которое сохранится в БД
                        if (reg_lection.IsMatch(input_data))
                        {
                            return 1;
                        }
                        else if (reg_comp.IsMatch(input_data))
                        {
                            return 2;
                        }
                        else if (reg_lab.IsMatch(input_data))
                        {
                            return 3;
                        }
                        else if (reg_room.IsMatch(input_data))
                        {
                            return 4;
                        }
                        else if (reg_gym.IsMatch(input_data))
                        {
                            return 5;
                        }
                        else
                        {
                            throw new Exception($"Знайдено непідтримуваний вид аудиторії ");
                        }      
        }
        protected static int inputCheckForDepartmentField(string input_data)
        {
                string test = input_data;
                input_data = test.TrimStart(); //очистка пробельных символов в начале строки
                Regex reg_kaf_PZ = new Regex(@"ПЗ", RegexOptions.IgnoreCase);
                Regex reg_kaf_PP = new Regex(@"ПП", RegexOptions.IgnoreCase);
                Regex reg_kaf_KSM = new Regex(@"КСМ", RegexOptions.IgnoreCase);
                Regex reg_kaf_Fzk = new Regex(@"Фзк", RegexOptions.IgnoreCase);
                Regex reg_kaf_Flsf = new Regex(@"Флсф", RegexOptions.IgnoreCase);
                Regex reg_kaf_Ukrz = new Regex(@"Укрз", RegexOptions.IgnoreCase);
                Regex reg_kaf_PM = new Regex(@"ПМ", RegexOptions.IgnoreCase);
                Regex reg_kaf_IM = new Regex(@"ІМ", RegexOptions.IgnoreCase);
                Regex reg_kaf_VM = new Regex(@"ВМ", RegexOptions.IgnoreCase);
                Regex reg_kaf_OIBC = new Regex(@"ОІВС", RegexOptions.IgnoreCase);

            //проверки конфертируют строковое значение названия кафедры в ID, которое сохранится в БД
                        if (reg_kaf_PZ.IsMatch(input_data))
                        {
                            return 1;
                        }
                        else if (reg_kaf_PP.IsMatch(input_data))
                        {
                            return 2;
                        }
                        else if (reg_kaf_Fzk.IsMatch(input_data))
                        {
                            return 3;
                        }
                        else if (reg_kaf_Flsf.IsMatch(input_data))
                        {
                            return 4;
                        }
                        else if (reg_kaf_Ukrz.IsMatch(input_data))
                        {
                            return 5;
                        }
                        else if (reg_kaf_PM.IsMatch(input_data))
                        {
                            return 6;
                        }
                        else if (reg_kaf_IM.IsMatch(input_data))
                        {
                            return 7;
                        }
                        else if (reg_kaf_VM.IsMatch(input_data))
                        {
                            return 8;
                        }
                        else if (reg_kaf_KSM.IsMatch(input_data))
                        {
                            return 9;
                        }
                        else if (reg_kaf_OIBC.IsMatch(input_data))
                        {
                            return 10;
                        }
                        else
                        {
                            throw new Exception($"Знайдено непідтримуваний вид кафедри");
                        }            
        }
        protected static int inputCheckForProfessorsRankField(string input_data)
        {
                string test = input_data;
                input_data = test.TrimStart(); //очистка пробельных символов в начале строки
                Regex reg_professor = new Regex(@"^про", RegexOptions.IgnoreCase);
                Regex reg_docent = new Regex(@"^доц", RegexOptions.IgnoreCase);
                Regex reg_stVikladach = new Regex(@"^ст", RegexOptions.IgnoreCase);
                Regex reg_assistent = new Regex(@"^ас", RegexOptions.IgnoreCase);
                Regex reg_zav_kaf = new Regex(@"^зав", RegexOptions.IgnoreCase);
            
            //проверки конфертируют строковое значение ранга преподавателя в ID, которое сохранится в БД
                        if (reg_professor.IsMatch(input_data))
                        {
                            return 1;
                        }
                        else if (reg_docent.IsMatch(input_data))
                        {
                            return 2;
                        }
                        else if (reg_stVikladach.IsMatch(input_data))
                        {
                            return 3;
                        }
                        else if (reg_assistent.IsMatch(input_data))
                        {
                            return 4;
                        }
                        else if (reg_zav_kaf.IsMatch(input_data))
                        {
                            return 5;
                        }
                        else
                        {
                            throw new Exception($"Знайдено непідтримуваний вид рангу викладача");
                        }                           
        }

        public void LoadDB(string dataSource = "TestDB.db") // Подключение БД для работы. Принимет адрес БД
        {
            try
            {
                DB = new SQLiteConnection($"Data Source = {dataSource}");
                DB.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CloseDB()
        {
            DB.Close();
        } // Закрытие БД

        public void LoadExcelFileForCurriculum(string filename, string name_of_course) //Загрузка расписания курса. Принимает имя Excel файла и название курса
        {                                                                                                       
            Workbook workbook = new Workbook();
            
            try
            {
                workbook.LoadTemplateFromFile(filename); //загрузка Excel файла
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return;
            }

            Worksheet sheet = workbook.Worksheets[0];
            DataTable dataTable = sheet.ExportDataTable(); //перемещение файла в DataTable для обработки

            var sqliteAdapter = new SQLiteDataAdapter($"SELECT * FROM {name_of_course}", DB); //создание адаптера для установления связи с таблицей в БД
            var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);

            if (dataTable.Columns.Count == 5) //проверка на количество столбцов
            {
                try
                {
                    inputCheckForColumnsNames(ref dataTable);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                LoadDB();
                SQLiteCommand cmd = DB.CreateCommand();

                cmd.CommandText = $"DROP TABLE IF EXISTS {name_of_course};"+
                                  $"CREATE TABLE {name_of_course} (" +      //динамическое создание таблиц расписания для курса
                                  @"Id                 INTEGER       PRIMARY KEY AUTOINCREMENT," +
                                  @"Subject            VARCHAR(100)  NOT NULL UNIQUE," +
                                  @"Department         INTEGER       REFERENCES [Names of Departments] (Id) ON DELETE CASCADE," +
                                  @"[Num of Hours for lections per week]  DOUBLE," +
                                  @" [Num of hours for practice per week] DOUBLE," +
                                  @"[Type of auditorium for practice]     INTEGER NOT NULL REFERENCES [Types of Auditorium] (Id) ON DELETE CASCADE );" +
                                  $@"CREATE UNIQUE INDEX unique_index_for_{name_of_course} ON {name_of_course}( Subject, Department);";
                ;

                try
                {
                    cmd.ExecuteNonQuery();  //проверка, успешно ли совершено действие
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                int rowCounter = 0;
                try
                {                
                    // цикл изменяет строковые данные на числовые для уменьшения кол-ва памяти в БД
                    for (rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
                    {
                        dataTable.Rows[rowCounter][4] = inputCheckForAuditoriumField(dataTable.Rows[rowCounter][4].ToString());
                        dataTable.Rows[rowCounter][1] = inputCheckForDepartmentField(dataTable.Rows[rowCounter][1].ToString());
                    }
                }
                catch(Exception ex)
                {
                    //сообщение об ошибке выводит строку в которой произошла ошибка 
                    MessageBox.Show($"{ex.Message} у рядку {rowCounter} . Будь ласка, звіртеся з шаблоном");
                }

                try //обновление таблицы и отключение адаптера
                {
                    sqliteAdapter.Update(dataTable); //N!B! названия столбцов БД и файла должны совпадать !
                    sqliteAdapter.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else //если кол-во столбцов не совпадает - таблицы не может быть занесена в БД
            {
                MessageBox.Show("Таблиця не співпадає за шаблоном ! Будь ласка, звіртеся ще раз");
            }
        }

        public void LoadExcelFileForAuditorium(string filename) //Загрузка данных об аудиториях. Принимает имя Excel файла 
        {

            

            Workbook workbook = new Workbook();

            try
            {
                workbook.LoadTemplateFromFile(filename); //загрузка Excel файла
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDB();
            SQLiteCommand cmd = DB.CreateCommand();
            cmd.CommandText = $"DELETE FROM Auditorium"; //Предыдущие данные будут удалены !!!
            cmd.ExecuteNonQuery();

            Worksheet sheet = workbook.Worksheets[0];
            DataTable dataTable = sheet.ExportDataTable(); //перемещение файла в DataTable для обработки
            var sqliteAdapter = new SQLiteDataAdapter("SELECT * FROM Auditorium", DB); //создание адаптера для установления связи с таблицей в БД
            var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
              
            if (dataTable.Columns.Count == 5) //проверка на количество столбцов
            {
                try
                {
                    inputCheckForColumnsNames(ref dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                int rowCounter = 0;
                try
                {
                    // цикл изменяет строковые данные на числовые для уменьшения кол-ва памяти в БД
                    for (rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
                    {
                        dataTable.Rows[rowCounter][3] = inputCheckForAuditoriumField(dataTable.Rows[rowCounter][3].ToString());
                        dataTable.Rows[rowCounter][4] = inputCheckForDepartmentField(dataTable.Rows[rowCounter][4].ToString());
                        ///вывод неправильной клетки
                    }
                }
                catch(Exception ex)
                {
                    //сообщение об ошибке выводит строку в которой произошла ошибка 
                    MessageBox.Show($"{ex.Message} у рядку {rowCounter} . Будь ласка, звіртеся з шаблоном");
                }

                try   //обновление таблицы и отключение адаптера
                {
                    sqliteAdapter.Update(dataTable); //N!B! названия столбцов БД и файла должны совпадать !
                    sqliteAdapter.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   return;
                }
            }
            else  //если кол-во столбцов не совпадает - таблицы не может быть занесена в БД
            {
                MessageBox.Show("Таблиця не співпадає за шаблоном ! Будь ласка, звіртеся ще раз");
            }
        }

        public void LoadExcelFileForProfessors(string filename) //Загрузка данных о преподавателях. Принимает имя Excel файла 
        {
            Workbook workbook = new Workbook();

            try
            {
                workbook.LoadTemplateFromFile(filename); //загрузка Excel файла
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SQLiteCommand cmd = DB.CreateCommand();
            cmd.CommandText = $"DELETE FROM Professors"; //Предыдущие данные будут удалены !!!
            cmd.ExecuteNonQuery();

            Worksheet sheet = workbook.Worksheets[0];
            DataTable dataTable = sheet.ExportDataTable(); //перемещение файла в DataTable для обработки
            var sqliteAdapter = new SQLiteDataAdapter("SELECT * FROM Professors", DB); //создание адаптера для установления связи с таблицей в БД
            var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);

            if (dataTable.Columns.Count == 4) //проверка на количество столбцов
            {
                try
                {
                    inputCheckForColumnsNames(ref dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                int rowCounter = 0;
                try
                {
                    // цикл изменяет строковые данные на числовые для уменьшения кол-ва памяти в БД
                    for (rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
                    {
                        dataTable.Rows[rowCounter][2] = inputCheckForProfessorsRankField(dataTable.Rows[rowCounter][2].ToString());
                        dataTable.Rows[rowCounter][0] = inputCheckForDepartmentField(dataTable.Rows[rowCounter][0].ToString());
                        ///вывод неправильной клетки
                    }
                }
                catch(Exception ex)
                {
                    //сообщение об ошибке выводит строку в которой произошла ошибка 
                    MessageBox.Show($"{ex.Message} у рядку {rowCounter} . Будь ласка, звіртеся з шаблоном");
                }

                try  //обновление таблицы и отключение адаптера
                {
                    sqliteAdapter.Update(dataTable); //N!B! названия столбцов БД и файла должны совпадать !
                    sqliteAdapter.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else  //если кол-во столбцов не совпадает - таблицы не может быть занесена в БД
            {
                MessageBox.Show("Таблиця не співпадає за шаблоном ! Будь ласка, звіртеся ще раз");
            }
        }

        public void LoadExcelFileForGroup(string filename)
        {
            Workbook workbook = new Workbook();

            try
            {
                workbook.LoadTemplateFromFile(filename); //загрузка Excel файла
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDB();
            SQLiteCommand cmd = DB.CreateCommand();
            cmd.CommandText = $"DELETE FROM Groups"; //Предыдущие данные будут удалены !!!
            cmd.ExecuteNonQuery();

            Worksheet sheet = workbook.Worksheets[0];
            DataTable dataTable = sheet.ExportDataTable(); //перемещение файла в DataTable для обработки
            var sqliteAdapter = new SQLiteDataAdapter($"SELECT * FROM Groups", DB); //создание адаптера для установления связи с таблицей в БД
            var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);

            if (dataTable.Columns.Count == 5) //проверка на количество столбцов
            {
                try
                {
                    inputCheckForColumnsNames(ref dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                int rowCounter = 0;
                try
                {
                    // цикл изменяет строковые данные на числовые для уменьшения кол-ва памяти в БД
                    for (rowCounter = 0; rowCounter < dataTable.Rows.Count; ++rowCounter)
                    {
                        dataTable.Rows[rowCounter][1] = inputCheckForDepartmentField(dataTable.Rows[rowCounter][0].ToString());
                        ///вывод неправильной клетки
                    }
                }
                catch (Exception ex)
                {
                    //сообщение об ошибке выводит строку в которой произошла ошибка 
                    MessageBox.Show($"{ex.Message} у рядку {rowCounter} . Будь ласка, звіртеся з шаблоном");
                }

                try  //обновление таблицы и отключение адаптера
                {
                    sqliteAdapter.Update(dataTable); //N!B! названия столбцов БД и файла должны совпадать !
                    sqliteAdapter.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else  //если кол-во столбцов не совпадает - таблицы не может быть занесена в БД
            {
                MessageBox.Show("Таблиця не співпадає за шаблоном ! Будь ласка, звіртеся ще раз");
            }
        }
       

        public List<string> getNamesOfCourses()
        {
            List<string> a;
            this.LoadDB();
                  
            SQLiteCommand cmd = DB.CreateCommand();
            cmd.CommandText = $"SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite%' AND name LIKE '%Sp%';";
            SQLiteDataReader reader = cmd.ExecuteReader();

            a = new List<string>(reader.StepCount);

      

            if (reader.HasRows)
            {               
                while(reader.Read())
                {
                    a.Add(reader[0].ToString());
                }
            }
 

            this.CloseDB();
            return a;
        }

    }
}
