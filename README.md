# 👾 Space-Invaders 👾
Hello world! In this project I tried out [Unity](https://unity.com/pages/unity-pro-buy-now?ds_rl=1295837&gclid=CjwKCAiAyfybBhBKEiwAgtB7fm7x9Pt-VpRfCr2USuDxuxxqBiMYTYaZIgE4l8B_yjF5fWM-FJle0RoCbO8QAvD_BwE&gclsrc=aw.ds) and implementing machine learning to a game with the [ml-agents framework](https://github.com/Unity-Technologies/ml-agents)! The game of choice being... Space Invaders! ✨ 

### Starting the AI 😸
Just start the game and watch the AI play! 

> I have made a few other models that can be tried out. To switch to another model, open the project via [Unity](unity.com/download) then inside the Unity editor click on the player game object and find the Agent component. The current model is ``The one`` but it can be easily changed.

### Lets train! ⚡️
So to train the machine learning agent, firstly there are a few prerequisites. Python and the ml-agents packages needs to be installed so that you can run the ``mlagents-learn`` command. I highly recommend reading this [installation guide](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Installation.md) if you would like to train the AI by yourself. 

Either way to train the AI start up the python API by entering ``mlagents-learn --time-scale=1 --run-id="Lets-Train-01`` from the TrainingConfig directory. Then just start the game and the agent will train and do its very best! 😇 

> If you would like to make changes to the agent the important scripts would be ``Player.cs``, ``BulletCollision.cs`` and ``Enemy.cs`` 🔧

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
```
### Agent properties 💽
- Set-up: A shooter environment with enemies aproaching the agent.
- Goal: The agent must destroy all enemies.
- Agents: The environment contains one agent.
- Agent Reward Function:
  - -0.003 for every bullet shot.
  - -1.0 if the enemies come too close.
  - -1.2 if the Agent comes in contact with an enemy bullet
  - +0.08 for every ufo destroyed.
  - +0.1 for every enemy destroyed.
  - +1.0 if all enemies are destroyed.
- Behavior Parameters:
  - Vector Observation space: (Continuous) 70 variables corresponding to 20
    ray-casts each detecting one of four possible objects (enemy, ufo, enemy bullet or
    cover).
  - Actions: 2 discrete action branch with 3 actions, corresponding to shoot a bullet, move along one axis, or do nothing.
- Float Properties: None
- Benchmark Mean Reward: -3.0
