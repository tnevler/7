using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Практика7;

namespace _7Практика
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod71() // Ошибки нет
        {
            string s = "100110100011";
            int[] arr = Program.FindMistake(s);
            string result = string.Concat(arr);
            Assert.AreEqual(result, s);
        }

        [TestMethod]
        public void TestMethod72() // Одна ошибка
        {
            string s = "100110100111";
            string s2 = "100110100011";
            int[] arr = Program.FindMistake(s);
            string result = string.Concat(arr);
            Assert.AreEqual(result, s2);
        }

        [TestMethod]
        public void TestMethod73() // Больше 1 ошибки
        {
            string s = "11110000111";
            int[] arr = Program.FindMistake(s);
            string result = string.Concat(arr);
            Assert.AreEqual(result, s);
        }

        [TestMethod]
        public void TestMethod74() // Одна ошибка
        {
            string s = "10010001111";
            string s2 = "10011001111";
            int[] arr = Program.FindMistake(s);
            string result = string.Concat(arr);
            Assert.AreEqual(result, s2);
        }

        [TestMethod]
        public void TestMethod75() // Show
        {
            string s = "10010001111";
            string s2 = "10011001111";
            int[] arr = Program.FindMistake(s);
            Program.Show(arr);
        }
    }
}
