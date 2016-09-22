using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   class BatchDto
   {
      private int _BatchID;
      public int BatchID
      {
         get { return _BatchID; }
         set
         {
            if (value > 0)
            {
               _BatchID = value;
            }
            else throw new ArgumentException("You have entered an invalid integer for BatchID");
         }
      }

      private string _Name;
      public string Name
      {
         get { return _Name; }
         set
         {
            if ( !String.IsNullOrWhiteSpace(value))
            {
               int count = 0;
               foreach (char c in value)
                  count++;
               if (count <= 50)
                  _Name = value;
               else throw new ArgumentException("The batch name cannot be more than 50 characters", "Name");
            }
            else
            {
               throw new ArgumentException("The batch name is required and cannot be empty");
            }
         }
      }

      private int _InstructorID;
      public int InstructorID
      {
         get { return _InstructorID; }
         set
         {
            if (value > 0)
            {
               _InstructorID = value;
            }
            else throw new ArgumentException("You have entered an invalid integer for InstructorID");
         }
      }

      private DateTime _StartDate;
      public DateTime StartDate
      {
         get { return _StartDate; }
         set
         {
            if (!DateTime.TryParse(value.ToString(), out _StartDate) && value >= DateTime.UtcNow)
               throw new ArgumentException("The Start Date is invalid");
            else _StartDate = value;
         }
      }

      private DateTime _EndDate;
      public DateTime EndDate
      {
         get { return _EndDate; }
         set
         {
            if (!DateTime.TryParse(value.ToString(), out _EndDate) && value >= DateTime.UtcNow)
               throw new ArgumentException("The End Date is invalid");
            else _StartDate = value;
         }
      }
   }
}