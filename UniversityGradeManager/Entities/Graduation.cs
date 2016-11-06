using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGradeManager.Entities
{
    public class Graduation
    {
        private int _id;
        private string _name;
        private List<Period> _periods;

        public Graduation()
        {
            _periods = new List<Period>();
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

        public List<Period> Periods
        {
            get
            {
                return _periods;
            }
        }

        public int TheorycClassesCount
        {
            get
            {
                int total = 0;
                foreach (Period period in _periods)
                    total += period.TheorycClassesCount;

                return total;
            }
        }

        public int PractiseClassesCount
        {
            get
            {
                int total = 0;
                foreach (Period period in _periods)
                    total += period.PractiseClassesCount;

                return total;
            }
        }

        public int NumberOfCredits
        {
            get
            {
                int total = 0;
                foreach (Period period in _periods)
                    total += period.NumberOfCredits;

                return total;
            }
        }

        public int Workload
        {
            get
            {
                int total = 0;
                foreach (Period period in _periods)
                    total += period.Workload;

                return total;
            }
        }

        public int ClockHours
        {
            get
            {
                int total = 0;
                foreach (Period period in _periods)
                    total += period.ClockHours;

                return total;
            }
        }
    }
}