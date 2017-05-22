using Csv.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.Test.UnitTests.Csv.Common
{
    public class CsvLinesMakerTests : IClassFixture<CsvLinesMaker>
    {
        #region "  SET UP "
        private static ICsvLinesMaker _CsvLinesMaker;

        public CsvLinesMakerTests(CsvLinesMaker CsvLinesMaker)
        {
            _CsvLinesMaker = CsvLinesMaker;
        }
        #endregion

        #region "  Csv Make Tests "

        [Fact]
        public void MakeCsvLines_CorrectStringCollection_CreatesDefaultCsvLines()
        {
            //Arrange
            List<string> source = new List<string>()
            { "AccountOfficeReference", "Address1", "Address2", "Address3", "Address4", "Address5", "BacsReferenceNo", "BankAccountName", "BankAccountNo", "BankBranch", "BankName", "BankSortCode", "CompanyName", "CompanyNo", "CompanyWeeks", "FourWeeklyDivisor", "HourlyDivisor", "MonthlyDivisor", "PayFrequency", "PeriodsPerYear", "QuarterlyDivisor", "TaxDistrict", "TaxOfficeNo", "TaxReference", "TwoWeeklyDivisor", "WeeklyDivisor", "WebSystemType", "AdditionalReports", "EmailPayslips", "EmailReports", "OutputMethod", "P11D", "PaidByBacs", "PayByDirectDebit", "PayDay", "PensionByWeb", "PostMethod", "SecondaryBacs", "PrintReports", "PrintEEsPayslip", "PrintERsPayslip", "NormalPayDay", "OrganisationName", "EmployeeNoFormat", "PayslipERsPension1", "PayslipERsPension2", "PrintPaymentDate", "OmniSlip"  };
            string expectedString = "\"AccountOfficeReference\",\"Address1\",\"Address2\",\"Address3\",\"Address4\",\"Address5\",\"BacsReferenceNo\",\"BankAccountName\",\"BankAccountNo\",\"BankBranch\",\"BankName\",\"BankSortCode\",\"CompanyName\",\"CompanyNo\",\"CompanyWeeks\",\"FourWeeklyDivisor\",\"HourlyDivisor\",\"MonthlyDivisor\",\"PayFrequency\",\"PeriodsPerYear\",\"QuarterlyDivisor\",\"TaxDistrict\",\"TaxOfficeNo\",\"TaxReference\",\"TwoWeeklyDivisor\",\"WeeklyDivisor\",\"WebSystemType\",\"AdditionalReports\",\"EmailPayslips\",\"EmailReports\",\"OutputMethod\",\"P11D\",\"PaidByBacs\",\"PayByDirectDebit\",\"PayDay\",\"PensionByWeb\",\"PostMethod\",\"SecondaryBacs\",\"PrintReports\",\"PrintEEsPayslip\",\"PrintERsPayslip\",\"NormalPayDay\",\"OrganisationName\",\"EmployeeNoFormat\",\"PayslipERsPension1\",\"PayslipERsPension2\",\"PrintPaymentDate\",\"OmniSlip\"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source);

            //Assert
            result.Should().Be(expectedString);
        }

        [Fact]
        public void MakeCsvLines_EmptyCollection_ReturnsEmptyString()
        {
            //Arrange
            List<string> source = new List<string>();
            string expectedString = "";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source);

            //Assert
            result.Should().Be(expectedString);
        }

        [Fact]
        public void MakeCsvLines_EmptyStringCollection_ReturnsEmptyQuotedSepratedCsvLines()
        {
            //Arrange
            List<string> source = new List<string>() { "", "", "" };
            string expectedString = "\"\",\"\",\"\"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source);

            //Assert
            result.Should().Be(expectedString);
        }

        [Fact]
        public void MakeCsvLines_OneDataItemOnly_ReturnsOneItemCsvLines()
        {
            //Arrange
            List<string> source = new List<string>() { "singleItem" };
            string expectedString = "\"singleItem\"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source);

            //Assert
            result.Should().Be(expectedString);
        }

        #endregion

        #region " Separator Tests "

        [Fact]
        public void MakeCsvLines_NonCommaSeprator_UsesSepratorToDelimitCsvLines()
        {
            //Arrange
            List<string> source = new List<string>() { "data1", "data2", "data3" };
            string expectedString = "\"data1\";\"data2\";\"data3\"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source, ';');

            //Assert
            result.Should().Be(expectedString);
        }

        #endregion

        #region " Quote tests "

        [Fact]
        public void MakeCsvLines_NonDoubleQuoteChar_UsesQuoteToWrapCsvLinesItems()
        {
            //Arrange
            List<string> source = new List<string>() { "data1", "data2", "data3" };
            string expectedString = "?data1?,?data2?,?data3?";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source, ',', '?');

            //Assert
            result.Should().Be(expectedString);

        }

        [Fact]
        public void MakeCsvLines_PreDoubleQuotedItemsWithDoubleQuoteChar_ReturnsDoubleQuotedWrappedItems()
        {
            //Arrange
            List<string> source = new List<string>() { "\"data1\"", "\"data2\"", "\"data3\"" };
            string expectedString = "\"\"data1\"\",\"\"data2\"\",\"\"data3\"\"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source, ',', '"');

            //Assert
            result.Should().Be(expectedString);

        }
        #endregion

        #region " Trim Items Tests "

        [Fact]
        public void MakeCsvLines_UntrimedItemsTrimsetToTrue_ReturnsTrimmedItemsInCsvLines()
        {
            //Arrange
            List<string> source = new List<string>() { "  Trimmed1  ", " Trimmed2 ", "   Trimmed3   " };
            string expectedString = "\"Trimmed1\",\"Trimmed2\",\"Trimmed3\"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source, true, true, ',', '"');

            //Assert
            result.Should().Be(expectedString);
        }

        [Fact]
        public void MakeCsvLines_UntrimedItemsTrimsetToFalse_ReturnsUnTrimmedItemsInCsvLines()
        {
            //Arrange
            List<string> source = new List<string>() { "  notTrimmed1  ", " notTrimmed2 ", "   notTrimmed3   " };
            string expectedString = "\"  notTrimmed1  \",\" notTrimmed2 \",\"   notTrimmed3   \"";

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source, true, false, ',', '"');

            //Assert
            result.Should().Be(expectedString);
        }

        #endregion

        #region " Line Terminator tests"

        [Fact]
        public void MakeCsvLines_NewLineStringGivenAsLineterminator_TerminatesCsvLinesWithNewLineString()
        {
            //Arrange
            List<string> source = new List<string>() { "data1", "data2", "data3" };
            string expectedEndOfLine = Environment.NewLine;

            //Act
            var result = _CsvLinesMaker.MakeCsvLines(source, true, true, ',', '"', Environment.NewLine);
            string resultEndOfLine = $"{result[result.Length - 2].ToString()}{result[result.Length - 1]}";

            //Assert
            resultEndOfLine.Should().Be(expectedEndOfLine);
        }

        #endregion


    }
}
