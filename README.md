# 👾 Space-Invaders 👾
Hello world! In this project I tried out [Unity](https://unity.com/pages/unity-pro-buy-now?ds_rl=1295837&gclid=CjwKCAiAyfybBhBKEiwAgtB7fm7x9Pt-VpRfCr2USuDxuxxqBiMYTYaZIgE4l8B_yjF5fWM-FJle0RoCbO8QAvD_BwE&gclsrc=aw.ds) and implementing machine learning to a game with the [ml-agents framework](https://github.com/Unity-Technologies/ml-agents)! The game of choice being... Space Invaders! ✨ 

### Starting the AI 😸
Just start the game and watch the AI play! I have made a few other models that can be tried out. To switch to another model, open the project via [Unity](unity.com/download) then inside the Unity editor click on the player game object and find the Agent component. The current model is ``The one`` but it can be easily changed.

### Lets train! ⚡️
So to train the machine learning agent, firstly there are a few prerequisites. Python and the ml-agents packages needs to be installed so that you can run the ``mlagents-learn`` command. I highly recommend reading this [installation guide](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md) if you would like to train the AI by yourself. 

Either way to train the AI start up the python API by entering ``mlagents-learn --time-scale=1 --run-id="Lets-Train-01`` from the TrainingConfig directory. Then just start the game and the agent will train and do its very best! 😇 

> If you would like to make changes to the agent the important scripts would be ``Player.cs``, ``BulletCollision.cs`` and ``Enemy.cs``

### Playing the game 🎶
You can of course play the game yourself as well! Just go to the player game object and inside of the Agent component change the Behaviour from ``Default`` to ``Hueristics``. Now you can play with the arrow keys to move and space bar to shoot. 😎
```

░░░░░░░░░░░░░░░░░
░░░░░▀▄░░░▄▀░░░░░
░░░░▄█▀███▀█▄░░░░
░░░█▀███████▀█░░░
░░░█░█▀▀▀▀▀█░█░░░
░░░░░░▀▀░▀▀░░░░░░
░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░
░░░▄░▀▄░░░▄▀░▄░░░
░░░█▄███████▄█░░░
░░░███▄███▄███░░░
░░░▀█████████▀░░░
░░░░▄▀░░░░░▀▄░░░░
░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░
░░░░▄▄████▄▄░░░░░
░░░██████████░░░░
░░░██▄▄██▄▄██░░░░
░░░░▄▀▄▀▀▄▀▄░░░░░
░░░▀░░░░░░░░▀░░░░
░░░░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░░
░░░░░░▄██▄░░░░░░░
░░░░▄██████▄░░░░░
░░░███▄██▄███░░░░
░░░░░▄▀▄▄▀▄░░░░░░
░░░░▀░▀░░▀░▀░░░░░
░░░░░░░░░░░░░░░░░
