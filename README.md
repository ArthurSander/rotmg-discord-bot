# RotMG Discord Bot
A friendly, open-source RotMG Discord Bot.

This bot is currently in the early stages of development, but I'm always open to listening to constructive criticism and adding new features that you develop through Pull Requests.

This repository will serve as the base for another one, not limited to [RotMG](https://www.realmofthemadgod.com/) Discord servers but suitable for any staff-based server!

Feel free to reach out to me if you need any guidance on using/contributing to this project!

## How to use (WIP)
During the early stages, we're focusing on developers. In the future, we plan to make the project ready-to-go on any computer or server through containers.

### Pre-Requisites

- .NET 8 SDK
- C# IDE - Visual Studio is recommended (optional)

### Steps
1. Clone the repository on your computer or server.
2. [Create a Discord Bot](https://www.ionos.com/digitalguide/server/know-how/creating-discord-bot/).
3. [Get your Bot's Token](https://docs.discordbotstudio.org/setting-up-dbs/finding-your-bot-token).
4. In the root folder of this repository, you'll find an `appsettings.example.json`; 
    - Rename it to `appsettings.json`.
    - Open `appsettings.json` and replace the `BotToken` default value with your Bot's Token.
6. Compile and run the project.

If done correctly, a Console should open, and the logs will inform you when the bot is ready to use.

For now, it only replyies to messages that don't come from a bot, but the basic configuration and boilerplate for an application are already set. Feel free to use it as you like. I would love to see what you create using it, so don't hesitate to message or email me about your implementation!

Don't forget to [Watch](https://github.com/ArthurSander/rotmg-discord-bot/subscription) and Star this repository to be notified when we implement new features and bug fixes!

## Technologies currently used
- C# 12
- .NET 8
- [Discord.Net](https://github.com/discord-net/Discord.Net) (.NET library to build Discord Apps)

## Soon
- Add agnostic logging throughout the application.
- Add persistent data logic (Probably EF Core)
- Configure Terraform and Docker
- Features planned:
    - Staff Applications system:
        - Using the native Discord interface.
        - API (to be consumed on WebApps or other applications)
        - Message Handlers (enable Message Queues)