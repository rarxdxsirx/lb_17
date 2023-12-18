using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lb_17
{
    public class PersonModel : IDataErrorInfo
    {
        public string Name { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Position { get; set; } = String.Empty;
        public string this[string columnName]
        {
            get
            {   
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if (Age <= 0 || Age > 100)
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "Name":
                        if (Name.Equals(String.Empty) || !Regex.IsMatch(Name, @"^[а-яА-Я ]+$") || Regex.IsMatch(Name.Trim(), @"[ \t]{2,}"))
                        {
                            error = "Имя должно содержать только русский язык и пробелы";
                        }
                        break;
                    case "Position":
                        if (Position.Equals(String.Empty) || !Regex.IsMatch(Position, @"^[а-яА-Я ]+$") || Regex.IsMatch(Position.Trim(), @"[ \t]{2,}"))
                        {
                            error = "Позиция должна содержать только русский язык и пробелы";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
