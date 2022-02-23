using BL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BL.Control
{
    public class UserControler : DatabaseDatasaver
    {
        public User CurrentUser { get; }

        public bool NewUser { get; } = false;
        
        string TableName;

        public UserControler(string userName, string tableName) : base(tableName)
        {
            TableName = tableName;
            sqldataAdapter = new SqlDataAdapter($"SELECT * FROM {tableName} WHERE Name = '{userName}'", sqlConnection);
            dataSet = new DataSet();
            sqldataAdapter.Fill(dataSet, tableName);

            if (dataSet.Tables[tableName].Rows.Count > 0 )
            {
                // old user 
                CurrentUser = new User(dataSet.Tables[tableName].Rows[0]["Name"].ToString());
                CurrentUser.Gender = dataSet.Tables[tableName].Rows[0]["Gender"].ToString();
                CurrentUser.Age = int.Parse(dataSet.Tables[tableName].Rows[0]["Age"].ToString());
                CurrentUser.Weight = double.Parse(dataSet.Tables[tableName].Rows[0]["Weight"].ToString());
                CurrentUser.Height = double.Parse(dataSet.Tables[tableName].Rows[0]["Height"].ToString());
            }
            else
            {
                CurrentUser = new User(userName);
                NewUser = true;
            }
        }

        public void SetNewUserData(string name, string gender, int age, double weight, double height)
        {
            CurrentUser.Gender = gender;
            CurrentUser.Age = age;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            sqldataAdapter = new SqlDataAdapter($"SELECT * FROM {TableName}", sqlConnection);
            sqldBuilder = new SqlCommandBuilder(sqldataAdapter);

            sqldBuilder.GetUpdateCommand();

            dataSet = new DataSet();
            sqldataAdapter.Fill(dataSet, TableName);

            DataRow row = dataSet.Tables[TableName].NewRow();
            row["Name"] = name;
            row["Gender"] = gender;
            row["Age"] = age;
            row["Weight"] = weight;
            row["Height"] = height;
            dataSet.Tables[TableName].Rows.Add(row);
            sqldataAdapter.Update(dataSet, TableName);
        }

        public double HarissBenedict(double activlevel)
        {
            double result = 0;

            if (CurrentUser.Gender == "М")
            {
                result = Math.Round((66.5 + 13.75 * CurrentUser.Weight + 5.003 * CurrentUser.Height - 6.775 * CurrentUser.Age) * activlevel);
            }
            else if (CurrentUser.Gender == "Ж")
            {
                result = Math.Round((655.1 + 9.563 * CurrentUser.Weight + 1.85 * CurrentUser.Height - 4.676 * CurrentUser.Age) * activlevel);
            }

            return result;
        }
    }

}
