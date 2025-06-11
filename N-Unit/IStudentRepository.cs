﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_testing
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetByRollNo(int rollNo);
        Student GetByName(string name);
        void Add(Student student);
        void Update(Student student);
        void Delete(int rollNo);
    }

}
