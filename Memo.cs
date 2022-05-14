using System;
namespace Typex_Notepad
{
    public class Memo
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String DateTime { get; set; }
        public String SubTitle { get; set; }
        public String MemoText { get; set; }
        public String Color { get; set; }
        public String WebLink { get; set; }
        public byte[] Image { get; set; }
        public String ImagePath { get; set; }
    }
}
