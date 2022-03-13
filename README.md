### Setting up the project

I apologize in advance for the hack that was done to enable something like this. I was running out of time and kinda slapped this together with the best of my abilities.

#### First step

You will want to download the brewery data

#### Second step

Take the csv that was downloaded with the full brewery information and load it into your sql server mangement tool

I created a brewerydb in the mangement console and then did a flat file upload without chaning any data entries

#### Third step

I added a new column to the db with an identity and then set the primary key for use later on

Note: all the fields that were imported as text so any queries that will be done on those columns will need to be converted to varchar(max). Visual studio does not support filtering on text


### Other notes

I realize this project is more hack and slash. A lot of the files were pregenerated to get things working but I ran out of time to debug issues.

I would have liked to actually make a migration that setup the db and everything from the git get but my lack of knowledge prevented me from doing so. I can add and make dummy data but loading from a csv was a little over my head for this... 

Linq is very powerful especially from coming from the land of JS and sql stored procs...