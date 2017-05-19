using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.Test.UnitTests.Csv.Parse
{
    public class CsvParseTests
    {
        #region " CSV Split"
                
       //[Fact]
        public void CsvSplit_CorrectCsvString_IsSplitIntoStringList()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void CsvSplit_InCorrectlyFormattedCsvString_ReturnsEmptyStringList()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void CsvSplit_EmptyString__ReturnsEmptyStringList()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void CsvSplit_NoSeparatorGiven_UsesCommaAsSeprator()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void CsvSplit_NoQuoteGiven_UsesDoubleQuoteAsQuote()
        {
            //Arrange


            //Act


            //Assert

        }

        #endregion

        #region " TransformStringToType "

       //[Fact]
        public void TransformStringToType_NullInputString_ReturnsNullString()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void TransformStringToType_NullableIntegerNullString_ReturnsNullInteger()
        {
            //Arrange


            //Act


            //Assert

        }

        #endregion

        #region "  TransformListStringToObject "

       //[Fact]
        public void TransformListStringToObject_CorrectFieldsAndData_ConstructsCorrectObject()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void TransformListStringToObject_NullFields_ReturnsNullObject()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void TransformListStringToObject_DataListHasZeroElements_ReturnsNullObject()
        {
            //Arrange


            //Act


            //Assert

        }

       //[Fact]
        public void TransformListStringToObject_FieldAndDataCountMismatch_ReturnsNullObject()
        {
            //Arrange


            //Act


            //Assert

        }


       //[Fact]
        public void TransformListStringToObject_ObjectAndFieldsMismatch_ReturnsNullForMissingProperty()
        {
            //Arrange


            //Act


            //Assert

        }

        #endregion
    }
}
