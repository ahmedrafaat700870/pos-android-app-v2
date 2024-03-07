using HTTPCLIENT.models;
using HTTPCLIENT.models.api_users_data;
using System.Collections.Generic;

namespace HTTPCLIENT.requests_model
{
    public class get_users
    {
        public List<users> users = new List<users>();
        public List<account_clients> customers { get; set; } = new List<account_clients>();
        public List<auth_token> tokens { get; set; } = new List<auth_token>();
    }
}
