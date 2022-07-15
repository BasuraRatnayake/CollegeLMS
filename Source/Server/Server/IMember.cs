using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    [ServiceContract]
    public interface IMember {
        [OperationContract]
        String getMemberPass(String nic);//Get the password and Reg Code of member from nic
        [OperationContract]
        String getMemberUsername(String regCode);//Get username from RegCode

        [OperationContract]
        Boolean changeMemberPass(String regCode, String pass);//Change the password of the member from regcode
        [OperationContract]
        Boolean changeMemberEmail(String regCode, String email);//Change the email address of the member from regcode
        [OperationContract]
        Boolean changeMemberContact(String username, String mobile, String home);//Change Contact of member from username
        [OperationContract]
        Boolean changeMemberAddress(String username, String street, String city);//Change Address of member from username

        [OperationContract]
        String showMemberDetails(String searchTerm, String sType);//Get All Details of the member

        [OperationContract]
        Boolean revokeMembership(String nic);//Revoke Membership of Member from NIC

        [OperationContract]
        String getMemberName(String username);//Get Member Full Name

        [OperationContract]
        String getMemberPic(String username);//Get the Profile pic of member
    }
}