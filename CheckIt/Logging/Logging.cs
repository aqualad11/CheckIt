using System;

namespace CheckIt.Logging
{
    public class Logging
    {
        //Method for creating a log
        //Method for appending to a log file
        //Method for error log creation

        //Check Vue Logs

        //Vuetify-vscode Vue Framework


        //Vue below when making a call to the server (after axios call)
        /*.catch((error) => (
            this.$log(error)
            window.alert('Error with run. Look in console')
        ))
        */

        //Vue Plugins

        //Logs dont go towards a Database
            //Too much overhead with the DB
                //Last resort, log to a different DB than the operational DB
        //Logging to a flatfile is harder to analyze
            //have to read the file line by line
        //NoSQL datastore is best for logs
            //Analytical queries are better than SQL
            //Document based NoSQL
                //Graph DB, KEYVALUE DB, Index DB
    }

}
