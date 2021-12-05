using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public interface IStrategy
    {
        List<Student> Search(Student student, string path);
    }
}
