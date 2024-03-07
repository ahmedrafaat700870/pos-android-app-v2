namespace App.Lang
{
    public interface IUnitLang<T> where T : class
    {
        T GetLang();
    }
}
