using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace TasklistGenerator.Tests
{
    public class TaskExtractorTests
    {
        private TaskExtractor _theExtractor;
        private string _simpleTask = "an important task";

        public TaskExtractorTests()
        {
            _theExtractor = new TaskExtractor("TODO");
           //_reader = new StringReader("//TODO " + _simpleTask);
        }


        [Fact]
        public void ExtractTasks_StringReadWithOfTask_NameIsExtracted()
        {
            var task = _theExtractor.Extract("//TODO " + _simpleTask);
            Assert.Equal("TODO",task.Name);
        }

        [Fact]
        public void ExtractTasks_TODOSeperatedbySpace_NameIsExtracted()
        {
            var task = _theExtractor.Extract("// TODO " + _simpleTask);
            Assert.Equal("TODO",task.Name);
        }


        [Fact]
        public void ExtractTasks_StringReadWithOfTask_TextIsExtracted()
        {
            var task = _theExtractor.Extract("//TODO " + _simpleTask);
            Assert.Equal(_simpleTask,task.Text);
        }
        [Fact]
        public void ExtractTasks_StringwithNewLineAtend_NewLineTrimed()
        {
            var task = _theExtractor.Extract("//TODO " + _simpleTask+ "\n");
            Assert.False(task.Text.EndsWith("\n"));
        }


        [Fact]
        public void ExtractTasks_TodoStartingWithWhitespaces_WhitespacesTrimed()
        {
            var task = _theExtractor.Extract("  \t //TODO " + _simpleTask+ "\n");
            Assert.Equal(_simpleTask, task.Text);
        }


        [Fact]
        public void ExtractTasks_StringThatdoesntMath_NullIsReturned()
        {
            var task = _theExtractor.Extract(" dsfg retsdfgas  " + _simpleTask);
            Assert.Null(task);
        }
    }
}
