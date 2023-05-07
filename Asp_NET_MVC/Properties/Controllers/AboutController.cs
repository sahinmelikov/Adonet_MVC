namespace Asp_NET_MVC.Properties.Controllers
{
    public class AboutController
    {
        public string index()
        {
            return "About Index";
        }
        public string detail(int id)
        {
            return "About details id="+ id;
        }
    }
}
