﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Data
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset ApplicationDate
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }

        private bool _applicationSubmitted;
        public bool ApplicationSubmitted
        {
            get
            {

                return _applicationSubmitted;
            }
            set
            {
                if (ListOfJobs.Count == 0)
                    _applicationSubmitted = false;

            }
        }
        [Required]
        public string  ApplicantFirstName { get; set; }
        [Required]
        public string ApplicantLastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ApplicantEmail { get; set; }
        public virtual ICollection<Job> ListOfJobs { get; set; }

        public Applicant()
        {
            ListOfJobs = new HashSet<Job>();
        }

    }
}
