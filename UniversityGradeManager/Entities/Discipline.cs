using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGradeManager.Entities
{
    public class Discipline
    {

        private string _code;
        private string _name;
        private int _theorycClassesCount;
        private int _practiseClassesCount;
        private int _numberOfCredits;
        private int _workload;
        private int _clockHours;
        private string _preRequisite;

        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int TheorycClassesCount
        {
            get
            {
                return _theorycClassesCount;
            }

            set
            {
                _theorycClassesCount = value;
            }
        }

        public int PractiseClassesCount
        {
            get
            {
                return _practiseClassesCount;
            }

            set
            {
                _practiseClassesCount = value;
            }
        }

        public int NumberOfCredits
        {
            get
            {
                return _numberOfCredits;
            }

            set
            {
                _numberOfCredits = value;
            }
        }

        public int Workload
        {
            get
            {
                return _workload;
            }

            set
            {
                _workload = value;
            }
        }

        public int ClockHours
        {
            get
            {
                return _clockHours;
            }

            set
            {
                _clockHours = value;
            }
        }

        public string PreRequisite
        {
            get
            {
                return _preRequisite;
            }

            set
            {
                _preRequisite = value;
            }
        }
    }
}