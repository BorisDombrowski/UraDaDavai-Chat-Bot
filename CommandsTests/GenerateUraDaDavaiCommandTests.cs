using Xunit;
using UraDaDavai_Chat_Bot.Commands;
using System;

namespace CommandsTests
{
    public class GenerateUraDaDavaiCommandTests
    {
        private Command _gen = new GenerateUraDaDavaiCommand();

        [Fact(DisplayName = "Test 01")]
        public void Test1()
        {
            var command1 = "gen 1";
            var command2 = "ген 1";
            Assert.True(_gen.CheckStringConformity(command1));
            Assert.True(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 02")]
        public void Test2()
        {
            var command1 = "gen 100";
            var command2 = "ген 100";
            Assert.True(_gen.CheckStringConformity(command1));
            Assert.True(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 03")]
        public void Test3()
        {
            var command1 = "gen 300";
            var command2 = "ген 300";
            Assert.True(_gen.CheckStringConformity(command1));
            Assert.True(_gen.CheckStringConformity(command2));
        }
        
        [Fact(DisplayName = "Test 04")]
        public void Test4()
        {
            var command1 = "gen -10";
            var command2 = "ген -10";
            Assert.False(_gen.CheckStringConformity(command1));
            Assert.False(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 05")]
        public void Test5()
        {
            var command1 = "gen 0";
            var command2 = "ген 0";
            Assert.False(_gen.CheckStringConformity(command1));
            Assert.False(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 06")]
        public void Test6()
        {
            var command1 = "gen 999";
            var command2 = "ген 999";
            Assert.False(_gen.CheckStringConformity(command1));
            Assert.False(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 07")]
        public void Test7()
        {
            var command1 = "gen qwerty";
            var command2 = "ген qwerty";
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command2));
        }

        [Fact(DisplayName = "Test 08")]
        public void Test8()
        {
            var command1 = "gen";
            var command2 = "ген";
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command2));
        }

        [Fact(DisplayName = "Test 09")]
        public void Test9()
        {
            var command1 = "gen -10";
            var command2 = "ген -10";
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command2));
        }

        [Fact(DisplayName = "Test 10")]
        public void Test10()
        {
            var command1 = "gen 10";
            var command2 = "ген 10";
            
            var res1 = _gen.Execute(command1);
            var res2 = _gen.Execute(command2);

            Assert.Equal(res1, res2);
            Assert.Equal(10, res1.Split(' ').Length); 
            Assert.Equal(10, res1.Split(' ').Length);
        }

        [Fact(DisplayName = "Test 11")]
        public void Test11()
        {
            var command1 = "gen 10 +";
            var command2 = "ген 10 +";
            Assert.True(_gen.CheckStringConformity(command1));
            Assert.True(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 12")]
        public void Test12()
        {
            var command1 = "gen -10 +";
            var command2 = "ген -10 +";
            Assert.False(_gen.CheckStringConformity(command1));
            Assert.False(_gen.CheckStringConformity(command2));
        }

        [Fact(DisplayName = "Test 13")]
        public void Test13()
        {
            var command1 = "gen 10 +";
            var command2 = "ген 10 +";

            var res1 = _gen.Execute(command1);
            var res2 = _gen.Execute(command2);

            Assert.Equal(res1, res2);

            Assert.Equal(10, res1.Split(' ').Length);
            Assert.Equal(10, res1.Split(' ').Length);

            Assert.True(res1.ToUpper().Equals(res1));
            Assert.True(res2.ToUpper().Equals(res2));
        }

        [Fact(DisplayName = "Test 14")]
        public void Test14()
        {
            var command1 = "gen";
            var command2 = "ген";

            Assert.ThrowsAny<Exception>(() => _gen.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command2));
        }

        [Fact(DisplayName = "Test 15")]
        public void Test15()
        {
            var command1 = "gen +";
            var command2 = "ген +";

            Assert.ThrowsAny<Exception>(() => _gen.Execute(command1));
            Assert.ThrowsAny<Exception>(() => _gen.Execute(command2));
        }

        [Fact(DisplayName = "Test 16")]
        public void Test16()
        {
            var command1 = "qwerty";
            var command2 = "qwerty";

            Assert.Throws<ArgumentException>(() => _gen.Execute(command1));
            Assert.Throws<ArgumentException>(() => _gen.Execute(command2));
        }
    }
}