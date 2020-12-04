*Benjamin Brownlie* |
|--- |
First Year Game Programming |
Math For Games Assessment |

## Program Requirement
Create a program that demonstrates the following requirements.

***List of Requirements***
> - Example of matrix heirarchy
> - Example of game objects moving using velocity and acceleration with vectors
> - Example of simple collision detection
> - MathLibrary passes unit test

## Documentation
The following is a list of the classes and functions used in the program along with their purpose.


### Game Class
Class used as the main engine for the program.

> #### Functions and Properties
> - GetSceneIndex- Returns the variable _currentSceneIndex
>
> - GetScene(int index)- Returns the array _scenes[] at the index of index
>
> - GetCurrentScene()- Returns the array _scenes[] at the index of _currentSceneIndex
>
> - AddScene(Scene scene)- Function used for adding more scenes to the scene[] array
>
> - RemoveScene(Scene scene)- Function used for removing scenes from the scene[] index
>
> - SetCurrentScene(int index)- Used for setting the game's current scene to the number passed in
>
> - GetKeyDown(int key)- Returns whether a key is being held down
>
> - GetKeyPressed(int key)- Returns whether a key is pressed
>
> - Game()- sets _scene to a new scene at the index of 0. _scene = new Scene[0]
>
> - SetGameOver(bool value)- Used to set the game over without an instance of game
>
> - Start()- Called at the start of the program and executes all code once
>
> - Update(float deltaTime)- Called every frame
>
> - Draw()- Displays actors to the screen
>
> - End()- Called when the program ends
>
> - Run()- Used to handle all the main game logic

### Scene Class
Class used for handling events that go on in a scene

> ### Functions and Properties
>
> - World- Returns the variable _transform
>
> - Started- A get set property
>
> - Scene()- Sets the variable _actors to a new Actor[] at the index of 0. _actors = new Actor[0]
>
> - AddActor(Actor actor)- Used for adding actors to the scene
>
> - RemoveActor(Actor actor)- Used to remove an actor from the scene
>
> - CheckCollision()- Used to check whether the actors in the scene are within collision distance, if so calls Actor's OnCollision function
>
> - Start()- Sets Started's value to true
>
> - Update(float deltaTime)- Called everyframe for actors, checks for collision
>
> - Draw()- For all actors in the scene, calls their draw function
>
> - End()- For all actors, calls their end function. Sets Started to false

### Actor Class
Used to handle all the attributes for an actor

> ### Functions and Properties
>
> - Started- A get set property
>
> - Forward- Returns a new Vector2 with the parameters _globalTransform.m11 and _globalTransform.m21
>
> - SetTranslation(Vector2 position)- Used for setting the actors _position in the world by calling Matrix3.CreateTranslation and passing in position
>
> - SetRotation(float radians)- Used for setting the actors _rotation by calling Matrix3.CreateRotation and passing in radian
>
> - SetScale(float x, float y)- Used for setting the actors _scale by calling Matrix3.CreateScale and casting the passed in x y as a vector2
>
> - UpdateTransform()- Sets the variable _localTransform to thr value of _translation * _rotation * _scale
>
> - CheckCollision(Actor other)- Finds the combined radius of the actor passed in and the actor colliding, finds the distance by subtracting their world positions and finding the magnitude. Returns true if the actors are colliding
>
> - WorldPosition- Returns the actors position in the world
>
> - LocalPosition- Returns the actors local position
>
> - Velocity- Returns the variable _veloctity, sets _velocity to a value
>
> - Actor()- A constructor for actor
>
> - Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)- Constructor for actor taking in 4 arguments
>
> - AddChild(Actor child)- Function for adding a childed actor to an array of child actors
>
> - RemoveChild(Actor child)- Function for removing a child from the array
>
> - Acceleration- gets the variable _acceleration and sets it to a value
>
> - MaxSpeed- returns the variable _maxSpeed and sets it to a value
>
> - Start()- Called at the beginning of the program, sets Started to true
>
> - Update(float deltaTime)- Called every frame, calls UpdateTransform(), adds Velocity and Acceleration's values, adds and sets LocalPosition to _velocity * deltaTime
>
> - Draw()- used to display the actors in the console window
>
> - End()- called at the end of the program

### Player Class
Used to handle the attributes of a player, inherits from Actor

> ### Functions and Properties
>
> - Speed- property used return the variable _speed and set it to a value
>
> - Player()- Constructor that takes in 4 arguments and calls the base constructor, sets the variable _playerSprite to be a new sprite at the designated path.
>
> - Player()- Constructor that takes in 5 arguments and calls the base constructor, sets the variable _playerSprite to be a new sprite at the designated path.
>
> - CreateBullet(Projectile bullet)- Function used for creating projectile actors. **Note: This function currently has no purpose and was for testing purposes**
>
> - Update(float deltaTime)- Used for moving the player manually in the console window and calls the base actor update
>
> - Draw()- Draws the player's sprite and calls the base actor draw

### Enemy Class
Used to handle the attributes of an enemy, inherits from Actor

> ### Functions and Properties
>
> - Target- returns the target and sets it to a value. **Note: The target feature currently is not being used the enemy class**
>
> - Constructors- Enemy uses the same constructors as Player, sets the variable _enemySprite to be a new sprite at the designated path.
>
> - CheckTargetInSight(float maxAngle, float maxDistance)- Uses the passed in values to check whether the target is in their line of sight
>
> - Start()- Called at the beginning of the program
>
> - Update(float deltaTime)- Calls CheckTargetInSight and the base actor update
>
> - Draw()- Draws the actor's sprite and calls the base actor draw

### Projectile Class
Used to handle the attributes of a projectile, inherits from Actor

**Note: Currently the Projectile class is not being used and is just for experimenting, will probably try and get it working after the assessment**

> ### Functions and Properties
>
> - Speed- Property used to get the variable _speed and set it to a value
>
> - Projectile(Vector2 direction, Vector2 origin, float speedVal, float damageVal, char icon, ConsoleColor color = ConsoleColor.White)-
Takes in a direction and origin vector2 and sets the variables _speed and _damage to speedVal and damageVal, sets the variable _bulletSprite to be a new sprite at the designated path.
>
> - CheckCollision(Actor other)- Currently only calls the base CheckCollision function
>
> - Update(float deltaTime)- Calls the base update function



## MathLibrary Documentation
This documentation for the redistributable MathLibrary

### Vector4 class
Vector class that uses 4 floats
> #### Variables
>
> - floats that are used to represent x, y, z, and w. _'s are used in the names for accessability and to note that they are private
>
> ### Functions and Properties
>
> - XYZW properties- These properties are used to get the variables that represent xyzw and set them to a value
>
> - Magnitude- Property used to return the square root of X + X * Y + Y * Z + Z * W + W casted as a float
>
> - Normalized- Property used to return the normalized version of a value
>
> - Normalize(Vector4 vector)- Returns the magnitude of a passed in vector4
>
> - DotProduct(Vector4 lhs, Vector4 rhs)- Returns the Dot product of the variables passed in for the left hand side(lhs) and the right hand side(rhs)
>
> - CrossProduct(Vector4 lhs, Vector4 rhs)- Returns the Cross product of the variables passed in for lhs and rhs
>
> - Vector4()- Used to set xyzw to 0
>
> - Vector4(float x, float y, float z, float w)- Sets the value of _x _y _z _w to be the value passed in
>
> - Operator Functions- Functions allowing for Vectors to add, subtract, multiple and divide by other vectors and floats

### Vector3 class
Vector class that uses 3 floats
> #### Variables
>
> - 