using System;
using System.ServiceModel;

namespace Server {
    [ServiceContract]
    public interface IPDResources {//Holds the Resources(Physical, Digital) of the System
        #region Books
        [OperationContract]
        Boolean addBook(String[] inputs);//Add Book or E-Book to Server
        [OperationContract]
        String showBook(String searchTerm, String Type);//Search and Return Books
        [OperationContract]
        Boolean removeBook(String isbn);//Remove Book from server
        [OperationContract]
        Boolean modifyBook(String[] inputs);//Modify Book Detail
        #endregion

        #region NewspaperMagazine
        [OperationContract]
        Boolean addNewspaper(String[] inputs);//Add Newspaper or Magazine
        [OperationContract]
        String showNewspapers(String searchTerm, String Type);//Search and Return Newspaper or Magazine
        [OperationContract]
        Boolean modifyNewspaper(String[] inputs);//Modify Newspaper Detail
        [OperationContract]
        Boolean removeNewspaper(String isbn);//Remove 
        #endregion

        #region Comics
        [OperationContract]
        Boolean addComic(String[] inputs);//Add Comic
        [OperationContract]
        String showComics(String searchTerm, String Type);//Search and Return Comics
        [OperationContract]
        Boolean modifyComic(String[] inputs);//Modify Detail
        [OperationContract]
        Boolean removeComic(String isbn);//Remove 
        #endregion

        #region VideoDocumentry
        [OperationContract]
        Boolean addDocVid(String[] inputs);//Add Comic
        [OperationContract]
        String showVidDoc(String searchTerm, String Type);//Search and Return Video and Documentry
        [OperationContract]
        Boolean modifyVidDoc(String[] inputs);//Modify Detail
        [OperationContract]
        Boolean removeVidDoc(String isbn);//Remove 
        #endregion

        #region PastPapers
        [OperationContract]
        Boolean addPastPaper(String[] inputs);//Add Past Paper
        [OperationContract]
        String showPastPapers(String searchTerm, String Type);//Search and Return Comics
        [OperationContract]
        Boolean modifyPastPaper(String[] inputs);//Modify Detail
        [OperationContract]
        Boolean removePastPaper(String isbn);//Remove 
        #endregion

        [OperationContract]
        Boolean resouceValid(String rCode, String rType);//Check if resource is valid
        [OperationContract]
        String getTitle(String table, String searchTerm);//Get Title of Resource
        [OperationContract]
        String getResourcePic(String table, String searchTerm);//Get the picture of the resource
    }
}