# Phasmophobia-Wiki
A wiki page for the game Phasmophobia.  This uses evidence found in-game, along with other community sites to make it easier to determine what ghost you are dealing with.

# Running the Application within your IDE:
The web application listens on port 8000 over HTTP.  The application can be started by using the following launch profile from within Visual Studio or Rider:

![image](https://user-images.githubusercontent.com/94319888/215604371-f17a380b-a114-48fe-a30e-dbbc9773fbfb.png)

Running the HTTP launch profile should open the following page within your browser:

![image](https://user-images.githubusercontent.com/94319888/215604905-f7b32a8f-de54-4997-b48f-67c6d001c8cd.png)

# Running the Application within Docker:
The Web Application has also been containerized.  If you download the Dockerfile and docker-compose.yaml files from within the 'Docker' subfolder within this repository, you can build the Dockerfile and run it using the following command:

![image](https://user-images.githubusercontent.com/94319888/215612801-7a7bdaa3-86fb-4c9d-9006-bc0ec6f80b8d.png)

This will pull the source files from GitHub, build them and launch the application, meaning it does not require any volume mappings.  This again, will run on port 8000.

# Planned development items:
-Using IMemoryCache at the service layer.

-Addition of Unit tests. (work started)
