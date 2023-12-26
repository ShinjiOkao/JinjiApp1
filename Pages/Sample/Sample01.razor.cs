using JinjiApp1.Models;

namespace JinjiApp1.Pages.Sample
{
    public partial class Sample01
    {
        public string? Name;
        public int Age;
        public string? Message;
        public List<Person> Persons = new List<Person>();

        protected override void OnInitialized()
        {
            Persons = DbService.GetPersonAll();
        }

        private void BtnCommand1_Click()
        {
            if (Name == null || Name.Equals(""))
            {
                Message = "名前を入れてください。";
            }
            else
            {
                DbService.InsertData(Name, Age);
                Persons = DbService.GetPersonAll();
            }
        }
    }
}
