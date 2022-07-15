using System;
using System.Collections;
using System.Linq;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS{
    public class Encryptions{
        protected String[] words(){
            return new string[] { "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "duis", "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie", "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eros", "et", "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum", "zzril", "delenit", "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis", "nostrud", "exerci", "tation", "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "duis", "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie", "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eros", "et", "accumsan", "et", "iusto", "odio", "dignissim", "qui", "blandit", "praesent", "luptatum", "zzril", "delenit", "augue", "duis", "dolore", "te", "feugait", "nulla", "facilisi", "nam", "liber", "tempor", "cum", "soluta", "nobis", "eleifend", "option", "congue", "nihil", "imperdiet", "doming", "id", "quod", "mazim", "placerat", "facer", "possim", "assum", "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat", "volutpat", "ut", "wisi", "enim", "ad", "minim", "veniam", "quis", "nostrud", "exerci", "tation", "ullamcorper", "suscipit", "lobortis", "nisl", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "duis", "autem", "vel", "eum", "iriure", "dolor", "in", "hendrerit", "in", "vulputate", "velit", "esse", "molestie", "consequat", "vel", "illum", "dolore", "eu", "feugiat", "nulla", "facilisis", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "at", "accusam", "aliquyam", "diam", "diam", "dolore", "dolores", "duo", "eirmod", "eos", "erat", "et", "nonumy", "sed", "tempor", "et", "et", "invidunt", "justo", "labore", "stet", "clita", "ea", "et", "gubergren", "kasd", "magna", "no", "rebum", "sanctus", "sea", "sed", "takimata", "ut", "vero", "voluptua", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor", "sit", "amet", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et", "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et", "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata", "sanctus", "est", "lorem", "ipsum" };
        }//Word List
        protected ArrayList wordList = new ArrayList();//Operatable Word List
        protected void setWordArrayList(int limit){//Make Array List
            for(int i = 0; i < words().Length; i++)
                if(words()[i].Length == limit)
                    wordList.Add(words()[i]);
        }

        private Random random = new Random();//Random Number Generator
        private int ranNumber = 0;//Random Number
        private String randomCode = "";//Random Code

        private DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        
        public String generateRegCode(String uid, String nic){//Generate Registration Code from NIC, UID
            randomCode = "";
            setWordArrayList(5);
            ranNumber = random.Next(wordList.Count - 1);

            nic = nic.Substring(0, 8);
            uid = (uid.Substring(10, uid.Length-10)).Replace("-","");
            
            randomCode += nic.ToArray()[random.Next(nic.ToArray().Length - 1)];
            randomCode += wordList[ranNumber];

            randomCode += uid.ToArray()[random.Next(uid.ToArray().Length - 1)];

            ranNumber = random.Next(wordList.Count - 1);
            randomCode += wordList[ranNumber].ToString().Substring(0, 1);
            randomCode += uid.ToArray()[random.Next(uid.ToArray().Length - 1)];
            randomCode += nic.ToArray()[random.Next(nic.ToArray().Length - 1)];

            randomCode = randomCode.ToUpper();

            Boolean codeK = server.regCodeAvailable(randomCode);//Check whether code already in db

            if(!codeK)//If Code Available recode
                randomCode = generateRegCode(uid, nic);

            if(randomCode.Length != 10)
                generateRegCode(uid, nic);

            return randomCode;
        }
        public String generateCode5(){//Generate a code of 5 unique characters
            randomCode = "";
            setWordArrayList(3);
            ranNumber = random.Next(wordList.Count - 1);

            randomCode = wordList[ranNumber].ToString().ToLower() + ranNumber;

            return randomCode;
        }

        public String[] exploreNIC(String nic){//Get NIC Data
            int year = Convert.ToInt16(nic.Substring(0, 2))+1900;//Store Month
            int days = Convert.ToInt16(nic.Substring(2, 3));//Get number of days
            int[] months = new int[] {
                31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
            };

            String gender = "Male";

            if(days > 500){
                gender = "Female";
                days = days - 500;
            }
            int i;
            for(i = 0;i < months.Length;i++){
                if(days > months[i])
                    days = days - months[i];
                else
                    break;
            }
            if(days < 10) 
                days = 1;

            return new String[]{
                days.ToString()+"/"+(i+1).ToString()+"/"+year.ToString(), gender
            };           

        }

        public String makePasswordX(String password){//Change Password to X
            String newPass = "";
            for(int i = 0;i<password.Length;i++) 
                newPass += "X";
            return newPass;
        }
    }
}
