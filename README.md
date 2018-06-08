# BrainWare Order List

This is a very small sample web application written in a very simplistic manner.

Grab the code and refactor it so that it meets your standard for production ready code.

There is no need to add additional functionality and you do not need to keep the existing code or project structure.

The only requirement is that it returns the list of orders and that it meets your standards!

## Changes for Running Locally

Update the connection string in the class <project root>\Web\Infrastructure\Database.cs.

Change the AttachDbFile name to the full path of the BrainWare.mdf file (located under <project root>\Web\App_Data\).

### If you get a SQL Version error while connecting

Check your instances of LocalDB with the commands

    > sqllocaldb i

>returns list of all instances of LocalDB on your computer
sqllocaldb i <DB_INSTANCE>
returns version of database instance 

You need version 13+ to attach the database to your LocalDB. 

If you have that version already installed, update the Data Source in the connection string to that instance name 
    
    Data Source=(LocalDb)\\<INSTANCE_NAME>

If not, get the latest version of SQL Server. Create an instance of localdb with the command:
    
    > sqllocaldb create v13.0 13.0

Then update the connection string.

## Original Output Example
![page image](output.GIF?raw=true)