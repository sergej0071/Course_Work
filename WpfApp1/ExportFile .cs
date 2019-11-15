using System;
using System.Data.SQLite;
using System.Data;
using System.IO;
using Spire.Xls;
using System.Text.RegularExpressions;
using System.Windows;

namespace Schedule
{
    class ExportFile : LoadFiles
    {
        protected static void outputCheckForColumns(ref DataTable dataTable)
        {
            string input;
            int max = dataTable.Columns.Count;
            for (int columnCounter = 0; columnCounter < max; columnCounter++)
            {
                input = dataTable.Columns[columnCounter].ColumnName;

                if (input == "Сapacity")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Кількість місць";
                }
                else if (input == "Num of Auditorium")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Номер";
                }
                else if (input == "Letter of Auditorium")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Літера";
                }
                else if (input == "Type of Auditorium" || input == "Type of auditorium for practice")
                {           
                    outputCheckForAuditoriumField(ref dataTable, columnCounter);
                    columnCounter--;
                    max--;
                }
                else if (input == "Department")
                {                   
                    outputCheckForDepartmentField(ref dataTable, columnCounter);
                    columnCounter--;
                    max--;
                }
                else if (input == "Rank")
                {
                    outputCheckForProfessorsRankField(ref dataTable, columnCounter);
                    columnCounter--;
                    max--;
                }
                else if (input == "Subject")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Дисципліна";
                }
                else if (input == "Num of Hours for lections per week")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Кількість лекцій на тиждень";
                }
                else if (input == "Num of hours for practice per week")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Кількість практик на тиждень";
                }
                else if (input == "FIO")
                {
                    dataTable.Columns[columnCounter].ColumnName = "ПІБ викладача";
                }
                else if (input == "NumOfMaxHours")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Бажана кількість годин";
                }
                else if (input == "Course")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Курс";
                }
                else if (input == "Speciality")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Спеціальність";
                }
                else if (input == "Population")
                {
                    dataTable.Columns[columnCounter].ColumnName = "Кількість студентів";
                }
                else
                {
                }
            }
        }
        protected static void outputCheckForAuditoriumField(ref DataTable dataTable, int selectedColumn)
        {
            int test;
            DataColumn dataColumn = new DataColumn("New");
            dataTable.Columns.Add(dataColumn);

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; rowCounter++)
            {
                test = int.Parse(dataTable.Rows[rowCounter][selectedColumn].ToString());

                if (test == 1)
                {
                    dataTable.Rows[rowCounter]["New"] = "лекційна";
                }
                else if (test == 2)
                {
                    dataTable.Rows[rowCounter]["New"] = "комп'ютерна";
                }
                else if (test == 3)
                {
                    dataTable.Rows[rowCounter]["New"] = "лабораторна";
                }
                else if (test == 4)
                {
                    dataTable.Rows[rowCounter]["New"] = "кабінет";
                }
                else if (test == 5)
                {
                    dataTable.Rows[rowCounter]["New"] = "Спорт.зал";
                }
                else
                {
                    throw new Exception($"Знайдено непідтримуваний вид аудиторії ");
                }
            }

            dataTable.Columns.Remove(dataTable.Columns[selectedColumn]);
            dataTable.Columns["New"].ColumnName = "Тип аудиторії";
        }
        protected static void outputCheckForDepartmentField(ref DataTable dataTable, int selectedColumn)
        {
            int test;
            DataColumn dataColumn = new DataColumn("New");
            dataTable.Columns.Add(dataColumn);

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; rowCounter++)
            {
                test = int.Parse(dataTable.Rows[rowCounter][selectedColumn].ToString());

                if (test == 1)
                {
                    dataTable.Rows[rowCounter]["New"] = "ПЗ";
                }
                else if (test == 2)
                {
                    dataTable.Rows[rowCounter]["New"] = "ПП";
                }
                else if (test == 3)
                {
                    dataTable.Rows[rowCounter]["New"] = "Фзк";
                }
                else if (test == 4)
                {
                    dataTable.Rows[rowCounter]["New"] = "Флсф";
                }
                else if (test == 5)
                {
                    dataTable.Rows[rowCounter]["New"] = "Укрз";
                }
                else if (test == 6)
                {
                    dataTable.Rows[rowCounter]["New"] = "ПМ";
                }
                else if (test == 7)
                {
                    dataTable.Rows[rowCounter]["New"] = "ІМ";
                }
                else if (test == 8)
                {
                    dataTable.Rows[rowCounter]["New"] = "ВМ";
                }
                else if (test == 9)
                {
                    dataTable.Rows[rowCounter]["New"] = "КСМ";
                }
                else if (test == 10)
                {
                    dataTable.Rows[rowCounter]["New"] = "ОІВС";
                }
                else
                {
                    throw new Exception($"Знайдено непідтримуваний вид кафедри");
                }
            }

            dataTable.Columns.Remove(dataTable.Columns[selectedColumn]);
            dataTable.Columns["New"].ColumnName = "Кафедра";
        }
        protected static void outputCheckForProfessorsRankField(ref DataTable dataTable, int selectedColumn)
        {
            int test;
            DataColumn dataColumn = new DataColumn("New");
            dataTable.Columns.Add(dataColumn);

            for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; rowCounter++)
            {
                test = int.Parse(dataTable.Rows[rowCounter][selectedColumn].ToString());

                if (test == 1)
                {
                    dataTable.Rows[rowCounter]["New"] = "Професор";
                }
                else if (test == 2)
                {
                    dataTable.Rows[rowCounter]["New"] = "Доцент";
                }
                else if (test == 3)
                {
                    dataTable.Rows[rowCounter]["New"] = "Асистент";
                }
                else if (test == 4)
                {
                    dataTable.Rows[rowCounter]["New"] = "Ст.викладач";
                }
                else if (test == 5)
                {
                    dataTable.Rows[rowCounter]["New"] = "Зав.каф";
                }
                else
                {
                    throw new Exception($"Знайдено непідтримуваний вид рангу викладача");
                }
            }
            dataTable.Columns.Remove(dataTable.Columns[selectedColumn]);
            dataTable.Columns["New"].ColumnName = "Посада";
        }
        public void ExportExcelFile(string filename, string name_of_table) //Выгрузка данных из БД в Excel.Принимает имя файла, куда будет помещена инф. и название выгружаемой таблицы
        {
            //SQLiteConnection DB = new SQLiteConnection("Data Source = TestDB.db"
            this.LoadDB();
            DataSet dataSet = new System.Data.DataSet();
            var sqliteAdapter = new SQLiteDataAdapter($"SELECT * FROM {name_of_table}", DB); //создание адаптера для установления связи с таблицей в БД
            var cmdBuilder = new SQLiteCommandBuilder(sqliteAdapter);
            sqliteAdapter.Fill(dataSet); // заполнение таблицы в dataSet
            DataTable dataTable = dataSet.Tables[0];
            dataTable.Columns.RemoveAt(0); //удаление колонки ID
            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];
            outputCheckForColumns(ref dataTable);
            sheet.InsertDataTable(dataTable, true, 1, 1);
            workbook.SaveToFile(filename, ExcelVersion.Version2016); //выгрузка файла
            this.CloseDB();
        }        
        public string outputCheckForDepartmentForComboBox(int selectedColumn)
        {
            
                if (selectedColumn == 1)
                {
                    return "ПЗ";
                }
                else if (selectedColumn == 2)
                {
                    return "ПП";
                }
                else if (selectedColumn == 3)
                {
                    return "Фзк";
                
                }
                else if (selectedColumn == 4)
                {
                    return "Флсф";
                }
                else if (selectedColumn == 5)
                {
                    return "Укрз";
                  
                }
                else if (selectedColumn == 6)
                {
                    return "PM";
                }
                else if (selectedColumn == 7)
                {
                    return "ІМ";
                }
                else if (selectedColumn == 8)
                {
                    return "ВМ";
                }
                else if (selectedColumn == 9)
                {
                return "КСМ";
                }
                else if (selectedColumn == 10)
                {
                return "ОІВС";
                }
                else
                {
                return "NonameDepartment";
                }
            

        
        }
    }
}
