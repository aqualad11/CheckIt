using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using Microsoft.IdentityModel.Tokens;

namespace CheckIt.Authorization
{
    class Token : IToken
    {
        //TODO: make own key and possibly store it somewhere else
        private string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742"+
           "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        private JwtSecurityTokenHandler handler;
        public bool activeSession { get; set; }
        private string jwt { get; set; }
        private List<string> actions { get; set; }
        private string email { get; set; }
        

        public Token(string email, List<string> actions)
        {
            this.actions = actions;
            this.email = email;
            handler = new JwtSecurityTokenHandler();
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            
            var payload = new JwtPayload {
                {"email", email },
                {"actions", actions}
            };

            var securityToken = new JwtSecurityToken(header, payload);

            jwt = handler.WriteToken(securityToken);

        }


        public Token(string jwt)
        {
            var token = handler.ReadJwtToken(jwt);
            email = token.Payload["email"].ToString();
            actions = ExtractActions(token.Payload);
            this.jwt = jwt;
        }


        private List<string> ExtractActions(JwtPayload payload)
        {
            var actionString = payload["actions"].ToString();
            var actionList = actionString.ToList();//char array
            bool start = false;//if char == '"' then it is the beginning or end of word
            bool q = false;// says whether quotation marks where the last char
            string actionWord = "";//the action string
            List<string> actionsNeeded = new List<string>();//list of actions
            foreach (var act in actionList)
            {
                if (act == '\"')
                {
                    start = !start;
                    if (start)
                    {
                        q = true;
                    }
                    else
                    {
                        actionsNeeded.Add(actionWord);
                        actionWord = "";
                    }
                }
                else if (q)
                {
                    q = false;
                    actionWord += act;
                }
                else if (start)
                {
                    actionWord += act;
                }

            }

            return actionsNeeded;
        }

        public List<string> GetActions()
        {
            return actions;
        }

        public string GetEmail()
        {
            return email;
        }
    }

}
