# Monopoly
*v2*
**Project by Bouvet Xavier and Cantie Maxime**

The project was to create a Monopoly game implementing different design pattern , for this we choosed a Singleton, an Observer and a Factory design pattern.

**THE SINGLETON**

We decide to use a singleton for the Board because we knew there would only be one and it would contains most of the important information such as the list of the players, a function to know when the game is over and the board initialization .

**THE OBSERVER**

We choosed to use an observer to notify all the players when a property was purchased by another player so they can have and idea of the evolution of the game and who owns which property (notify the players when the ownership change too for further expension conserning trade of properties).

**THE FACTORY**

We decide to use the factory to create the board, the factory create two entities which are either property or Action case, so we can configure each case as one of them when implementing the board. 
