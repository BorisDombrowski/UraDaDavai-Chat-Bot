using Xunit;
using UraDaDavai_Chat_Bot.Commands;
using System;

namespace CommandsTests
{
    public class RepeatCommandTests
    {
        private Command _repeat = new RepeatCommand();

        [Fact(DisplayName = "Test 01")]
        public void Test1()
        {
            var command1 = "repeat qwerty 100";
            var command2 = "повтор qwerty 100";
            Assert.True(_repeat.CheckStringConformity(command1));
            Assert.True(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 02")]
        public void Test2()
        {
            var command1 = "повтор qwerty 1";
            var command2 = "repeat qwerty 1";
            Assert.True(_repeat.CheckStringConformity(command1));
            Assert.True(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 03")]
        public void Test3()
        {
            var command1 = "повтор qwerty 1000";
            var command2 = "repeat qwerty 1000";
            Assert.True(_repeat.CheckStringConformity(command1));
            Assert.True(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 04")]
        public void Test4()
        {
            var command1 = "повтор qwe rty 10";
            var command2 = "repeat qwe rty 10";
            Assert.True(_repeat.CheckStringConformity(command1));
            Assert.True(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 05")]
        public void Test5()
        {
            var command1 = "повтор !№;%:?*()_+ 1";
            var command2 = "repeat !№;%:?*()_+ 1";
            Assert.True(_repeat.CheckStringConformity(command1));
            Assert.True(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 06")]
        public void Test6()
        {
            var command1 = "повтор 999";
            var command2 = "repeat 999";
            Assert.False(_repeat.CheckStringConformity(command1));
            Assert.False(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 07")]
        public void Test7()
        {
            var command1 = "повтор qwerty";
            var command2 = "repeat qwerty";
            Assert.False(_repeat.CheckStringConformity(command1));
            Assert.False(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 08")]
        public void Test8()
        {
            var command1 = "повтор qwerty -1";
            var command2 = "repeat qwerty -1";
            Assert.False(_repeat.CheckStringConformity(command1));
            Assert.False(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 09")]
        public void Test9()
        {
            var command1 = "повтор qwerty 1001";
            var command2 = "repeat qwerty 1001";
            Assert.False(_repeat.CheckStringConformity(command1));
            Assert.False(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 10")]
        public void Test10()
        {
            var command1 = "повтор qwerty 0";
            var command2 = "repeat qwerty 0";
            Assert.False(_repeat.CheckStringConformity(command1));
            Assert.False(_repeat.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 11")]
        public void Test11()
        {
            var command = "qwe qwerty 0";
            Assert.False(_repeat.CheckStringConformity(command));
        }

        [Fact(DisplayName = "Test 12")]
        public void Test12()
        {
            var command1 = "повтор qwerty 1";
            var command2 = "repeat qwerty 1";
            Assert.Equal("qwerty", _repeat.Execute(command1));
            Assert.Equal("qwerty", _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 13")]
        public void Test13()
        {
            var command1 = "повтор qwerty 5";
            var command2 = "repeat qwerty 5";
            Assert.Equal("qwerty qwerty qwerty qwerty qwerty", _repeat.Execute(command1));
            Assert.Equal("qwerty qwerty qwerty qwerty qwerty", _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 14")]
        public void Test14()
        {
            var command1 = "повтор qwe rty 1";
            var command2 = "repeat qwe rty 1";
            Assert.Equal("qwe rty", _repeat.Execute(command1));
            Assert.Equal("qwe rty", _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 15")]
        public void Test15()
        {
            var command1 = "повтор qwe rty 3";
            var command2 = "repeat qwe rty 3";
            Assert.Equal("qwe rty qwe rty qwe rty", _repeat.Execute(command1));
            Assert.Equal("qwe rty qwe rty qwe rty", _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 16")]
        public void Test16()
        {
            var command1 = "повтор qwerty";
            var command2 = "repeat qwerty";
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 17")]
        public void Test17()
        {
            var command1 = "повтор qwe rty";
            var command2 = "repeat qwe rty";
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 18")]
        public void Test18()
        {
            var command1 = "повтор 100";
            var command2 = "repeat 100";
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 19")]
        public void Test19()
        {
            var command1 = "повтор qwerty -100";
            var command2 = "repeat qwerty -100";
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command2));
        }

        [Fact(DisplayName = "Test 20")]
        public void Test20()
        {
            var command = "qwerty";
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command));
        }

        [Fact(DisplayName = "Test 21")]
        public void Test21()
        {
            var command = "qwerty qwerty 10";
            Assert.ThrowsAny<Exception>(() => _repeat.Execute(command));
        }
    }
}
