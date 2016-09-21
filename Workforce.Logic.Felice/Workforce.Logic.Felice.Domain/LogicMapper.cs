using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain
{
   class LogicMapper
   {
      private readonly MapperConfiguration traineeMapper = new MapperConfiguration(t => t.CreateMap<TraineeDao, AssociateDto>().ForMember(t1 => t1.Gender, opt => opt.MapFrom(t2 => t2.GenderID.ToString())));
      private readonly MapperConfiguration instructorMapper = new MapperConfiguration(i => i.CreateMap<InstructorDao, InstructorDto>());
      private readonly MapperConfiguration genderMapper = new MapperConfiguration(g => g.CreateMap<GenderDao, GenderDto>());
      private readonly MapperConfiguration batchMapper = new MapperConfiguration(b => b.CreateMap<BatchDao, BatchDto>());
      private readonly MapperConfiguration addressMapper = new MapperConfiguration(a => a.CreateMap<AddressDao, AddressDto>());


      private readonly MapperConfiguration traineeReverseMapper = new MapperConfiguration(t => t.CreateMap<AssociateDto, TraineeDao>().ForMember(t2 => t2.GenderID, m => m.MapFrom(t1 => t1.Gender)));
      private readonly MapperConfiguration instructorReverseMapper = new MapperConfiguration(i => i.CreateMap<InstructorDto, InstructorDao>());
      private readonly MapperConfiguration genderReverseMapper = new MapperConfiguration(g => g.CreateMap<GenderDto, GenderDao>());
      private readonly MapperConfiguration batchReverseMapper = new MapperConfiguration(b => b.CreateMap<BatchDto, BatchDao>());
      private readonly MapperConfiguration addressReverseMapper = new MapperConfiguration(a => a.CreateMap<AddressDto, AddressDao>());

      #region MapToBusiness (Data Layer to Logic Layer)
      /// <summary>
      /// The purpose of this method is to link the Dao of the Data Layer to the Dto of the Logic Layer
      /// </summary>
      public AssociateDto MapToBusiness(TraineeDao t)
      {
         var mapper = traineeMapper.CreateMapper();

         return mapper.Map<AssociateDto>(t);
      }

      /// <summary>
      /// The purpose of this method is to link the Dao of the Data Layer to the Dto of the Logic Layer
      /// </summary>
      public InstructorDto MapToBusiness(InstructorDao i)
      {
         var mapper = instructorMapper.CreateMapper();

         return mapper.Map<InstructorDto>(i);
      }

      /// <summary>
      /// The purpose of this method is to link the Dao of the Data Layer to the Dto of the Logic Layer
      /// </summary>
      public GenderDto MapToBusiness(GenderDao g)
      {
         var mapper = genderMapper.CreateMapper();

         return mapper.Map<GenderDto>(g);
      }

      /// <summary>
      /// The purpose of this method is to link the Dao of the Data Layer to the Dto of the Logic Layer
      /// </summary>
      public BatchDto MapToBusiness(BatchDao b)
      {
         var mapper = batchMapper.CreateMapper();

         return mapper.Map<BatchDto>(b);
      }

      /// <summary>
      /// The purpose of this method is to link the Dao of the Data Layer to the Dto of the Logic Layer
      /// </summary>
      public AddressDto MapToBusiness(AddressDao a)
      {
         var mapper = addressMapper.CreateMapper();

         return mapper.Map<AddressDto>(a);
      }
      #endregion

      #region MapToService (Logic Layer to Data Layer)
      /// <summary>
      /// The purpose of this method is to link the Dto of the Logic Layer to the Dao of the Data Layer
      /// </summary>
      public TraineeDao MapToService(AssociateDto t)
      {
         var mapper = traineeReverseMapper.CreateMapper();

         return mapper.Map<TraineeDao>(t);
      }

      /// <summary>
      /// The purpose of this method is to link the Dto of the Logic Layer to the Dao of the Data Layer
      /// </summary>
      public InstructorDao MapToService(InstructorDto i)
      {
         var mapper = instructorReverseMapper.CreateMapper();

         return mapper.Map<InstructorDao>(i);
      }

      /// <summary>
      /// The purpose of this method is to link the Dto of the Logic Layer to the Dao of the Data Layer
      /// </summary>
      public GenderDao MapToService(GenderDto g)
      {
         var mapper = genderReverseMapper.CreateMapper();

         return mapper.Map<GenderDao>(g);
      }

      /// <summary>
      /// The purpose of this method is to link the Dto of the Logic Layer to the Dao of the Data Layer
      /// </summary>
      public BatchDao MapToService(BatchDto b)
      {
         var mapper = batchReverseMapper.CreateMapper();

         return mapper.Map<BatchDao>(b);
      }

      /// <summary>
      /// The purpose of this method is to link the Dto of the Logic Layer to the Dao of the Data Layer
      /// </summary>
      public AddressDao MapToService(AddressDto a)
      {
         var mapper = addressReverseMapper.CreateMapper();

         return mapper.Map<AddressDao>(a);
      }
      #endregion
   }
}
