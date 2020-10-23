# vending-machine
Technology Stack : .NET CORE 2.2

IDE : Visual Studio 2019

Installation Steps : 

	1. Clone the repository
	2. Build Solution
____________________________

The given repository contains a well structured opsedo code that shows the object oriented fundementals and algorithm which usen to solve the problem of vending-machine,
I've built the task using the common design patterns which are related to the vending machine problem after doing the research part which made me understand the big picture to solve
the current problem and build a well proper solution.
 
 Design patters :
 
	  1. Dependancy injection
	  2. Singelton
	  3. pubsub
	  4. Factory
	  5. Lazy Loading
 
 Algorithms :
 
		1. Greedy for coin change ( see the description and written code in the task)
  
 User Flow : 
 
	 1. users select the vending machine he wants to use. 
	 2. get single instance of the snacks vending machine through the Factory. 
	 3. initialize products.
	 4. each product has a certain price and row/column index.
	 5. the user select payment method.
	 6. the machine validates input money if it is one of the allowed coins/note.
	 7. there are different consumers/ push message depends on the user selection which will listen and validate the amount.
	 8. consumers after validating will send the remaining money ( input money - product price) to CoinChange class which is built over the Greedy algorithm to
		calculate and return the array of money changes including ( coins and notes).