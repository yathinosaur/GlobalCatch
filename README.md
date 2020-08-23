# Catch! (Around-The-World)

## Our Inspiration

Catch has to be one of our most favourite ~childhood~ games. Something about just throwing and recieving a ball does wonders for your serotonin. Since all of our team members have relatives throughout the entire world, we thought it'd be nice to play catch with those relatives that we haven't seen due to distance. Furthermore, we're all learning to social distance (physically!) during this pandemic that we're in, so who says we can't we play a little game while social distancing?

## What it does

Our application uses AR and Unity to allow you to play catch with another person from somewhere else in the globe! You can tap a button which allows you to throw a ball off into space, and then the person you send the ball to will be able to catch it and throw it back. We also allow users to chat with one another using our web-based chatting application so they can have some comentary going on while they are playing catch.

## How we built it

For the AR functionality of the application, we used Unity and then to record the user sending the ball to another user, we used a Firebase back-end. We also utilized EchoAR to create different 3D objects that users can choose to throw. This lets the application know that user A has sent a ball to user B, so a ball should show up on user B's screen. Furthermore for the chat application, we developed it using Python (Flask), HTML and Socket.io in order to create bi-directional communication between the web-user and server.

## Challenges we ran into

Initially we had a seperate idea for what we wanted to do in this hackathon. After a couple of hours of planning and developing, we realized that our goal is far too complex and it was too diffcult to complete in the given timeframe. As such, our biggest challenge had to do with figuring out a project that was doable within the time of this hackathon.

This also ties into another challenge we ran into was with initially creating the application and the learning portion of the hackathon. We did not have experience with some of the technologies we were using, so we had to overcome the inevitable learning curve. 

## Accomplishments

* Working Unity application with AR
* Use of EchoAR and integrating with our application
* Learning how to use Firebase
* Creating a working chat application between multiple users

## What's next?

- [x] Demo at HackThe6ix!
- [ ] Have a clearer transition
- [ ] Play catch with strangers (implementing directional throwing)
- [ ] Sense how far and hard user wants to throw ball
