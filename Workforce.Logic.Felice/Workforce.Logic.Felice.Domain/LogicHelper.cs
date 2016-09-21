using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain
{
   class LogicHelper
   {
      private readonly DataContractClient client = new DataContractClient();
      private readonly LogicMapper logic = new LogicMapper();

      #region All Methods associated with 'Associate'
      #region All 'Get' methods for Associates
      /// <summary>
      /// This method returns all 'active' associates from within the database
      /// This method is also the 'Default' GET method called by the UI
      /// </summary>
      public async Task<List<AssociateDto>> GetAllActiveAssociates()
      {
         var associates = new List<AssociateDto>();
         var serviceAssociates = await client.GetTraineesAsync();
         var serviceGenders = await client.GetGendersAsync();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceAssociates)
         {
            if (item.Active == true) //this is to ensure that only the active members are pulled through
            {
               var par = logic.MapToBusiness(item); //this primes the data to be edited by the next set of codes

               par.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name; //this line converts the GenderID to GenderName for the UI
               associates.Add(par);
            }
         }
         return associates;
      }

      /// <summary>
      /// This method returns all 'deactive' associates from within the database 
      /// </summary>
      public async Task<List<AssociateDto>> GetAllDeactiveAssociates()
      {
         var associates = new List<AssociateDto>();
         var serviceAssociates = await client.GetTraineesAsync();
         var serviceGenders = await client.GetGendersAsync();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceAssociates)
         {
            if (item.Active == false)
            {
               var par = logic.MapToBusiness(item);

               par.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name;
               associates.Add(par);
            }
         }

         return associates;
      }

      /// <summary>
      /// This method returns ALL associates from within the database
      /// </summary>
      public async Task<List<AssociateDto>> GetAllAssociates()
      {
         var associates = new List<AssociateDto>();
         var serviceAssociates = await client.GetTraineesAsync();
         var serviceGenders = await client.GetGendersAsync();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceAssociates)
         {
            var par = logic.MapToBusiness(item);

            par.Gender = serviceGenders.FirstOrDefault(g => g.GenderID.Equals(item.GenderID)).Name;
            associates.Add(par);
         }
         return associates;
      }
      #endregion

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// Connects to the Data Layer to add a new associate to the database
      /// </summary>
      public int AddNewAssociate(AssociateDto associate)
      {
         var success = client.AddTrainee(logic.MapToService(associate));
         return success;
      }

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// Connects to the Data Layer to (de)activate existing associate within the database
      /// </summary>
      public bool ChangeActiveStatusOfAssociate(AssociateDto associate)
      {
         //client.___(logic.MapToService(associate)); this line is missing the name of the DAL associated function
         return true;
      }

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This method connects to the Data Access Layer and allows the user to Update existing associate information within the Database
      /// </summary>
      public bool UpdateAssociate(AssociateDto associate)
      {
         //reserved for code necessary to link to DAL
         return true;
      }
      #endregion

      #region All methods associated with 'Instructor'
      #region All 'Get' methods for Instructor
      /// <summary>
      /// This method returns all 'active' instructors from within the database
      /// This method is also the 'Default' GET method called by the UI
      /// </summary>
      public async Task<List<InstructorDto>> GetAllActiveInstructors()
      {
         var instructors = new List<InstructorDto>();
         var serviceInstructors = await client.GetInstructorsAsync();

         foreach (var item in serviceInstructors)
         {
            if (item.Active == true) instructors.Add(logic.MapToBusiness(item));
         }

         return instructors;
      }

      /// <summary>
      /// This method returns all 'deactive' instructors from within the database
      /// </summary>
      public async Task<List<InstructorDto>> GetAllDeactiveInstructors()
      {
         var instructors = new List<InstructorDto>();
         var serviceInstructors = await client.GetInstructorsAsync();

         foreach (var item in serviceInstructors)
         {
            if (item.Active == false) instructors.Add(logic.MapToBusiness(item));
         }

         return instructors;
      }

      /// <summary>
      /// This method returns ALL instructors from within the database
      /// </summary>
      public async Task<List<InstructorDto>> GetAllInstructors()
      {
         var instructors = new List<InstructorDto>();
         var serviceInstructors = await client.GetInstructorsAsync();

         foreach (var item in serviceInstructors)
         {
            instructors.Add(logic.MapToBusiness(item));
         }

         return instructors;
      }
      #endregion

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This methods connects to the Data Layer and allows the user to add a new instructor
      /// </summary>
      public bool AddNewInstructor(InstructorDto instructor)
      {
         //bool success = client.AddInstructor(logic.MapToService(instructor));
         return true;
      }

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This is the 'Delete' method that (de)activates an existing instructor within the database
      /// </summary>
      public bool ChangeActiveStatusOfInstructor(InstructorDto instructor)
      {
         //client.__(logic.MapToService(instructor)); this line is missing the name of the DAL associated function
         return true;
      }

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This method connects to the Data Access Layer and allows the user to Update existing instructor information within the Database
      /// </summary>
      public bool UpdateInstructor(InstructorDto instructor)
      {
         //reserved for code necessary to link to DAL
         return true;
      }
      #endregion

      #region All methods associated with 'Gender'
      /// <summary>
      /// This method is specifically for the Get request for Genders
      /// </summary>
      public async Task<List<GenderDto>> GetAllGenders()
      {
         var genders = new List<GenderDto>();
         var serviceGenders = await client.GetGendersAsync();

         foreach (var item in serviceGenders)
         {
            genders.Add(logic.MapToBusiness(item));
         }

         return genders;
      }
      #endregion

      #region All methods associated with 'Batch'
      #region All 'Get' methods for Batch
      /// <summary>
      /// This method returns all 'active' associates from within the database
      /// This method is also the 'Default' GET method called by the UI
      /// </summary>
      public async Task<List<BatchDto>> GetAllActiveBatches()
      {
         var batches = new List<BatchDto>();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceBatches)
         {
            if (item.Active == true) batches.Add(logic.MapToBusiness(item));
         }

         return batches;
      }

      /// <summary>
      /// This method returns all 'deactive' associates from within the database
      /// </summary>
      public async Task<List<BatchDto>> GetAllDeactiveBatches()
      {
         var batches = new List<BatchDto>();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceBatches)
         {
            if (item.Active == false) batches.Add(logic.MapToBusiness(item));
         }

         return batches;
      }

      /// <summary>
      /// This method returns ALL batches from within the database
      /// </summary>
      public async Task<List<BatchDto>> GetAllBatches()
      {
         var batches = new List<BatchDto>();
         var serviceBatches = await client.GetBatchesAsync();

         foreach (var item in serviceBatches)
         {
            batches.Add(logic.MapToBusiness(item));
         }

         return batches;
      }
      #endregion

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This method connects to the Data Layer and allows the user to add a new batch into the database
      /// </summary>
      public bool AddNewBatch(BatchDto batch)
      {
         //bool success = client.AddBatch(logic.MapToService(batch));
         return true;
      }

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This method is the 'Delete' method that (de)activates an existing batch from within the database
      /// </summary>
      public bool ChangeActiveStatusOfBatch(BatchDto batch)
      {
         //client.__(logic.MapToService(batch)); this line is missing the name of the DAL associated function
         return true;
      }

      /// <summary>
      /// This method is a failed method that needs to be reworked
      /// This method connects to the Data Access Layer and allows the user to Update existing batch information within the Database
      /// </summary>
      public bool UpdateBatch(BatchDto batch)
      {
         //reserved for code necessary to link to DAL
         return true;
      }
      #endregion

      #region All methods associated with 'Address'
      /// <summary>
      /// This is the standard 'Get' for Addresses
      /// </summary>
      public async Task<List<AddressDto>> GetAddresses()
      {
         var addresses = new List<AddressDto>();
         var serviceAssociates = await client.GetAddressesAsync();

         foreach (var item in serviceAssociates)
         {
            addresses.Add(logic.MapToBusiness(item));
         }
         return addresses;
      }
      #endregion
   }
}
