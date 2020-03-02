using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class WorkerInfo
    {
        public WorkerInfo()
        {

        }

        public WorkerInfo(string firstName, string lastName, int code, DateTime birthDay, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalCode = code;
            Birthday = birthDay;
            HomeAddress = address;
            WorkerStatus = Status.Active;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PersonalCode { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string HomeAddress { get; set; }
        [Required]
        public Status WorkerStatus { get; set; }
    }
}
