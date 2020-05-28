GET Articles 
Returns this page

GET Articles/{id}
Return specificed Article
Parameter id: The ID of the article to return
Returns Article or 404 if not found

GET Articles/ALL
Returns list of all Articles

POST Articles
Adds article to list
Paramters:
type: application/json
Body:
string author - The Author of the article
string headline - The Headline of the article
int year - The year of the article
string text - The content of the article

DELETE Articles
Removes an article from the list
Paramter id: The ID of the article to delete
Returns a confirmation on deletion or 404 if not found



There are two primary ways to get a Docker image to another target, like to a test machine or to a production server, either via publishing the image to a repository or via "docker save" to make a file to move manually, with docker load on the target environment.
Once the image is where it is to run, a simple docker run with the exposed port and port local to the image as well as the container name.
docker run -it --rm -p 3000:80 --name articleservicecontainer articleservice

A build server wouldn't work with the image, rather checkout the code and then build and run the image itself.

