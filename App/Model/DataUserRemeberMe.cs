
namespace App.Model
{
    public class UserPrivData
    {
        public string userName;
        public string password;
        public bool rememberMe;

        public UserPrivData()
        {
            userName = string.Empty;
            password = string.Empty;
            rememberMe = false;
        }
    }

    public partial class DataUserRemeberMe
    {
        public DataUserRemeberMe()
        {
            DataUser = new UserPrivData();
        }
        public UserPrivData DataUser;
        private const string dataUser = "dataUser";

        public void SetData(string username, string password, bool rememberMe)
        {
            this.DataUser.userName = username;
            this.DataUser.password = password;
            this.DataUser.rememberMe = rememberMe;
        }

        public void GetRememerMeData()
        {

            string content = GetFileWriteerAndReader().ReadTextFile(dataUser);
            DataUser = JsonConvert.DeserializeObject<UserPrivData>(content);
            
        }

        public bool isContainsDataUser()
        {
            return this.DataUser is not null;
        }

        public void SaveData()
        {
            string content = JsonConvert.SerializeObject(DataUser);
            GetFileWriteerAndReader().WirteTextToFile(content, dataUser);
        }


        private ReadAndWriteFile GetFileWriteerAndReader()
        {
            return App.GetReadAndWriteFile();
        }
        public void ReomveLastUser()
        {
            DataUser = new UserPrivData();
            SaveData();
        }

        public void DropFile()
        {
            App.GetReadAndWriteFile().DeleteFile(dataUser);
        }


    }
}
