# iMusic

<a href="https://resimlink.com/Q1fU" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/Q1fU.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a>


# The goal of the project:

Users (Premium and regular users) will listen to songs, Premium users
playlists can be followed and all users can create their own playlists.
A database will be developed for music application. **Desktop application** will be implemented.

## Description:

System; It consists of admin and users. Admin; adding, updating songs, artists, albums,
makes deletions. User; Listening to songs, following songs, artists, albums, playlists
It is the end user who can create their own lists.
- Admin and user will log into the system with separate interfaces. Tables for server and user
will be created and powers will be determined. For example, the user's ability to add songs, add artists
This authorization will only be by the admin side.
- Admin; Updates for adding or deleting new artists, songs and albums
will be able to. Song ID, Song Title, date, artist album, genre, duration, number of times for the song,
information will be. A song can have more than one artist. A song can only be in one album.
- There will be ID, Artist name, Country information for the artist. Album information is; albumId, album name,
It should contain information about the artist, song, date and genre. Multiple songs and multiple artists in one album can be found.
- User ID, user name, email, password, subscription type (Normal / Premium),
country information should be included. Users can be either Premium or regular members. Premium users must have paid information. Premium users will be able to be followed by regular users.
- Users will be able to view and save the playlists of the users they follow.

## Scenario and Problems
### Problem 1: Extra features should be offered for premium users 

Info: Only Premium users can be followed by other users and premium users
When users are followed, the playlists will be open to sharing for their followers. All users
will be able to view the playlists of the people they follow. For any tracking process,
User permission is not required. Normal users can follow Premium users,
It can create playlists but they cannot be followed and the playlists are also not available for sharing.

### Problem 2: Each user will have three Playlists (Pop-Jazz-Classic).

Information: When a user is registered to the system, three playlists will be created for that user. Blankly
The user will be able to add the songs they want to these created lists. Three music genres in the database
enough. Pop, Jazz, Classic. Each time the user adds the songs listed on the homepage to the playlist,
must be added to the playlist of the same name as the song genre.

### Problem 3: Users will be able to access the lists of the users they follow, and add the songs in their playlists to their own playlist.

Info: All users can view the songs in the playlists of the users they follow or the list
will be able to add all of them to their own playlists. If a song already exists in its playlist,
will not be added. Songs must be saved in the same playlist.

### Problem 4: Automatically generated lists will be displayed in the user module.

Information: The number of hits will be kept for each song. Created according to musical genres (pop, jazz, classical)
The list of the 10 most listened songs, the list of the 10 most listened songs in general,
Lists of 10 tracks listened to must be available to the user


### Problem 5. When admin performs add - delete - update operations on tables, related tables will also be updated.


Information: When a song is added-deleted-updated, that song is added to all playlists,
it must be deleted and all the playlists must be updated. The same operations are performed by artist, album and other
should also be applied for tables


:pushpin: Some images from the project: <br>
<a href="https://resimlink.com/jTislDc" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/jTislDc.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a><br>
<a href="https://resimlink.com/RbOLEA" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/RbOLEA.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a><br>
<a href="https://resimlink.com/nS1xM" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/nS1xM.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a><br>
<a href="https://resimlink.com/KgrQfj" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/KgrQfj.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a><br>
<a href="https://resimlink.com/5hAU" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/5hAU.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a><br>
<a href="https://resimlink.com/ODETWkh6" title="ResimLink - Resim Yükle"><img src="https://r.resimlink.com/ODETWkh6.png" title="ResimLink - Resim Yükle" alt="ResimLink - Resim Yükle"></a><br>


