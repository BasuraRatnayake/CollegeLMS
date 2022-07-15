using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server {
    public class DatabaseServer:IDatabaseServer {
        protected Database db = new Database();

        #region Member
        public String getMemberPass(String nic) {//Get the password and Reg Code of member from nic
            db.establishConnection();

            db.reader = db.Select("lD.password,rC.regCode", "regCodes rC, loginDetails lD", "rC.nic = '"+nic+"' AND ld.regCode = rC.regCode").ExecuteReader();

            db.reader.Read();

            String pass = db.reader.GetValue(0).ToString() + "|"+ db.reader.GetValue(1).ToString();

            db.closeConnection();
            return pass;
        }
        public String getMemberUsername(String regCode) {//Get username from RegCode
            db.establishConnection();

            db.reader = db.Select("username", "loginDetails", "regCode = '" + regCode + "'").ExecuteReader();

            db.reader.Read();

            String username = db.reader.GetValue(0).ToString();

            db.closeConnection();
            return username;
        }

        public Boolean changeMemberPass(String regCode, String pass) {//Change the password of the member from nic
            int status = db.Update("password", "'"+ pass + "'", "regCode = '" + regCode+"'", "loginDetails");
            db.closeConnection();

            return (status == 1);
        }

        public Boolean changeMemberEmail(String regCode, String email) {//Change the email address of the member from regcode
            int status = db.Update("email", "'" + email + "'", "regCode = '" + regCode + "'", "loginDetails");
            db.closeConnection();

            return (status == 1);
        }

        public Boolean changeMemberContact(String username, String mobile, String home) {//Change Address of member from username
            int status = db.Update("mobile", "'" + mobile + "', home = '" + home + "'", "username = '" + username + "'", "contactDetails");
            db.closeConnection();

            return (status == 1);
        }

        public Boolean changeMemberAddress(String username, String street, String city) {//Change Address of member from username
            int status = db.Update("street", "'" + street + "', city = '" + city + "'", "username = '" + username + "'", "personalDetails");
            db.closeConnection();

            return (status == 1);
        }

        public String showMemberDetails(String searchTerm, String sType) {//Get All Details of the member
            db.establishConnection();
            db.reader = db.Select("rC.regCode,rC.nic,rC.sid,rC.regDate,rC.pic, ld.username,ld.email,ld.password, pD.firstName, pD.lastName, pD.street, pD.city, cD.home, Cd.mobile", "loginDetails lD,personalDetails pD,contactDetails cD,regCodes rC", "(ld.regCode = rC.regCode AND ld.username = pD.username AND lD.username = cD.username) AND "+sType + " LIKE '%" + searchTerm + "%'").ExecuteReader();

            List<dynamic> bData = new List<dynamic>();
            while(db.reader.Read()) {
                bData.Add(new DataStructures.Members {
                    regCode = db.reader.GetValue(0).ToString(), nic = db.reader.GetValue(1).ToString(), sid = db.reader.GetValue(2).ToString(), regDate = db.reader.GetValue(3).ToString(), pic = db.reader.GetValue(4).ToString(), username = db.reader.GetValue(5).ToString(), email = db.reader.GetValue(6).ToString(), password = db.reader.GetValue(7).ToString(), firstName = db.reader.GetValue(8).ToString(), lastName = db.reader.GetValue(9).ToString(), street = db.reader.GetValue(10).ToString(), city = db.reader.GetValue(11).ToString(), home = db.reader.GetValue(12).ToString(), mobile = db.reader.GetValue(13).ToString(),
                });
            }

            db.closeConnection();

            return JsonConvert.SerializeObject(bData) + "|" + bData.Count;
        }

        public Boolean revokeMembership(String nic) {
            String username = getMemberPass(nic).Split('|')[1];
            username = getMemberUsername(username);

            int status = db.Delete("contactDetails", "username = '" + username + "'");//Remove Contact Details
            db.closeConnection();
            status += db.Delete("personalDetails", "username = '" + username + "'");//Remove Personal Details
            db.closeConnection();
            status += db.Delete("loginDetails", "username = '" + username + "'");//Remove Login Detail
            db.closeConnection();

            return (status == 3);
        }

        public String getMemberName(String username) {//Get Member Full Name
            db.establishConnection();

            db.reader = db.Select("firstName +' '+lastName ", "personalDetails", "username = '"+ username + "'").ExecuteReader();

            db.reader.Read();

            String title = db.reader.GetValue(0).ToString();

            db.closeConnection();
            return title;
        }
        #endregion

        public bool regIDsAvailable(String sid, String nic) {
            if(db.numberOfRows("regCodes", "sid = '" + sid + "' AND nic = '" + nic + "'") == 0)
                return true;
            return false;
        }
        public Boolean regCodeAvailable(String regcode) {
            if(db.numberOfRows("regCodes", "regCode = '" + regcode + "' AND activated = '0'") == 0)
                return true;
            return false;
        }
        public int insertRegCode(String uid, String nic, String regcode, String pic) {
            return db.Insert("'" + nic + "','" + uid + "', '" + regcode + "', Current_Timestamp, '0', '"+pic+"'", "regCodes");
        }

        public bool validLogin(string username, string password) {
            if(db.numberOfRows("loginDetails", "username = '" + username + "' AND password = '" + password + "'") == 1)
                return true;
            return false;
        }
        public Boolean userRegistered(String username) {
            if(db.numberOfRows("loginDetails", "username = '" + username + "'") == 1)
                return true;
            return false;
        }

        public bool validUsername(string username) {
            if(db.numberOfRows("loginDetails", "username = '" + username + "'") == 0)
                return true;
            return false;
        }
        public bool validEmail(string email) {
            if(db.numberOfRows("loginDetails", "email = '" + email + "'") == 0)
                return true;
            return false;
        }

        public bool registerUser(String regCode, String[] personal, String[] contact, String[] login) {
            int status = 0;

            status += db.Update("activated", "'1'", "regCode = '" + regCode + "'", "regCodes");//Change the activated status of the regCode
            db.closeConnection();

            status += db.Insert("'" + regCode + "','" + login[0] + "', '" + login[2] + "', '" + login[1] + "'", "loginDetails");//Insert Login Details
            db.closeConnection();

            status += db.Insert("'" + login[0] + "','" + personal[0] + "', '" + personal[1] + "', '" + personal[2] + "','" + personal[3] + "'", "personalDetails");//Insert Personal Information
            db.closeConnection();

            status += db.Insert("'" + login[0] + "','" + contact[0] + "', '" + contact[1] + "'", "contactDetails");
            db.closeConnection();//Insert Contact Details

            return (status == 4);
        }
        public Boolean validNIC(String nic) {//Check if NIC in System
            if(db.numberOfRows("regCodes", "nic = '" + nic + "'") == 1)
                return true;
            return false;
        }

        #region Books
        public bool addBook(String[] inputs) {
            if(inputs[9].ToLower() == "false")//Check if Books is Ebook
                inputs[9] = "N";
            else
                inputs[9] = "E";

            int count = db.Insert("'" + inputs[0] + "','" + inputs[1] + "','" + inputs[2] + "','" + inputs[3] + "','" + inputs[4] + "','" + inputs[5] + "','" + inputs[6] + "','" + inputs[7] + "','" + inputs[8] + "','" + inputs[9] + "'", "books");//Insert 
            db.closeConnection();

            count += db.Insert("'" + inputs[0] + "', 'Book_"+ inputs[9] + "'", "resourceCodes");

            db.closeConnection();
            return (count == 2);
        }
        public String showBook(String searchTerm, String sType) {//Return data of Book(s)
            db.establishConnection();
            db.reader = db.Select("isbn, title, fname, lname, pic, bType, published, publisher, lang, genre", "books", sType + " LIKE '%" + searchTerm + "%'").ExecuteReader();

            List<dynamic> bData = new List<dynamic>();
            while(db.reader.Read()) {
                bData.Add(new DataStructures.Books {
                    isbn = db.reader.GetValue(0).ToString(), title = db.reader.GetValue(1).ToString(), fname = db.reader.GetValue(2).ToString(), lname = db.reader.GetValue(3).ToString(), pic = db.reader.GetValue(4).ToString(), btype = db.reader.GetValue(5).ToString(), published = db.reader.GetValue(6).ToString(), publisher = db.reader.GetValue(7).ToString(), lang = db.reader.GetValue(8).ToString(), genre = db.reader.GetValue(9).ToString()
                });
            }

            db.closeConnection();

            return JsonConvert.SerializeObject(bData)+"|"+bData.Count;
        }
        public Boolean removeBook(String isbn){//Delete record from database
            int status = db.Delete("resourceCodes", "rCode = '" + isbn + "'");
            status += status = db.Delete("books", "isbn = '" + isbn + "'");
            return (status == 2);            
        }
        public Boolean modifyBook(String[] inputs) {//Modify Book Detail
            if(inputs[8].ToLower() == "false")//Check if Books is Ebook
                inputs[8] = "N";
            else
                inputs[8] = "E";

            int status = db.Update("title = '"+ inputs[1] + "', fname = '" + inputs[2] + "', lname = '" + inputs[3] + "', genre = '" + inputs[4] + "', published = '" + inputs[5] + "', publisher = '" + inputs[6] + "', lang = '" + inputs[7] + "', bType = '" + inputs[8] + "'", "isbn = '" + inputs[0] + "'", "books");//Change the activated status of the regCode
            db.closeConnection();
            return (status == 1);
        }
        #endregion

        #region NewspaperMagazine
        public bool addNewspaper(String[] inputs) {//Add Newspaper or Magazine
            if(inputs[6].ToLower() == "false")//Check if Newspaper 
                inputs[6] = "N";
            else
                inputs[6] = "M";

            int count = db.getMaxID("nmId", "newspapersMags");//Get Maximum ID

            count = db.Insert("'" + count + "', 'NewM_" + inputs[6] + "'", "resourceCodes");//Add Datat to Resource Table
            db.closeConnection();

            count += db.Insert("'" + inputs[0] + "','" + inputs[1] + "','" + inputs[2] + "','" + inputs[5] + "','" + inputs[4] + "','" + inputs[3] + "','" + inputs[6] + "'", "newspapersMags");//Insert 
            db.closeConnection();
            
            return (count == 2);
        }
        public String showNewspapers(String searchTerm, String sType) {//Return data of Newspaper(s) or Magazine(s)
            db.establishConnection();
            db.reader = db.Select("nmId, title, genre, published, lang, pic, publisher, bType", "newspapersMags", sType + " LIKE '%" + searchTerm + "%'").ExecuteReader();

            List<dynamic> bData = new List<dynamic>();
            while(db.reader.Read()) {
                bData.Add(new DataStructures.NewM {
                    nmId = db.reader.GetValue(0).ToString(),
                    title = db.reader.GetValue(1).ToString(),
                    genre = db.reader.GetValue(2).ToString(),
                    published = db.reader.GetValue(3).ToString(),
                    lang = db.reader.GetValue(4).ToString(),
                    pic = db.reader.GetValue(5).ToString(),
                    publisher = db.reader.GetValue(6).ToString(),
                    bType = db.reader.GetValue(7).ToString()
                });
            }

            db.closeConnection();

            return JsonConvert.SerializeObject(bData) + "|" + bData.Count;
        }
        public Boolean modifyNewspaper(String[] inputs) {//Modify Newspaper Detail
            if(inputs[6].ToLower() == "false")//Check if Newspaper 
                inputs[6] = "N";
            else
                inputs[6] = "M";

            int status = db.Update("title = '" + inputs[1] + "', genre = '" + inputs[2] + "', published = '" + inputs[3] + "', publisher = '" + inputs[4] + "', lang = '" + inputs[5] + "', bType = '" + inputs[6] + "'", "nmId = " + inputs[0], "newspapersMags");
            db.closeConnection();
            return (status == 1);
        }
        public Boolean removeNewspaper(String isbn) {//Delete record from database
            int status = db.Delete("resourceCodes", "rCode = '" + isbn + "'");
            db.closeConnection();

            status += status = db.Delete("newspapersMags", "nmId = '" + isbn + "'");
            db.closeConnection();

            return (status == 2);
        }
        #endregion

        #region Comics
        public bool addComic(String[] inputs) {//Add Comic
            int count = db.getMaxID("coId", "comics");//Get Maximum ID

            count = db.Insert("'" + count + "', 'Comic'", "resourceCodes");//Add Datat to Resource Table
            db.closeConnection();

            count += db.Insert("'" + inputs[0] + "','" + inputs[1] + "','" + inputs[2] + "','" + inputs[3] + "','" + inputs[4] + "','" + inputs[5] + "','" + inputs[6] + "'", "comics");//Insert 
            db.closeConnection();

            return (count == 2);
        }
        public String showComics(String searchTerm, String sType) {//Search and Return Video and Documentry
            db.establishConnection();
            db.reader = db.Select("*", "comics", sType + " LIKE '%" + searchTerm + "%'").ExecuteReader();

            List<dynamic> bData = new List<dynamic>();
            while(db.reader.Read()) {
                bData.Add(new DataStructures.Comics {
                    coId = db.reader.GetValue(0).ToString(),
                    title = db.reader.GetValue(1).ToString(),
                    genre = db.reader.GetValue(2).ToString(),
                    published = db.reader.GetValue(3).ToString(),
                    lang = db.reader.GetValue(4).ToString(),
                    pic = db.reader.GetValue(5).ToString(),
                    publisher = db.reader.GetValue(6).ToString(),
                    volume = db.reader.GetValue(7).ToString()
                });
            }

            db.closeConnection();

            return JsonConvert.SerializeObject(bData) + "|" + bData.Count;
        }
        public Boolean modifyComic(String[] inputs) {//Modify Detail
            int status = db.Update("title = '" + inputs[1] + "', genre = '" + inputs[2] + "', published = '" + inputs[3] + "', lang = '" + inputs[4] + "', publisher = '" + inputs[5] + "', volume = '" + inputs[6] + "'", "coId = " + inputs[0], "comics");
            db.closeConnection();
            return (status == 1);
        }
        public Boolean removeComic(String isbn) {//Delete record from database
            int status = db.Delete("resourceCodes", "rCode = '" + isbn + "'");
            db.closeConnection();

            status += status = db.Delete("comics", "coId = '" + isbn + "'");
            db.closeConnection();

            return (status == 2);
        }
        #endregion

        #region Documentry
        public bool addDocVid(String[] inputs) {//Add Video Documentry or Tutorial
            if(inputs[7] == "Documentry")
                inputs[7] = "D";
            else
                inputs[7] = "T";

            int count = db.getMaxID("vdId", "vidDoc");//Get Maximum ID

            count = db.Insert("'" + count + "', 'VidD_" + inputs[7] + "'", "resourceCodes");//Add Datat to Resource Table
            db.closeConnection();

            count += db.Insert("'" + inputs[0] + "','" + inputs[1] + "','" + inputs[2] + "','" + inputs[3] + "','" + inputs[4] + "','" + inputs[5] + "','" + inputs[6] +"','"+ inputs[7] + "'", "vidDoc");//Insert 
            db.closeConnection();

            return (count == 2);
        }
        public String showVidDoc(String searchTerm, String sType) {//Search and Return Video and Documentry
            db.establishConnection();
            db.reader = db.Select("*", "vidDoc", sType + " LIKE '%" + searchTerm + "%'").ExecuteReader();

            List<dynamic> bData = new List<dynamic>();
            while(db.reader.Read()) {
                bData.Add(new DataStructures.VidDoc {
                    vdId = db.reader.GetValue(0).ToString(),
                    title = db.reader.GetValue(1).ToString(),
                    genre = db.reader.GetValue(2).ToString(),
                    lang = db.reader.GetValue(3).ToString(),
                    fname = db.reader.GetValue(4).ToString(),
                    lname = db.reader.GetValue(5).ToString(),
                    duration = db.reader.GetValue(6).ToString(),
                    pic = db.reader.GetValue(7).ToString(),
                    vdType = db.reader.GetValue(8).ToString()
                });
            }

            db.closeConnection();

            return JsonConvert.SerializeObject(bData) + "|" + bData.Count;
        }
        public Boolean modifyVidDoc(String[] inputs) {//Modify Detail
            int status = db.Update("title = '" + inputs[1] + "', genre = '" + inputs[2] + "', lang = '" + inputs[3] + "', fname = '" + inputs[4] + "', lname = '" + inputs[5] + "', duration = " + inputs[6], "vdId = " + inputs[0], "vidDoc");
            db.closeConnection();
            return (status == 1);
        }
        public Boolean removeVidDoc(String isbn) {//Delete record from database
            int status = db.Delete("resourceCodes", "rCode = '" + isbn + "'");
            db.closeConnection();

            status += status = db.Delete("vidDoc", "vdId = '" + isbn + "'");
            db.closeConnection();

            return (status == 2);
        }
        #endregion

        #region PastPapers
        public bool addPastPaper(String[] inputs) {//Add PastPaper
            int count = db.getMaxID("ppID", "pastPapers");//Get Maximum ID

            count = db.Insert("'" + count + "', 'PastP'", "resourceCodes");//Add Datat to Resource Table
            db.closeConnection();

            count += db.Insert("'" + inputs[0] + "','" + inputs[1] + "'," + inputs[2] + "," + inputs[3] + ",'" + inputs[4] + "','" + inputs[5] + "','" + inputs[6] + "','" + inputs[7] + "'", "pastPapers");//Insert 
            db.closeConnection();
            return (count == 2);
        }
        public String showPastPapers(String searchTerm, String sType) {//Search and Return Past Papers
            db.establishConnection();
            db.reader = db.Select("*", "pastPapers", sType + " LIKE '%" + searchTerm + "%'").ExecuteReader();

            List<dynamic> bData = new List<dynamic>();
            while(db.reader.Read()) {
                bData.Add(new DataStructures.PastPapers {
                    ppID = db.reader.GetValue(0).ToString(),
                    title = db.reader.GetValue(1).ToString(),
                    programme = db.reader.GetValue(2).ToString(),
                    eyear = db.reader.GetValue(3).ToString(),
                    semester = db.reader.GetValue(4).ToString(),
                    fname = db.reader.GetValue(5).ToString(),
                    lname = db.reader.GetValue(6).ToString(),
                    eDate = db.reader.GetValue(7).ToString(),
                    pic = db.reader.GetValue(8).ToString(),
                });
            }

            db.closeConnection();

            return JsonConvert.SerializeObject(bData) + "|" + bData.Count;
        }
        public Boolean modifyPastPaper(String[] inputs) {//Modify Detail
            int status = db.Update("title = '" + inputs[1] + "', programme = '" + inputs[2] + "', eyear = " + inputs[3] + ", semester = " + inputs[4] + ", fname = '" + inputs[5] + "', lname = '" + inputs[6] + "', eDate = '" + inputs[7] + "'", "ppID = " + inputs[0], "pastPapers");
            db.closeConnection();
            return (status == 1);
        }
        public Boolean removePastPaper(String isbn) {//Delete record from database
            int status = db.Delete("resourceCodes", "rCode = '" + isbn + "'");
            db.closeConnection();

            status += status = db.Delete("pastPapers", "ppID = '" + isbn + "'");
            db.closeConnection();

            return (status == 2);
        }
        #endregion

        public object[] getLICDetails(String nic) {//Get Details of the Library Card
            db.establishConnection();

            object[] data = new object[] {"", "", "", "", "", ""};
            int count = 0;

            db.reader = db.Select("r.nic,r.sid,r.regCode,r.regDate,r.pic,p.firstName+' ' +p.lastName", "regCodes r, loginDetails l, personalDetails p", "r.nic='"+nic+"' AND r.regCode = l.regCode AND p.username = l.username").ExecuteReader();

            db.reader.Read();
            while(count < 6) {
                data[count] = db.reader.GetValue(count);
                count++;
            }

            db.closeConnection();
            return data;
        }

        public bool resouceValid(string rCode, string rType) {
            if(db.numberOfRows("resourceCodes", "rCode = '" + rCode + "' AND rType = '" + rType + "'") == 1)
                return true;
            return false;
        }
        public string getTitle(string table, string searchTerm) {//Get Title of Resource
            db.establishConnection();

            db.reader = db.Select("title",table,searchTerm).ExecuteReader();

            db.reader.Read();

            String title = db.reader.GetValue(0).ToString();

            db.closeConnection();
            return title;
        }
        public String getResourcePic(String table, String searchTerm) {//Get Picture of Resource
            db.establishConnection();

            db.reader = db.Select("pic", table, searchTerm).ExecuteReader();

            db.reader.Read();

            String pic = db.reader.GetValue(0).ToString();

            db.closeConnection();
            return pic;
        }

        public String getMemberPic(String username) {//Get the Profile pic of member
            db.establishConnection();

            db.reader = db.Select("r.pic", "regCodes r, loginDetails l", "(r.regCode = l.regCode) AND l.username = '"+username+"'").ExecuteReader();

            db.reader.Read();

            String pic = db.reader.GetValue(0).ToString();

            db.closeConnection();
            return pic;
        }
    }
}