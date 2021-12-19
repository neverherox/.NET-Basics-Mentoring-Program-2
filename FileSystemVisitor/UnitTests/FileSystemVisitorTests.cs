using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileSystemVisitorLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class FileSystemVisitorTests
    {
        private FileSystemVisitor _visitor;
        private readonly string testPath = @"..\..\..\TestFolder";

        [TestMethod]
        public void TestSearchWithoutFilter()
        {
            _visitor = new FileSystemVisitor();
            var files = new List<FileSystemInfo>();
            var expectedFileName = "folder112";

            foreach (var file in _visitor.Traverse(false, testPath))
            {
                files.Add(file);
            }

            Assert.AreEqual(expectedFileName, files.Last().Name);
        }

        [TestMethod]
        public void TestSearchWithFilter()
        {
            _visitor = new FileSystemVisitor(x => x.Name.Contains("111"));
            var files = new List<FileSystemInfo>();
            var expectedFileName = "folder111";

            foreach (var file in _visitor.Traverse(false, testPath))
            {
                files.Add(file);
                Console.WriteLine(file.Name);
            }

            Assert.AreEqual(expectedFileName, files.Last().Name);
        }

        [TestMethod]
        public void TestSearchThrowsDirectoryNotFoundException()
        {
            _visitor = new FileSystemVisitor();
            var files = new List<FileSystemInfo>();

            Assert.ThrowsException<DirectoryNotFoundException>(() => {
                foreach (var file in _visitor.Traverse(false, ""))
                {
                    files.Add(file);
                }
            });
        }
    }
}
