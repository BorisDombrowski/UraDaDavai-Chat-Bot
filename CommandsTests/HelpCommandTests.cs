using Xunit;
using UraDaDavai_Chat_Bot.Commands;
using System;

namespace CommandsTests
{
    public class HelpCommandTests
    {
        private Command _help = new HelpCommand();
        private string _helpResponce =
                "��� ������������� ���� � ������ ���������� ����� �������� ���/ura\n" +
                "\n" +
                "\n" +
                "� ���/gen <�����_����> [+] - ��������� ������ ��� �� �����\n" +
                "-- <�����_����> - ���������� ����, ������� ������ ��������� ����� (�� 1 �� 300)\n" +
                "-- [+] - �������������� ��������, �������� ���, ���� ��� ����� ������ ������ ���� � ������� ��������\n" +
                "\n" +
                "\n" +
                "� ������/repeat <�����> <�����_��������>\n" +
                "� ������/repeat <����� ����� ������> <�����_��������> - ��������� ������ �� ������������� �����/�����\n" +
                "-- <�����> - �����, ������� ����� ���������\n" +
                "-- <����� ����� ������> - �����, ������� ����� ���������\n" +
                "-- <�����_��������> - ������� ��� ����� ��������� ����� (�� 1 �� 1000)";

        [Fact(DisplayName = "Test 01")]
        public void Test1()
        {            
            Assert.False(_help.CheckStringConformity("qwerty"));
        }

        [Fact(DisplayName = "Test 02")]
        public void Test2()
        {           
            Assert.True(_help.CheckStringConformity("help"));
        }

        [Fact(DisplayName = "Test 03")]
        public void Test3()
        {            
            Assert.False(_help.CheckStringConformity("help qwerty"));
        }

        [Fact(DisplayName = "Test 04")]
        public void Test4()
        {
            Assert.Equal(_helpResponce, _help.Execute("help"));
        }

        [Fact(DisplayName = "Test 05")]
        public void Test5()
        {
            Assert.Throws<ArgumentException>(() => _help.Execute("qwerty"));
        }
    }
}