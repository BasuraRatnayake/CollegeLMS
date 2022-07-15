using System;
using System.Text.RegularExpressions;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS{
    public class Validation{
        private DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        public Boolean isNumber(String value) {//Check if String is Number or Characters
            int n;
            return int.TryParse(value, out n);
        }
        
        public Boolean NationalID(String nic){//Validate National Identification Number
            if(nic.Length == 10) 
                if(nic[9] == 'V') 
                    if(isNumber(nic.Substring(0, 9))) 
                        return true;
            return false;
        }
        public Boolean UniversityID(String uid) {//Valide University Identification Number
            if(uid.Length == 17) {
                String[] code = uid.Split('-');
                if(code[0] == "STAFF" || code[0] == "STUDY") 
                    if(code[1].Length == 3 && (code[1] == "LEC" || code[1] == "ACC" || code[1] == "OTH" || code[1] == "COM" || code[1] == "MAN" || code[1] == "LOG" || code[1] == "ADM"))
                        if(code[2].Length == 3 && isNumber(code[2]))
                            if(code[3].Length == 3 && isNumber(code[3]))
                                return true;
            }
            return false;
        }
        public Boolean RegCode(String regCode) {//Validate the Registration Code
            if(regCode.Length == 10) 
                if(isNumber(regCode[0].ToString())) 
                    if(!isNumber(regCode.Substring(1, 5))) 
                        if(isNumber(regCode[6].ToString()) && !isNumber(regCode[7].ToString())) 
                            if(isNumber(regCode[8].ToString()) && isNumber(regCode[9].ToString())) 
                                return true;
            return false;
        }

        public Boolean FirstLastName(String name) {//Validate First and Last Names
            if(name.Length >= 3 && name.Length <= 30 && (name != "City" && name != "First Name" && name != "Last Name")) 
                if(Regex.Match(name, "^[a-zA-Z ]*$").Success) 
                    return true;
            return false;
        }
        public Boolean StreetName(String street) {
            if(street.Length >= 5 && street.Length <= 60 && street != "Street Name")
                if(Regex.Match(street, "^[a-zA-Z0-9 /,#:]*$").Success)
                    return true;
            return false;
        }
        public Boolean PhoneNumber(String number) {
            if(number.Length == 10)
                if(Regex.Match(number, "^[0-9]*$").Success)
                    return true;
            return false;
        }
        public Boolean Username(String username) {
            if(username.Length >= 10 && username.Length <= 20)
                if(Regex.Match(username, "^[a-zA-Z_0-9]*$").Success) 
                    if(server.validUsername(username)) 
                        return true;
            return false;
        }
        public Boolean Email(String email){
            if(Regex.Match(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase).Success)
                if(server.validEmail(email))
                    return true;
            return false;
        }
        public Boolean Password(String password){
            if(password.Length >= 10 && password.Length <= 60)
                if(Regex.Match(password, "^[a-zA-Z_0-9. ]*$").Success)
                    return true;
            return false;
        }
    }
}