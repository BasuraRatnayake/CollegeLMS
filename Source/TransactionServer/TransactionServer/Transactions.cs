using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TransactionServer {
    public class Transactions:ITransactions {
        protected Database db = new Database();

        private String currentDate;//Today
        private String returnDate;//Today + 7 days
        private void setDates() {//Set Today and Current Date
            currentDate = DateTime.Now.ToString().Split(' ')[0];
            currentDate = currentDate.Split('/')[2] + "-" + currentDate.Split('/')[1] + "-" + currentDate.Split('/')[0];//Current Date

            returnDate = DateTime.Now.AddDays(7).ToString().Split(' ')[0];
            returnDate = returnDate.Split('/')[2] + "-" + returnDate.Split('/')[1] + "-" + returnDate.Split('/')[0];//Current Date
        }

        private int updateIssuedTable(String regCode) {//Send Data to the issuedCount
            int count = 0;
            if(db.numberOfRows("issuedCount", "memberId = '" + regCode + "'") == 0)
                count += db.Insert("'" + regCode + "', 1", "issuedCount");
            else{
                db.establishConnection();
                db.reader = db.Select("rCount", "issuedCount", "memberId = '" + regCode + "'").ExecuteReader();
                db.reader.Read();

                int rCount = Convert.ToInt16(db.reader.GetValue(0)) + 1;
                db.closeConnection();

                count += db.Update("rCount = " + rCount, "memberId = '" + regCode + "'", "issuedCount");
            }
            db.closeConnection();

            return count;
        }

        #region Issue
        public Boolean issueBook(String regCode, String resId, String type) {//Issue Book to Member
            setDates();//Set Today and Current Date

            int count = db.Insert("'" + regCode + "','" + resId + "', '" + type + "', '"+ currentDate + "', '"+ returnDate + "', 'N'", "issueBook");
            db.closeConnection();

            count += updateIssuedTable(regCode);

            return (count == 2);
        }

        public Boolean issueComic(String regCode, String resId) {//Issue Comic to Member
            setDates();//Set Today and Current Date

            int count = db.Insert("'" + regCode + "','" + resId + "', '" + currentDate + "', '" + returnDate + "', 'N'", "issueComic");
            db.closeConnection();

            count += updateIssuedTable(regCode);

            return (count == 2);
        }
        public bool issuePastP(string regCode, string resId) {//Issue Past Paper to Member
            setDates();//Set Today and Current Date

            int count = db.Insert("'" + regCode + "','" + resId + "', '" + currentDate + "', '" + returnDate + "', 'N'", "issuePastP");
            db.closeConnection();

            count += updateIssuedTable(regCode);

            return (count == 2);
        }

        public bool issueNewsMag(string regCode, string resId, string type) {//Issue Comic to Newspaper/Magazine
            setDates();//Set Today and Current Date

            int count = db.Insert("'" + regCode + "','" + resId + "', '" + type + "', '" + currentDate + "', '" + returnDate + "', 'N'", "issueNewM");
            db.closeConnection();

            count += updateIssuedTable(regCode);

            return (count == 2);
        }

        public bool issueVidDoc(string regCode, string resId, string type) {//Issue Comic to Video/Documentry
            setDates();//Set Today and Current Date

            int count = db.Insert("'" + regCode + "','" + resId + "', '" + type + "', '" + currentDate + "', '" + returnDate + "', 'N'", "issueVidD");
            db.closeConnection();

            count += updateIssuedTable(regCode);

            return (count == 2);
        }
        #endregion

        public bool resourcedIssued(String table, String searchTerm) {//Check if resource valid for issue
            int count = db.numberOfRows(table, "rCode = '"+searchTerm+"' AND returned = 'N'");
            return (count == 0);
        }


        public int unReturnedCount(String memberID) {//Get the Number of Resources Issued
            int count = 0;

            if(db.numberOfRows("issuedCount", "memberId = '" + memberID + "'") == 0)
                count = 0;
            else{

                db.establishConnection();

                db.reader = db.Select("rCount", "issuedCount", "memberId = '" + memberID + "'").ExecuteReader();

                db.reader.Read();
                count = Convert.ToInt16(db.reader.GetValue(0));

                db.closeConnection();
            }

            return count;
        }

        public Boolean returnResource(String memberCode, String resourceCode, String table) {//Return Resource to Library
            int status = unReturnedCount(memberCode);

            if(status>0)
                status--;

            status = db.Update("rCount = "+status, "memberId = '"+memberCode+"'", "issuedCount");//Change the borrow count
            db.closeConnection();

            status += db.Update("returned = 'Y'", "memberId = '"+memberCode+"' AND rCode = '"+resourceCode+"'", table);//Change the return type of resource from N to Y
            db.closeConnection();

            return (status == 2);
        }

        public String issuedResources(String searchTerm) {//Get List of Issued Resources
            int count = 0;
            int tblCount = 0;
            String[] tables = new String[]{
                "issueBook", "issueNewM", "issueVidD", "issueComic", "issuePastP"
            };

            List<dynamic> rData = new List<dynamic>();

            while(tblCount <tables.Length) {
                count = db.numberOfRows(tables[tblCount], searchTerm);
                if(count > 0) {
                    db.establishConnection();
                    db.reader=db.Select("*", tables[tblCount], searchTerm+" ORDER by issueDate").ExecuteReader();

                    while(db.reader.Read()) {
                        DataStructures.issuedResources iR=null;

                        if(tables[tblCount]!="issueComic" || tables[tblCount]!="issuePastP") {
                            iR=new DataStructures.issuedResources {
                                unCode=db.reader.GetValue(0).ToString(),
                                memberId=db.reader.GetValue(1).ToString(),
                                resourceId=db.reader.GetValue(2).ToString(),
                                rType=db.reader.GetValue(3).ToString(),
                                issueD=db.reader.GetValue(4).ToString().Split(' ')[0],
                                returnD=db.reader.GetValue(5).ToString().Split(' ')[0],
                                table=tables[tblCount]
                            };
                        }

                        rData.Add(iR);
                    }
                    db.closeConnection();
                }
                tblCount++;
            }
            return JsonConvert.SerializeObject(rData)+"|"+rData.Count;
        }
    }
}
