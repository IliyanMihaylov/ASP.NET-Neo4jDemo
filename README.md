# ASP.NET-Neo4jDemo
Application using Google plus, Facebook, Google Drive and Neo4j api.

#File format 
CSV files can be stored on the database server and are then accessible using a file:// URL. Alternatively, also supports accessing CSV files via HTTPS, HTTP, and FTP.

#Google file 
Google file must be in the following format. Users and Relationships should be separated with a new line. </br>
</br>
Users - file:///L:/UsersTest.csv </br>
Relationships - file:///L:/Site.csv

#Users file
Csv file with Users. The file must be start with headers.</br>
</br>
id,name,eyes,email </br>
1,"borqna","blue","broqna@abv.bg" </br>
2,"iliyan","red","iliyan@abv.bg" </br>
3,"krasen","brown","krasen@abv.bg" </br>

#Relationships file
Csv file with relationships. The file must be start with headers. </br>
</br>
fromId,toId </br>
1,3</br>
1,2</br>
2,3</br>
3,1</br>
