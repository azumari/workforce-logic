using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain
{
   public class CoreValidator
   {
      public bool ValidateRequiredString(string newString, int maxLength)
      {
         if (String.IsNullOrWhiteSpace(newString) || newString.Length > maxLength)
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      public bool ValidateStandardString(string newString)
      {
         if (newString == String.Empty)
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      public bool ValidateInt(int newInt)
      {
         if (newInt < 0)
         {
            return false;
         }

         return true;
      }

      public bool ValidateNullableKey(Nullable<int> nullableInt)
      {
         if (nullableInt == null || nullableInt >= 0)
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      public bool ValidateBool(bool? newBool)
      {
         if (newBool != true && newBool != false && newBool != null)
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      public bool ValidateDate(DateTime? newDate)
      {
         DateTime test;

         if (newDate == null)
         {
            return true;
         }
         else if (DateTime.TryParse(newDate.ToString(), out test))
         {
            return true;
         }
         else
         {
            return false;
         }
      }
   }
}