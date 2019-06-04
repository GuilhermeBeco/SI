using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] //só quero uma instancia deste serviço, independentemente do nr de pessoas que se liguem vai ser sempre a mesma instancia (bom por ex se tivermos muitos clientes a ligarem e tivermos uma máquina com alto poder de processamento)
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] //uma instancia diferente para cada cliente
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]//instancia para cada chamada
    public class AuthService : IAuthService
    {
        public DescriptionMessage GetUserDescription(string login)
        {
            var user = SqlServerHelper.GetUser(login);
            if(user == null) //se user nao existir
            {
                return new DescriptionMessage()
                {
                    Status = "Not OK",
                    Message = "User not found"
                };
            }
            return new DescriptionMessage()
            {
                Status = "OK",
                Description = user.Description
            };
        }

        public UsersMessage GetUsers(string login, string password) //para ir buscar os Users
        {
            var userID = SqlServerHelper.UserExists(login, password);

            if (userID > 0)
            {
                //Authenticated
                //queremos que só os Admins consigam obter os Users
                var user = SqlServerHelper.GetUser(userID);
                if(user.Role == "Admins") //apenas os users com o privilégio "Admins" podem obter os Users
                {
                    //Authorized
                    return new UsersMessage()
                    {
                        Status = "OK",
                        Users = SqlServerHelper.GetUsers().ToArray()
                    };
                }

                //NOT Authorized
                return new UsersMessage()
                {
                    Status = "Not OK",
                    Message = "Not Authorized"
                };

            }
            //Not Authenticated
            return new UsersMessage()
            {
                Status = "Not OK",
                Message = "Not Authenticated"
            };

        }

        public UsersMessage GetUsersByThumbprint(string pkcs7Base64) //pkcs7Base64 traz a chain de certificados que são precisos
        { //para substiruir a autenticação com login e password por um certificado
            try
            {

                SignedCms signedCms = new SignedCms();
                signedCms.Decode(Convert.FromBase64String(pkcs7Base64));

                signedCms.CheckSignature(false); //para validar tudo passamos false

                //Authentication
                var thumbprint = signedCms.Certificates[0].Thumbprint;

                var user = SqlServerHelper.GetUserByThumbprint(thumbprint);

                if (user != null)
                {
                    //Authenticated - Match with User
                    //queremos que só os Admins consigam obter os Users
                    if (user.Role == "Admins") //apenas os users com o privilégio "Admins" podem obter os Users
                    {
                        //Authorized
                        return new UsersMessage()
                        {
                            Status = "OK",
                            Users = SqlServerHelper.GetUsers().ToArray()
                        };
                    } //NOT Authorized
                    return new UsersMessage()
                    {
                        Status = "Not OK",
                        Message = "Not Authorized"
                    };
                } 

                //NOT Authed
                return new UsersMessage()
                {
                    Status = "Not OK",
                    Message = "Not Authenticated"
                };
            }
            catch (CryptographicException cryptoException)
            {
                //Not Authenticated
                return new UsersMessage()
                {
                    Status = "Not OK",
                    Message = "Not Authenticated"
                };

            }

        }


        public BaseMessage SetUserDescription(string login, string password, string description)
        {
            var userID = SqlServerHelper.UserExists(login, password);

            if (userID > 0) //se existir este login com esta password na BD fica autenticado
            {
                //Authenticated
                var user = SqlServerHelper.GetUser(userID);
                if(user.Role == "Admins" || user.Role == "Users") //só podem alterar as descrições os users com os privilégios "Users" e "Admins"
                {
                    if (SqlServerHelper.UpdateUserDescription(userID, description) > 0)
                    {
                        return new BaseMessage()
                        {
                            Status = "OK",
                            Message = "User Description Updated"
                        };
                    }

                    return new BaseMessage()
                    {
                        Status = "Not OK",
                        Message = "User Description Not Updated"
                    };
                }

                //Not Authorized
                return new BaseMessage()
                {
                    Status = "Not OK",
                    Message = "Not Authorized"
                };

            }
            //Not Authenticated
            return new BaseMessage()
            {
                Status = "Not OK",
                Message = "Not Authenticated"
            };
        }

        /// <summary>
        /// Exemplo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string VerifyAcessToBD()
        {
            User user = SqlServerHelper.GetUser(1);
            if (user == null)
                return "Erro ao aceder à base de dados";
            return user.Name;
        }


    }

}
