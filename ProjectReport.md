# Code Review Report
Course: C# Development SS 2023 (4 ECTS, 3 SWS)

Student ID: cc211010

BCC Group: B

Name: Ana Bonavides Aguilar

Your Project Topic: Dijkstra’s Algorithm

#

### A Short Summary about the Algorithm (What is the Background and the Motivation of having such an algorithm?): 
This algorithm was created by Edsger W.Dijkstra, to find the shortest path between two nodes in a weighted graph. It is important as in a lot of fields it is necessary to find the shortest path between two points. For example, between two cities. And, even though it is not the most performant, it lets you have, from a source, all the possible shortest paths you can have.

### Implementation Details

#### Implementation Logic Explanation:
I started by defining which was the easiest and most effective way of asking for the graph information to the User. For me and other of my collegues, writing the information as an Adjecency Matrix was the easiest way (as I wanted to let the user have a weighted directed graph.) Because of it, I defined my main user input as the 

#### Achievements:
(List down and explain what achievements you are proud of (e.g., features, techniques, etc.) in the project. Please explain in detail.)
1. I really like that you are able to generate multiple graphs, not only one, and get the paths of all of them. I achieved this by implementing a class's structure that lets the Algorithm have n amount of graphs. As a user, you are able to identify the different graphs outputs as the output file is a combination between the Graph's name (that must be defined at the beginning), and the emding "Output.txt".

### Learned Knowledge from the Project
1. Something really specific that I learned was that array's size can be defined at runtime...It was surprising that I did not know, but also great having learned it.
2. I realized that the way I like the most to go about developing is first thinking of the way I want to input the data, and then, based on it, define which will be my structure to store it. I heard this once from my boyfriend and tried it for the project. I really liked it!
3. Sometimes we need to choose between having a "better" solution, to a solution that will be able to be mantained. There was some code that got really intertwined at some point, and I needed to make the choice of adding more lines of code to achieve it, or store some more variables. Even though these were not needed, it let me continue to work with the code without getting confused.


#### Major Challenges and Solutions:
(List down and explain the major challenges. Did you solve it? How? Please explain in detail.)
1. Keeping the code clean and understandable was a big challenge. There were some challenges I wanted to tackle, like outputing the data, where the places I was storing information made no sense duirng my first iteration of the code. For that one, for example, I ended up creating a function in my Algorithm class that returns the information I want to output as a string, that way my Main program does not need to handle printing.

#### Minor Challenges and Solutions:
(List down and explain the minor challenges. Did you solve it? How? Please explain in detail.)
1. Keeping the if-else code logic was hard at some points, I really needed to ask myself "which result do I want to achieve'and made it work before I tried to make it more efficient.

### Reflections on the Own Project:
(List down and explain what you could improve and add if you have more time.)
1. Item
2. Item, and so forth

### Reflections on the Projects learned during the Presentation:
(List down and explain what you have learned from your colleague’s codes and what you should pay attention to when writing codes next time.)
1. Item
2. Item, and so forth
