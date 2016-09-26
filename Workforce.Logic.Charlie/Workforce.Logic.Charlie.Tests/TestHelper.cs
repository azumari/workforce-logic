using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.TransferModels;
using Xunit;

namespace Workforce.Logic.Charlie.Tests
{
    public class TestHelper
    {
        #region test inserts

        private readonly LogicHelper logicHelper = new LogicHelper();

        /// <summary>
        ///  Test method to insert location
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_InsertLocation()
        {
            var locDto = new LocationDto()
            {
                Address = "400 Random Road, Anywhere, Anystate",
                StopName = "Somewhere",
                Latitude = 30,
                Longitude = 30
            };
            bool passed = await logicHelper.InsertLocation(locDto);
            Assert.True(passed);
        }

        /// <summary>
        /// test method to insert ride (positive)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_InsertRide()
        {
            var rideDto = new RideDto()
            {
                DepartureLoc = 19,
                DestinationLoc = 20,
                DepartureTime = new DateTime(2016,9,27,15,45,0),
                AssociateEmail = "me@iamsocool.com",
                AssociateFirst = "David",
                AssociateLast = "Bowie",
                SeatsAvailable = 3
            };
            bool passed = await logicHelper.InsertRide(rideDto);
            Assert.True(passed);
        }

        /// <summary>
        /// test method to insert ride (negative)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_InsertRide2()
        {
            var rideDto = new RideDto()
            {
                DepartureLoc = 300,
                DestinationLoc = 30,
                DepartureTime = new DateTime(2016, 9, 27, 15, 45, 0),
                AssociateEmail = "me@iamsocool.com",
                AssociateFirst = "David",
                AssociateLast = "Bowie",
                SeatsAvailable = 3
            };
            bool passed = await logicHelper.InsertRide(rideDto);
            Assert.True(!passed);
        }

        /// <summary>
        /// test method to insert request (positive)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_InsertRequest()
        {
            var reqDto = new RequestDto()
            {
                DepartureLoc = 18,
                DestinationLoc = 30,
                DepartureTime = new DateTime(2016, 9, 27, 15, 45, 0),
                AssociateEmail = "me@iamsocool.com",
                AssociateFirst = "David",
                AssociateLast = "Bowie"
            };
            bool passed = await logicHelper.InsertRequest(reqDto);
            Assert.True(passed);
        }

        /// <summary>
        /// test method to insert request (negative)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_InsertRequest2()
        {
            var reqDto = new RequestDto()
            {
                DepartureLoc = 1900,
                DestinationLoc = 30,
                DepartureTime = new DateTime(2016, 9, 27, 15, 45, 0),
                AssociateEmail = "me@iamsocool.com",
                AssociateFirst = "David",
                AssociateLast = "Bowie"
            };
            bool passed = await logicHelper.InsertRequest(reqDto);
            Assert.True(!passed);
        }
        #endregion

        #region test deletes

        /// <summary>
        /// test method to delete location (positive)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_DeleteLocation()
        {
            var locDto = new LocationDto()
            {
                LocationId = 37,
                Latitude = 0,
                Longitude = 0,
                Address = "",
                StopName = ""

            };
            bool passed = await logicHelper.DeleteLocation(locDto);
            Assert.True(passed);
        }

        /// <summary>
        /// test method to delete location (negative)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_DeleteLocation2()
        {
            var locDto = new LocationDto()
            {
                LocationId = 370,
                Latitude = 0,
                Longitude = 0,
                Address = "",
                StopName = ""

            };
            bool passed = await logicHelper.DeleteLocation(locDto);
            Assert.True(!passed);
        }

        #endregion

    }
}
