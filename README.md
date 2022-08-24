Test Instructions
The point of this test is to see your familiarity and experience with database schema design, using Entity Framework, and writing APIs.
Your task is to create a restaurant reservation system.
You will need to:
Create the database for restaurant reservation
Write an API that will do the booking
(As a Bonus, if time permits) Secure the API so that anonymous connections are not allowed
Specifications:
If you need to make assumptions, please be sure to let us know during the debrief interview and walk us through your decision process.
There are multiple restaurants in our system.
Each restaurant may have one or more locations.
Each location has multiple tables.
There are only 3 different table sizes to choose from.
Small - up to 2 people
Medium - up to 4 people
Large - up to 8 people
The correct table size will automatically be chosen based on the size of the party.
3 person reservation will require a Medium size table
5 person reservation will require a Large size table
3 person reservation will never use a large size table even if there are no more Medium size tables left
Reservations for more than 8 people are not allowed.
Reservations can only be booked on the hour. That is, at 6pm or 7pm or 8pm. 6:30pm is not allowed.
A reservation will be exactly one hour in duration.
Reservations are only valid when the restaurant is open.