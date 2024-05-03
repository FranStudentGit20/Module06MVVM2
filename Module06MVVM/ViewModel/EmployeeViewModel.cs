using Module06MVVM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module06MVVM.ViewModel
{
    class EmployeeViewModel
    {
        public EmployeeModel EmployeeModelSet { get; set; }
        public EmployeeViewModel()
        {
            EmployeeModelSet = new EmployeeModel
            {
                Id = 1,
                Name = "Juan Dela Cruz",
                Email = "juandelacruz@auf.edu.ph",
                Address = "Angeles City"
            };
        }
    }
}
