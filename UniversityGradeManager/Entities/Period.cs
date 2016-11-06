using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGradeManager.Entities
{
    public class Period
    {

        private int _id;
        private List<Discipline> _discplines;

        public Period()
        {
            _discplines = new List<Discipline>();
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public List<Discipline> Discplines
        {
            get
            {
                return _discplines;
            }
        }

        public int TheorycClassesCount
        {
            get
            {
                int total = 0;
                foreach (Discipline discilpline in _discplines)
                    total += discilpline.TheorycClassesCount;

                return total;
            }
        }

        public int PractiseClassesCount
        {
            get
            {
                int total = 0;
                foreach (Discipline discilpline in _discplines)
                    total += discilpline.PractiseClassesCount;

                return total;
            }
        }

        public int NumberOfCredits
        {
            get
            {
                int total = 0;
                foreach (Discipline discilpline in _discplines)
                    total += discilpline.NumberOfCredits;

                return total;
            }
        }

        public int Workload
        {
            get
            {
                int total = 0;
                foreach (Discipline discilpline in _discplines)
                    total += discilpline.Workload;

                return total;
            }
        }

        public int ClockHours
        {
            get
            {
                int total = 0;
                foreach (Discipline discilpline in _discplines)
                    total += discilpline.ClockHours;

                return total;
            }
        }
    }
}