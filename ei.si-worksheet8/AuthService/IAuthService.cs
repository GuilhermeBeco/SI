using System.Runtime.Serialization;
using System.ServiceModel;

namespace AuthService
{
    [ServiceContract]
    public interface IAuthService
    {
        /// <summary>
        /// Verifica se é possível aceder à BD
        /// </summary>
        /// <returns></returns>
        [OperationContract] //isto é que diz a interface para publicar o metodo a baixo
        string VerifyAcessToBD();

        [OperationContract]
        UsersMessage GetUsers(string login, string password);

        [OperationContract]
        UsersMessage GetUsersByThumbprint(string pkcs7Base64);

        [OperationContract]
        DescriptionMessage GetUserDescription(string login);

        [OperationContract]
        BaseMessage SetUserDescription(string login, string password, string description);

    }

}
