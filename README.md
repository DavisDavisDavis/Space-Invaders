# Space-Invaders
Hello world! In this project I tried out Unity and implementing machine learning to a game! The game if choice being... Space Invaders! 👾✨ 

## Starting the AI 😸
I have made a few models that can be tried out. Open the project via [Unity](unity.com/download) then inside the Unity editor click on the player game object and find the Agent component. The current model is ``The one`` but it can be easily changed.

### Lets train! ⚡️
So to train the machine learning agent, first open up the project in [Unity](unity.com/download). Then install [Python](https://www.python.org/downloads/) and the [ml-agents]() python package. Following this [installation guide](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md) is highly recommended. I know it is a lot of prerequisites but it will totally be worth it! Now start up the ml-agents python API by entering ``mlagents-learn --time-scale=1 --run-id="Lets-Train-01`` from the TrainingConfig directory. Then stat the game and the agent will start training. 😲 

If you would like to make changes to the agent the important scripts would be ``Player.cs``, ``BulletCollision.cs`` and ``Enemy.cs``

### Playing the game 🎶
You can of course play the game yourself as well! Just go to the player game object and inside of the Agent component change the Behaviour from ``Default`` to ``Hueristics``. Now you can play with the arrow keys to move and space bar to shoot. 😎
