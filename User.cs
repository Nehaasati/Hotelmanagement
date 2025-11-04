namespace App;


// a user class to manage logning in and loggning out.
// change to public class so we can access in program.cs and save user
public class User
{

  public string? UserEmail; // user's emailadress. 
  public string? _password; // //  user's password. 

  public User(string? useremail, string? password) // a constructor 
  {
    UserEmail = useremail; // assign the input email 
    _password = password; // assign the input password 
  }



  public bool TryLogin(string? useremail, string? password) // a boolean verification method to be called where want to check if the useremail and password are true. 

  {
    return useremail == UserEmail && password == _password;
  }

}