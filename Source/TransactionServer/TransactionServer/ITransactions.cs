using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TransactionServer {
    [ServiceContract]
    public interface ITransactions {
        #region Issue
        [OperationContract]
        Boolean issueBook(String regCode, String resId, String type);//Issue Book to Member
        [OperationContract]
        Boolean issueComic(String regCode, String resId);//Issue Comic to Member
        [OperationContract]
        Boolean issuePastP(String regCode, String resId);//Issue Past Paper to Member
        [OperationContract]
        Boolean issueNewsMag(String regCode, String resId, String type);//Issue Past Paper to Newspaper/magazine
        [OperationContract]
        Boolean issueVidDoc(String regCode, String resId, String type);//Issue Past Paper to Video/Documentry
        #endregion


        [OperationContract]
        int unReturnedCount(String memberID);//Get the Number of Borrowed unreturned Books

        [OperationContract]
        Boolean resourcedIssued(String table, String searchTerm);//Check if resource valid for issue

        [OperationContract]
        Boolean returnResource(String memberCode, String resourceCode, String table);//Return Resource to Library

        [OperationContract]
        String issuedResources(String searchTerm);//Get List of Issued Resources
    }
}
