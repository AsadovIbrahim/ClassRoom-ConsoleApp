using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom_Project.Models
{
    public static class Helper
    {
        public static bool CheckName(this string name)
        {
            return name.Length < 3 && !char.IsUpper(name[0]);
        }

        public static bool CheckSurname(this string surname)
        {
            return !char.IsUpper(surname[0]);
        }
    }
}
