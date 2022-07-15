using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server {
    [ServiceContract]
    public interface IDatabaseServer : IPDResources, IMember{
        [OperationContract]
        Boolean regIDsAvailable(String sid, String nic);//Check for the Availability of NIC, UID
        [OperationContract]
        Boolean regCodeAvailable(String regcode);//Check for the Availability of RegCode
        [OperationContract]
        int insertRegCode(String uid, String nic, String regcode, String pic);//Insert Regcode, Nic, Uid into database


        [OperationContract]
        Boolean validLogin(String username, String password);
        [OperationContract]
        Boolean userRegistered(String username);
        [OperationContract]
        Boolean validUsername(String username);//Check if Username Available 
        [OperationContract]
        Boolean validEmail(String email);//Check if Email Available 

        [OperationContract]
        Boolean registerUser(String regCode, String[] personal, String[] contact, String[] login);//Register User
        [OperationContract]
        Boolean validNIC(String nic);//Validate NIC

        
        [OperationContract]
        object[] getLICDetails(String nic);//Get Details of the Library Card        
    }
}
