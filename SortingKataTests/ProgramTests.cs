using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace SortingKata.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        int[] arrEmpty = { };
        int[] arrSingleElement = { 3 };
        int[] arrTwoElement = { 7, 3 };
        int[] arrTen = { 9, 10, 11, 2, 1, 5, 6, 8, 7, 3 };
        int[] arrThree = { 8, 7, 3 };
        int[] arrMerge = { 11, 10, 9, 1, 2, 8, 9, 3, 4, 5, 22, 42 };
        int[] arrMerge2 = { 11, 10, 9, 1, 2, 3, 4, 5, 8, 9, 22, 42 };

        [TestMethod]
        public void TestEmptyArray()
        {
            Program.BubbleSort(arrEmpty);
            arrEmpty.Length.ShouldBe(0);
        }

        [TestMethod]
        public void TestSingleElementArray()
        {
            Program.BubbleSort(arrSingleElement);
            arrSingleElement[0].ShouldBe(3);
            arrSingleElement.Length.ShouldBe(1);
        }

        [TestMethod]
        public void TestTwoElementArray()
        {
            Program.BubbleSort(arrTwoElement);
            arrTwoElement[0].ShouldBe(3);
            arrTwoElement[1].ShouldBe(7);
            arrTwoElement.Length.ShouldBe(2);
        }

        [TestMethod]
        public void TestThreeElementArray()
        {
            Program.BubbleSort(arrThree);
            arrThree[0].ShouldBe(3);
            arrThree[1].ShouldBe(7);
            arrThree[2].ShouldBe(8);
            arrThree.Length.ShouldBe(3);
        }

        [TestMethod]
        public void TestTenElementArray()
        {
            Program.BubbleSort(arrTen);
            arrTen.ShouldBe(new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 11 });
            arrTen.Length.ShouldBe(10);
        }

        [TestMethod]
        public void TestTenElementArrayDescending()
        {
            Program.BubbleSort(arrTen, false);
            arrTen.ShouldBe(new int[] { 11, 10, 9, 8, 7, 6, 5, 3, 2, 1 });
            arrTen.Length.ShouldBe(10);
        }

        [TestMethod]
        public void TestOptimisations()
        {
            int[] arrOptimised = { 1, 2, 3, 4, 5 };
            Program.BubbleSort(arrOptimised).ShouldBe(4);
        }

        [TestMethod]
        public void TestInsertionEmptyArray()
        {
            Program.InsertionSort(arrEmpty);
            arrEmpty.Length.ShouldBe(0);
        }

        [TestMethod]
        public void TestInsertionTwoElementArray()
        {
            Program.InsertionSort(arrTwoElement);
            arrTwoElement[0].ShouldBe(3);
            arrTwoElement[1].ShouldBe(7);
            arrTwoElement.Length.ShouldBe(2);
        }

        [TestMethod]
        public void TestInsertionTenElementArray()
        {
            Program.InsertionSort(arrTen);
            arrTen.ShouldBe(new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 11 });
            arrTen.Length.ShouldBe(10);
        }

        [TestMethod]
        public void TestInsertionTenElementArrayDescending()
        {
            Program.InsertionSort(arrTen, false);
            arrTen.ShouldBe(new int[] { 11, 10, 9, 8, 7, 6, 5, 3, 2, 1 });
            arrTen.Length.ShouldBe(10);
        }

        [TestMethod]
        public void TestMerge()
        {
            Program.Merge(arrMerge, 3, 6, 9);
            arrMerge.ShouldBe(new int[] { 11, 10, 9, 1, 2, 3, 4, 5, 8, 9, 22, 42 });
            arrMerge.Length.ShouldBe(12);
        }

        [TestMethod]
        public void TestMergeWhen()
        {
            Program.Merge(arrMerge2, 3, 4, 9);
            arrMerge2.ShouldBe(new int[] { 11, 10, 9, 1, 2, 3, 4, 5, 8, 9, 22, 42 });
            arrMerge2.Length.ShouldBe(12);
        }

        [TestMethod]
        public void TestMergeWhenOneOfLeftSide()
        {
            int[] arrMerge3 = { 11, 1, 9, 10, 2 };
            Program.Merge(arrMerge3, 0, 0, 3);
            arrMerge3.ShouldBe(new int[] { 1, 9, 10, 11, 2 });
            arrMerge3.Length.ShouldBe(5);
        }

        [TestMethod]
        public void TestMergeWhenOneOnRightSide()
        {
            int[] arrMerge3 = { 1, 9, 10, 11, 2 };
            Program.Merge(arrMerge3, 0, 2, 3);
            arrMerge3.ShouldBe(new int[] { 1, 9, 10, 11, 2 });
            arrMerge3.Length.ShouldBe(5);
        }

        [TestMethod]
        public void TestMergeSortWithOddNumerOfElements()
        {
            int[] arrMergeTen = { 9, 10, 11, 2, 1, 5, 6, 8, 7, 3, 12 };
            Program.MergeSort(arrMergeTen);
            arrMergeTen.ShouldBe(new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 11, 12 });
            arrMergeTen.Length.ShouldBe(11);
        }

        [TestMethod]
        public void TestMergeSortWithTwoElements()
        {
            int[] arrMergeTen = { 10, 9 };
            Program.MergeSort(arrMergeTen);
            arrMergeTen.ShouldBe(new int[] {9, 10 });
            arrMergeTen.Length.ShouldBe(2);
        }

        [TestMethod]
        public void TestMergeSortWithEvenNumerOfElements()
        {
            int[] arrMergeTen = { 9, 10, 11, 2, 1, 5, 6, 8, 7, 3 };
            Program.MergeSort(arrMergeTen);
            arrMergeTen.ShouldBe(new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 11 });
            arrMergeTen.Length.ShouldBe(10);
        }

        [TestMethod]
        public void TestMergeSortWithOneElement()
        {
            int[] arrMergeTen = { 10 };
            Program.MergeSort(arrMergeTen);
            arrMergeTen.ShouldBe(new int[] { 10 });
            arrMergeTen.Length.ShouldBe(1);
        }

        [TestMethod]
        public void TestMergeSortWithZeroElements()
        {
            int[] arrMergeTen = { };
            Program.MergeSort(arrMergeTen);
            arrMergeTen.ShouldBe(new int[] { });
            arrMergeTen.Length.ShouldBe(0);
        }
    }
}

