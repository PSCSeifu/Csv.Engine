using Csv.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.Test
{

    public class CsvLinesplitterTests : IClassFixture<CsvLineSplitter>
    {
        #region " SET UP "

        private static ICsvLineSplitter _CsvLinesplitter;

        public CsvLinesplitterTests(CsvLineSplitter CsvLinesplitter)
        {
            _CsvLinesplitter = CsvLinesplitter;
        }

        #endregion

        #region " CSV Split"

        [Fact]
        public void CsvSplit_CorrectCsvString_IsSplitIntoStringList()
        {
            //Arrange
            string source = "\"AccountOfficeReference\",\"Address1\",\"Address2\",\"Address3\",\"Address4\",\"Address5\",\"BacsReferenceNo\",\"BankAccountName\",\"BankAccountNo\",\"BankBranch\",\"BankName\",\"BankSortCode\",\"CompanyName\",\"CompanyNo\",\"CompanyWeeks\",\"FourWeeklyDivisor\",\"HourlyDivisor\",\"MonthlyDivisor\",\"PayFrequency\",\"PeriodsPerYear\",\"QuarterlyDivisor\",\"TaxDistrict\",\"TaxOfficeNo\",\"TaxReference\",\"TwoWeeklyDivisor\",\"WeeklyDivisor\",\"WebSystemType\",\"AdditionalReports\",\"EmailPayslips\",\"EmailReports\",\"OutputMethod\",\"P11D\",\"PaidByBacs\",\"PayByDirectDebit\",\"PayDay\",\"PensionByWeb\",\"PostMethod\",\"SecondaryBacs\",\"PrintReports\",\"PrintEEsPayslip\",\"PrintERsPayslip\",\"NormalPayDay\",\"OrganisationName\",\"EmployeeNoFormat\",\"PayslipERsPension1\",\"PayslipERsPension2\",\"PrintPaymentDate\",\"OmniSlip\"";
            List<string> expectedList =
                new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3", "Address4", "Address5", "BacsReferenceNo", "BankAccountName", "BankAccountNo", "BankBranch", "BankName", "BankSortCode", "CompanyName", "CompanyNo", "CompanyWeeks", "FourWeeklyDivisor", "HourlyDivisor", "MonthlyDivisor", "PayFrequency", "PeriodsPerYear", "QuarterlyDivisor", "TaxDistrict", "TaxOfficeNo", "TaxReference", "TwoWeeklyDivisor", "WeeklyDivisor", "WebSystemType", "AdditionalReports", "EmailPayslips", "EmailReports", "OutputMethod", "P11D", "PaidByBacs", "PayByDirectDebit", "PayDay", "PensionByWeb", "PostMethod", "SecondaryBacs", "PrintReports", "PrintEEsPayslip", "PrintERsPayslip", "NormalPayDay", "OrganisationName", "EmployeeNoFormat", "PayslipERsPension1", "PayslipERsPension2", "PrintPaymentDate", "OmniSlip" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, true, true, ',', '"');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }
        
        [Fact]
        public void CsvSplit_EmptyString_ReturnsEmptyCollection()
        {
            //Arrange
            string source = "";
            List<string> expectedList = new List<string>();
            //Act
            var result = _CsvLinesplitter.CsvSplit(source, true, true, ',', '"');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_CsvLinesBelow3Chars_ReturnsEmptyCollection()
        {
            //Arrange
            string source = @"ab";
                 List<string> expectedList =   new List<string>();
            //Act
            var result = _CsvLinesplitter.CsvSplit(source, true, true, ',', '"');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_SepratorInsideQuotes_ReturnsSepratorAsPartOfNormalString()
        {
            //Arrange
            string source = "*data1*,*data2,data2*,*data3*";
            List<string> expectedList = new List<string>() {"data1","data2,data2","data3" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, ',', '*');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_OneDataItemOnly_ReturnsOneCollectionItem()
        {
            //Arrange
            string source = "*data1*";
            List<string> expectedList = new List<string>() { "data1"};

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, ';', '*');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_EmptyDataItemsCsvLines_ReturnsEmptyDataItems()
        {
            //Arrange
            string source = "**,**,**";
            List<string> expectedList = new List<string>() { "", "", "" };

            //Act
            //Act
            var result = _CsvLinesplitter.CsvSplit(source, ',', '*');

            //Assert
            result.Should().BeEquivalentTo(expectedList);            
        }
        #endregion

        #region " Separator Tests "

        [Fact]
        public void CsvSplit_WrongSeparatorCsvString_ReturnsEmptyCollection()
        {
            //Arrange
            string source = "AccountOfficeReference:Address1:Address2";
            List<string> expectedList = new List<string>();

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, true, true, '%', '"');

            //Assert            
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_SeparatorNotGivenAndCommaSeparatedCsvLines_UsesCommaAsDefaultSeparator()
        {
            //Arrange
            string source = "\"AccountOfficeReference\",\"Address1\",\"Address2\",\"Address3\",\"Address4\",\"Address5\",\"BacsReferenceNo\",\"BankAccountName\",\"BankAccountNo\",\"BankBranch\",\"BankName\",\"BankSortCode\",\"CompanyName\",\"CompanyNo\",\"CompanyWeeks\",\"FourWeeklyDivisor\",\"HourlyDivisor\",\"MonthlyDivisor\",\"PayFrequency\",\"PeriodsPerYear\",\"QuarterlyDivisor\",\"TaxDistrict\",\"TaxOfficeNo\",\"TaxReference\",\"TwoWeeklyDivisor\",\"WeeklyDivisor\",\"WebSystemType\",\"AdditionalReports\",\"EmailPayslips\",\"EmailReports\",\"OutputMethod\",\"P11D\",\"PaidByBacs\",\"PayByDirectDebit\",\"PayDay\",\"PensionByWeb\",\"PostMethod\",\"SecondaryBacs\",\"PrintReports\",\"PrintEEsPayslip\",\"PrintERsPayslip\",\"NormalPayDay\",\"OrganisationName\",\"EmployeeNoFormat\",\"PayslipERsPension1\",\"PayslipERsPension2\",\"PrintPaymentDate\",\"OmniSlip\"";
            List<string> expectedList = new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3", "Address4", "Address5", "BacsReferenceNo", "BankAccountName", "BankAccountNo", "BankBranch", "BankName", "BankSortCode", "CompanyName", "CompanyNo", "CompanyWeeks", "FourWeeklyDivisor", "HourlyDivisor", "MonthlyDivisor", "PayFrequency", "PeriodsPerYear", "QuarterlyDivisor", "TaxDistrict", "TaxOfficeNo", "TaxReference", "TwoWeeklyDivisor", "WeeklyDivisor", "WebSystemType", "AdditionalReports", "EmailPayslips", "EmailReports", "OutputMethod", "P11D", "PaidByBacs", "PayByDirectDebit", "PayDay", "PensionByWeb", "PostMethod", "SecondaryBacs", "PrintReports", "PrintEEsPayslip", "PrintERsPayslip", "NormalPayDay", "OrganisationName", "EmployeeNoFormat", "PayslipERsPension1", "PayslipERsPension2", "PrintPaymentDate", "OmniSlip" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source);

            //Assert
            result.Should().BeEquivalentTo(expectedList);

        }

        [Fact]
        public void CsvSplit_SeparatorNotGivenAndNonCommaCsvLines_ReturnsEmptyCollection()
        {
            //Arrange
            string source = "AccountOfficeReference;Address1;Address2;Address3;Address4";
            List<string> expectedList =  new List<string>();
        
            //Act
            var result = _CsvLinesplitter.CsvSplit(source);

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_QuoteInsideItem_ReturnsSepratorAsPartOfNormalString()
        {
            //Arrange
            string source = "*data1*,*data2*data2*,*data3*";
            List<string> expectedList = new List<string>() { "data1", "data2*data2", "data3" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, ',', '*');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }
        #endregion

        #region " Quote Tests "

        [Fact]
        public void CsvSplit_NoQuoteCharGiven_UsesDoubleQuoteAsQuote()
        {
            //Arrange
            string source = "\"AccountOfficeReference\",\"Address1\",\"Address2\",\"Address3\",\"Address4\",\"Address5\",\"BacsReferenceNo\",\"BankAccountName\",\"BankAccountNo\",\"BankBranch\",\"BankName\",\"BankSortCode\",\"CompanyName\",\"CompanyNo\",\"CompanyWeeks\",\"FourWeeklyDivisor\",\"HourlyDivisor\",\"MonthlyDivisor\",\"PayFrequency\",\"PeriodsPerYear\",\"QuarterlyDivisor\",\"TaxDistrict\",\"TaxOfficeNo\",\"TaxReference\",\"TwoWeeklyDivisor\",\"WeeklyDivisor\",\"WebSystemType\",\"AdditionalReports\",\"EmailPayslips\",\"EmailReports\",\"OutputMethod\",\"P11D\",\"PaidByBacs\",\"PayByDirectDebit\",\"PayDay\",\"PensionByWeb\",\"PostMethod\",\"SecondaryBacs\",\"PrintReports\",\"PrintEEsPayslip\",\"PrintERsPayslip\",\"NormalPayDay\",\"OrganisationName\",\"EmployeeNoFormat\",\"PayslipERsPension1\",\"PayslipERsPension2\",\"PrintPaymentDate\",\"OmniSlip\"";

            //Act
            var result = _CsvLinesplitter.CsvSplit(source).Count();

            //Assert
            result.Should().Be(48);

        }

        [Fact]
        public void CsvSplit_NoQuoteGivenAndDoubleQuoteCsvLines_UsesDoubleQuoteAsDefault()
        {
            //Arrange                     
            string source = "\"AccountOfficeReference\",\"Address1\",\"Address2\",\"Address3\",\"Address4\",\"Address5\"";
            List<string> expectedList =
                new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3", "Address4", "Address5" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source);

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_NoQuoteGivenAndNonDoubleQuoteCsvLines_ReturnsNonDoubleQuotedItems()
        {
            //Arrange                     
            string source = "?AccountOfficeReference?,?Address1?,?Address2?,?Address3?,?Address4?,?Address5?,?BacsReferenceNo?,?BankAccountName?,?BankAccountNo?,?BankBranch?,?BankName?,?BankSortCode?,?CompanyName?,?CompanyNo?,?CompanyWeeks?,?FourWeeklyDivisor?,?HourlyDivisor?,?MonthlyDivisor?,?PayFrequency?,?PeriodsPerYear?,?QuarterlyDivisor?,?TaxDistrict?,?TaxOfficeNo?,?TaxReference?,?TwoWeeklyDivisor?,?WeeklyDivisor?,?WebSystemType?,?AdditionalReports?,?EmailPayslips?,?EmailReports?,?OutputMethod?,?P11D?,?PaidByBacs?,?PayByDirectDebit?,?PayDay?,?PensionByWeb?,?PostMethod?,?SecondaryBacs?,?PrintReports?,?PrintEEsPayslip?,?PrintERsPayslip?,?NormalPayDay?,?OrganisationName?,?EmployeeNoFormat?,?PayslipERsPension1?,?PayslipERsPension2?,?PrintPaymentDate?,?OmniSlip?";
            List<string> expectedList = new List<string>() { "?AccountOfficeReference?", "?Address1?", "?Address2?", "?Address3?", "?Address4?", "?Address5?", "?BacsReferenceNo?", "?BankAccountName?", "?BankAccountNo?", "?BankBranch?", "?BankName?", "?BankSortCode?", "?CompanyName?", "?CompanyNo?", "?CompanyWeeks?", "?FourWeeklyDivisor?", "?HourlyDivisor?", "?MonthlyDivisor?", "?PayFrequency?", "?PeriodsPerYear?", "?QuarterlyDivisor?", "?TaxDistrict?", "?TaxOfficeNo?", "?TaxReference?", "?TwoWeeklyDivisor?", "?WeeklyDivisor?", "?WebSystemType?", "?AdditionalReports?", "?EmailPayslips?", "?EmailReports?", "?OutputMethod?", "?P11D?", "?PaidByBacs?", "?PayByDirectDebit?", "?PayDay?", "?PensionByWeb?", "?PostMethod?", "?SecondaryBacs?", "?PrintReports?", "?PrintEEsPayslip?", "?PrintERsPayslip?", "?NormalPayDay?", "?OrganisationName?", "?EmployeeNoFormat?", "?PayslipERsPension1?", "?PayslipERsPension2?", "?PrintPaymentDate?", "?OmniSlip?" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source,',');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }
        #endregion

        #region " Strip Quote Tests "

        [Fact]
        public void CsvSplit_NonDoubleQuoteParameterGiven_StripsUsingGivenQuotechar()
        {
            //Arrange                     
            string source = "?AccountOfficeReference?,?Address1?,?Address2?,?Address3?,?Address4?,?Address5?,?BacsReferenceNo?,?BankAccountName?,?BankAccountNo?,?BankBranch?,?BankName?,?BankSortCode?,?CompanyName?,?CompanyNo?,?CompanyWeeks?,?FourWeeklyDivisor?,?HourlyDivisor?,?MonthlyDivisor?,?PayFrequency?,?PeriodsPerYear?,?QuarterlyDivisor?,?TaxDistrict?,?TaxOfficeNo?,?TaxReference?,?TwoWeeklyDivisor?,?WeeklyDivisor?,?WebSystemType?,?AdditionalReports?,?EmailPayslips?,?EmailReports?,?OutputMethod?,?P11D?,?PaidByBacs?,?PayByDirectDebit?,?PayDay?,?PensionByWeb?,?PostMethod?,?SecondaryBacs?,?PrintReports?,?PrintEEsPayslip?,?PrintERsPayslip?,?NormalPayDay?,?OrganisationName?,?EmployeeNoFormat?,?PayslipERsPension1?,?PayslipERsPension2?,?PrintPaymentDate?,?OmniSlip?";
            List<string> expectedList = new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3", "Address4", "Address5", "BacsReferenceNo", "BankAccountName", "BankAccountNo", "BankBranch", "BankName", "BankSortCode", "CompanyName", "CompanyNo", "CompanyWeeks", "FourWeeklyDivisor", "HourlyDivisor", "MonthlyDivisor", "PayFrequency", "PeriodsPerYear", "QuarterlyDivisor", "TaxDistrict", "TaxOfficeNo", "TaxReference", "TwoWeeklyDivisor", "WeeklyDivisor", "WebSystemType", "AdditionalReports", "EmailPayslips", "EmailReports", "OutputMethod", "P11D", "PaidByBacs", "PayByDirectDebit", "PayDay", "PensionByWeb", "PostMethod", "SecondaryBacs", "PrintReports", "PrintEEsPayslip", "PrintERsPayslip", "NormalPayDay", "OrganisationName", "EmployeeNoFormat", "PayslipERsPension1", "PayslipERsPension2", "PrintPaymentDate", "OmniSlip" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, ',', '?');
            var count = _CsvLinesplitter.CsvSplit(source, ',', '?').Count();

            //Assert
            result.Should().BeEquivalentTo(expectedList);
            count.Should().Be(48);

        }

        [Fact]
        public void CsvSplit_IncorrectQuoteParamGiven_CollectionItemsNotStriped()
        {
            //Arrange
            string source = "?AccountOfficeReference?,?Address1?,?Address2?,?Address3?,?Address4?";
            List<string> expectedList = new List<string>() { "?AccountOfficeReference?", "?Address1?", "?Address2?", "?Address3?", "?Address4?" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source, ',', ';');

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        #endregion

        #region " Trim Source line Tests "
        [Fact]
        public void CsvSplit_WhiteSpaceIAtEndofCsvLines_TrimsCsvLines()
        {
            //Arrange
            string source = "AccountOfficeReference,Address1,Address2,Address3   ";
            List<string> expectedList =
                new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source);

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_WhiteSpaceIAtStartofCsvLines_TrimsCsvLines()
        {
            //Arrange             
            string source = "     AccountOfficeReference,Address1,Address2,Address3";
            List<string> expectedList =
                new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3" };

            //Act
            var result = _CsvLinesplitter.CsvSplit(source);

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }
        #endregion

        #region " Trims Collection Items Test "
        [Fact]
        public void CsvSplit_TrimParameterNotGivenNotQuotedCsvLines_TrimsItemsByDefault()
        {
            //Arrange           
            string source = "    AccountOfficeReference, Address1 ,  Address2  ,   Address3";
            List<string> expectedList = new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3" };
            
            //Act
            var result = _CsvLinesplitter.CsvSplit(source,',',char.MinValue);

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void CsvSplit_TrimParameterNotGivenQuotedCsvLines_TrimsItemsByDefault()
        {
            //Arrange
            string source = "\"AccountOfficeReference  \",\"  Address1\",\"Address2        \",\"Address3\",\"      Address4\",\"Address5\"";
            List<string> expectedList = new List<string>() { "AccountOfficeReference", "Address1", "Address2", "Address3", "Address4", "Address5" };
            
            //Act
            var result = _CsvLinesplitter.CsvSplit(source);

            //Assert
            result.Should().BeEquivalentTo(expectedList);
        }
                
        #endregion
    }
}
