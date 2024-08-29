# Leaderboard popup

This project presents the work of leaderboard functionality, it is designed to display player rankings, scores, names, types and avatars.
To check it you need to run Unity and start play-mode using SampleScene and then press "Launch" button in the middle of display. After that you will see the popup with list of players that are created in runtime due to data received from Leaderboard.json file, located in Resources folder.
This project uses Zenject for dependency injection, UniTask for asynchronous programming and Addressables for game objects managing system.

Structure of project:
- AddressableAssetsData - consists of files related to Addressables system
- Modules - consists of separate modules of different entities. It is used for easy access approach and project navigation advantage
- Plugins - consists of third party products that project needs for fast development
- Resources - consists of files we may easy access from any point of the project
- Scenes - consists of scene files
- Scripts - consists of script files divided by its purpose, such as Models, Services, Common and other scripts