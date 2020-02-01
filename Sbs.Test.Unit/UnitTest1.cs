using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SbsWeb.Data;

namespace SbsLib.Test.Unit
{
    [TestClass]
    public class UnitTest1
    {
        public const string TotallyRandomTextValue = "TotallyRandomTextValue";

        [TestMethod]
        public void Test_Printing()
        {
            var b = new Board(TotallyRandomTextValue,TotallyRandomTextValue);
            foreach (var number in b.RowNumbers)
            {
                Console.Write($"|   {number}   |");
            }
        }

        [TestMethod]
        public void Generate_Numbers_Returns_Array()
        {
            var b = new Board(TotallyRandomTextValue, TotallyRandomTextValue);
            for (int i = 0; i < 1000; i++)
            {
                var result = b.GenerateNumbers();
                result.Length.Should().Be(10);
            }
        }

        [TestMethod]
        public void Generate_Numbers_Returns_Array_With_Each_Number_Used_Only_Once()
        {
            var b = new Board(TotallyRandomTextValue, TotallyRandomTextValue);
            for (int i = 0; i < 1000; i++)
            {
                var result = b.GenerateNumbers();
                var groupedResult = result.GroupBy(i1 => i1);
                foreach (var g in groupedResult)
                {
                    g.ToList().Count.Should().Be(1);
                }
            }
        }
    }
}
